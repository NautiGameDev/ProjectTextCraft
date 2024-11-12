using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

/*
NPC Object that is instantiated into the world upon chunk generation.
*/

public class NPCEntity
{
    public enum NPCState {ALIVE, DEAD}
    public NPCState currentState = NPCState.ALIVE;

    public string entityName;
    string npcRace;
    int npcAge;

    //Appearance
    string npcSex;
    string npcSkinTone;
    string npcHairColor;
    string npcHairType;
    string npcEyeColor;
    string npcFacialHair;

    //Base stats
    int npcConstitution;
    int npcStrength;
    int npcDexterity;
    int npcIntelligence;
    int npcWisdom;
    int npcCharisma;

    //Dynamic stats
    int npcMaxHealth;
    int npcCurrentHealth;
    int npcMeleeDamage;
    int npcRangeDamage;
    int npcMagicDamage;

    public Dictionary<ItemEntity, float> dropTableDict = new Dictionary<ItemEntity, float>();
    public List<ItemEntity> equipment = new List<ItemEntity>();



    string attackMessage;
    string listenMessage;
    string inspectMessage;
    string gatherMessage;
    string lootMessage;

    string deadAttackMessage;
    string deadListenMessage;
    string deadInspectMessage;
    string deadGatherMessage;
    string deadLootMessage;

    //References
    World gameWorld;


    public NPCEntity(NPCData npcData, string npc, World world)
    {
        Dictionary<string, string> npcInfo = npcData.NPCDict[npc];

        entityName = npcInfo["EntityName"];
        npcRace = npcInfo["EntityRace"];
        
        npcConstitution = int.Parse(npcInfo["Constitution"]);
        npcStrength = int.Parse(npcInfo["Strength"]);
        npcDexterity = int.Parse(npcInfo["Dexterity"]);
        npcIntelligence = int.Parse(npcInfo["Intelligence"]);
        npcWisdom = int.Parse(npcInfo["Wisdom"]);
        npcCharisma = int.Parse(npcInfo["Charisma"]);

        gameWorld = world;
        
        string[] dropTableStrings = npcInfo["DropTable"].Split("/");
        PopulateDropTable(dropTableStrings);

        string[] equipmentStrings = npcInfo["Equipment"].Split("/");
        PopulateEquipment(equipmentStrings);

        attackMessage = npcInfo["AttackMessage"];
        listenMessage = npcInfo["ListenMessage"];
        inspectMessage = npcInfo["InspectMessage"];
        gatherMessage = npcInfo["GatherMessage"];
        lootMessage = npcInfo["LootMessage"];

        deadAttackMessage = npcInfo["DeadAttackMessage"];
        deadListenMessage = npcInfo["DeadListenMessage"];
        deadInspectMessage = npcInfo["DeadInspectMessage"];
        deadGatherMessage = npcInfo["DeadGatherMessage"];
        deadLootMessage = npcInfo["DeadLootMessage"];

        UpdateDynamicStats();
    }


#region object instantiation methods

    void PopulateDropTable(string[] dropTableStrings)
    {
        foreach (string itemString in dropTableStrings)
        {
            string[] newStringArray = itemString.Split("%");
            if (newStringArray[0] != "")
            {
                ItemEntity item = gameWorld.CreateItemFromData(newStringArray[0]);
                dropTableDict.Add(item, float.Parse(newStringArray[1]));
            }
        }
    }

    void PopulateEquipment(string[] equipmentStrings)
    {
        if (equipmentStrings[0] != "")
        {
            for (int i = 0; i<equipmentStrings.Length; i++)
            {
                Debug.Log("Populating equipment[NPC:" + entityName + "] " + equipmentStrings[i]);
                ItemEntity newItem = gameWorld.CreateItemFromData(equipmentStrings[i]);
                equipment.Add(newItem);
            }
        }
    }

    public void UpdateDynamicStats()
    {
        //Get base stats at character creation in world
        CalculateHealth();
        CalculateMeleeDamage();
        CalculateRangedDamage();
        CalculateMagicDamage();
    }

