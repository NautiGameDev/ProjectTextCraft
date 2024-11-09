using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/*
Handles core data for NPC types. Ex: Goblin Archer, Dwarf Civilian, Etc.
These values are used to generate NPC class in world.
*/

[CreateAssetMenu(fileName ="NPC Data" ,menuName ="Data/NPC Data")]
public class NPCData : ScriptableObject
{
    public enum NPCState {ALIVE, DEAD}
    public NPCState currentState = NPCState.ALIVE;

    //EquipmentData npcInventory = new EquipmentData();

    public string entityName;
    public string npcRace;
    public int npcAge;

    public string npcSex;

    public string npcSkinTone;
    public string npcHairColor;
    public string npcHairType;
    public string npcEyeColor;
    public string npcFacialHair;

    //Base stats
    public int npcConstitution;
    public int npcStrength;
    public int npcDexterity;
    public int npcIntelligence;
    public int npcWisdom;
    public int npcCharisma;

    //Dynamic stats
    int npcMaxHealth;
    int npcCurrentHealth;
    int npcMeleeDamage;
    int npcRangeDamage;
    int npcMagicDamage;

    public ItemData[] dropTable;
    public ItemData[] equipment;

    public NPCData corpseObj;

    public string[] attackMessages;
    public string[] listenMessages;
    public string[] inspectMessages;
    public string[] gatherMessages;
    public string[] lootMessages;


#region methods to update dynamic stats
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
        npcMaxHealth = baseHP + (npcConstitution * 1);
        npcCurrentHealth = npcMaxHealth;
        Debug.Log("NPC health: " + npcCurrentHealth);
    }

    void CalculateMeleeDamage()
    {
        //NPC starts with a base damage determined by race.
        //For each point in strength add 2 melee damage to the NPC.
        //Will need to add methods in future to get str modifiers from inventory

        int baseDMG = 3;
        npcMeleeDamage = baseDMG + (npcStrength * 1);
    }

    void CalculateRangedDamage()
    {
        //NPC starts with a base ranged damage determined by race.
        //For each point in dexterity add 2 range damage to the NPC.
        //Will need to add methods in the future to get dex modifiers from inventory.

        int baseDMG = 3;
        npcRangeDamage = baseDMG + (npcDexterity * 1);
    }

    void CalculateMagicDamage()
    {
        //Player starts with a base magic damage determined by race.
        //For each point in intelligence add 2 magic damage to the player.
        //Will need to add methods in the future to get int modifiers from inventory.

        int baseDMG = 3;
        npcMagicDamage = baseDMG + (npcIntelligence * 1);
    }

#endregion

#region Message Getter methods
    public string GetGatherMessage()
    {
        int randomChoice = UnityEngine.Random.Range(0, gatherMessages.Length-1);
        return gatherMessages[randomChoice];
    }

    public string GetInspectMessage()
    {
        int randomChoice = UnityEngine.Random.Range(0, inspectMessages.Length-1);
        return inspectMessages[randomChoice];
    }

    public string GetListenMessage()
    {
        int randomChoice = UnityEngine.Random.Range(0, listenMessages.Length-1);
        return listenMessages[randomChoice];
    }

    public string GetAttackMessage()
    {
        int randomChoice = UnityEngine.Random.Range(0, attackMessages.Length-1);
        return attackMessages[randomChoice];
    }

    public string GetLootMessage()
    {
        int randomChoice = UnityEngine.Random.Range(0, lootMessages.Length - 1);
        return lootMessages[randomChoice];
    }
    
#endregion

#region Combat Methods

    public bool IsAlive()
    {
        if (currentState==NPCState.ALIVE)
        {
            return true;
        }

        return false;
    }

    public int[] ResolveDamage(int dmg)
    {
        Debug.Log("Resolving damage against NPC");
        int armor = 0;
        foreach (ItemData item in equipment)
        {
            armor += item.ArmorModifier;
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
        Debug.Log("Getting npc melee damage");
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

        foreach (ItemData item in equipment)
        {
            diceToRoll += item.GetDiceQuantity();
        }

        return diceToRoll;
    }

    public int GetArmorStat()
    {
        int armor = 0;
        foreach (ItemData item in equipment)
        {
            armor += item.ArmorModifier;
        }

        return armor;
    }

    public List<ItemData> GetRandomLoot()
    {
        Debug.Log("Getting random loot from " + entityName);

        List<ItemData> lootedItems = new List<ItemData>();

        int randomNumb = UnityEngine.Random.Range(0, dropTable.Length - 1);
        lootedItems.Add(dropTable[randomNumb]);

        for (int i = 0; i < equipment.Length; i++)
        {
            lootedItems.Add(equipment[i]);
            
        }

        return lootedItems;

    }

#endregion

}