    void CalculateHealth()
    {
        //NPC starts at a base HP determined by class.
        //For each point in constituion add 2hp to the NPC.
        //Will need to add methods in future to get const modifiers from inventory

        int baseHP = 15;
        npcMaxHealth = baseHP + (npcConstitution * 2);
        npcCurrentHealth = npcMaxHealth;
    }

    void CalculateMeleeDamage()
    {
        //NPC starts with a base damage determined by race.
        //For each point in strength add 1 melee damage to the NPC.
        //Will need to add methods in future to get str modifiers from inventory

        int baseDMG = 3;
        npcMeleeDamage = baseDMG + (npcStrength * 1);
    }

    void CalculateRangedDamage()
    {
        //NPC starts with a base ranged damage determined by race.
        //For each point in dexterity add 1 range damage to the NPC.
        //Will need to add methods in the future to get dex modifiers from inventory.

        int baseDMG = 3;
        npcRangeDamage = baseDMG + (npcDexterity * 1);
    }

    void CalculateMagicDamage()
    {
        //Player starts with a base magic damage determined by race.
        //For each point in intelligence add 1 magic damage to the player.
        //Will need to add methods in the future to get int modifiers from inventory.

        int baseDMG = 3;
        npcMagicDamage = baseDMG + (npcIntelligence * 1);
    }

#endregion

#region Message Getter methods
    public string GetGatherMessage()
    {

        return currentState == NPCState.DEAD ? deadGatherMessage : gatherMessage;
    }

    public string GetInspectMessage()
    {
        return currentState == NPCState.DEAD ? deadInspectMessage : inspectMessage;
    }

    public string GetListenMessage()
    {
        return currentState == NPCState.DEAD ? deadListenMessage : listenMessage;
    }

    public string GetAttackMessage()
    {
        return currentState == NPCState.DEAD ? deadAttackMessage : attackMessage;
    }

    public string GetLootMessage()
    {
        return currentState == NPCState.DEAD ? deadLootMessage: lootMessage;
    }
    
#endregion

#region Combat Methods

    public bool IsAlive()
    {
        return currentState == NPCState.ALIVE ? true : false;
    }

    public int[] ResolveDamage(int dmg)
    {
        Debug.Log("Resolving damage against NPC");
        int armor = 0;
        foreach (ItemEntity item in equipment)
        {
            armor += item.GetArmorQuantity();
        }


        npcCurrentHealth -= dmg - armor;

        if (npcCurrentHealth < 0)
        {
            npcCurrentHealth = 0;
        }

        int[] npcHealthStats = new int[] {npcCurrentHealth, npcMaxHealth};
        return npcHealthStats;
    }

    public int GetMeleeDamage()
    {
        return npcMeleeDamage;
    }

    public int GetRangeDamage()
    {
        return npcRangeDamage;
    }

    public int GetMagicDamage()
    {
        return npcMagicDamage;
    }

    public int GetCurrentHealth()
    {
        return npcCurrentHealth;
    }

    public int GetWeaponDice()
    {
        int diceToRoll = 0;

        foreach (ItemEntity item in equipment)
        {
            diceToRoll += item.GetDiceQuantity();
        }

        return diceToRoll;
    }

    public int GetArmorStat()
    {
        int armor = 0;
        foreach (ItemEntity item in equipment)
        {
            armor += item.GetArmorQuantity();
        }

        return armor;
    }

    public List<ItemEntity> GetRandomLoot()
    {
        //Returns list of items to actions handle which is iterated through and each item is added to player inventory
        //Random item is chosen from drop table based on probability, then a list is created with the equiped items + random drop item

        Debug.Log("Getting random loot from " + entityName);

        List<ItemEntity> lootedItems = new List<ItemEntity>();

        float randomNumb = UnityEngine.Random.value;
        float highestChance = 1f;
        ItemEntity chosenItem = null;

        foreach (ItemEntity item in dropTableDict.Keys)
        {

            if (dropTableDict[item] > randomNumb && dropTableDict[item] <= highestChance)
            {
                highestChance = dropTableDict[item];
                chosenItem = item;
            }
        }

        if (chosenItem != null)
        {
            lootedItems.Add(chosenItem);
        }


        for (int i = 0; i < equipment.Count; i++)
        {
            lootedItems.Add(equipment[i]);
        }

        return lootedItems;

    }

#endregion

}

