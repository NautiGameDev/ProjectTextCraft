using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEntity
{
       
    public enum entTypes {MATERIAL, CONSUMABLE, EQUIPABLE, KEY}
    public enum equipableSlot {NONE, HEAD, SHOULDERS, CHEST, WRIST, HANDS, WAIST, LEGS, FEET, MAINHAND, OFFHAND, FINGER, NECK}

    public string entityName;
    public entTypes entityType;
    public equipableSlot entitySlot;
    public float weight_kg;
    public int quantity = 1;

    public Dictionary<string, int> itemModifiers = new Dictionary<string, int>() 
    {
        {"Armor", 0},
        {"Strength", 0},
        {"Dexterity", 0},
        {"Constitution", 0},
        {"Intelligence", 0},
        {"Charisma", 0}
    };

    public int ATKDiceNumber;
    
    
    public string attackMessage;
    public string listenMessage;
    public string inspectMessage;
    public string gatherMessage;
    public string lootMessage;

    public ItemEntity(ItemData itemData, string item)
    {
        Dictionary<string, string> newItem = itemData.itemDictionary[item];
        Debug.Log("Creating " + item + " from construct.");

        entityName = newItem["EntityName"];
        entityType = SetEntityType(newItem["EntityType"]);
        entitySlot = SetEquipableSlot(newItem["EquipableSlot"]);
        weight_kg = float.Parse(newItem["Weight_KG"]);

        Dictionary<string, int> tempItemMods = new Dictionary<string, int>();

        foreach (string modifier in itemModifiers.Keys)
        {
            tempItemMods[modifier] = int.Parse(newItem[modifier]);
        }

        itemModifiers = tempItemMods;

        ATKDiceNumber = int.Parse(newItem["DiceAmount"]);

        attackMessage = newItem["AttackMessage"];
        listenMessage = newItem["ListenMessage"];
        inspectMessage = newItem["InspectMessage"];
        gatherMessage = newItem["GatherMessage"];
        lootMessage = newItem["LootMessage"];
    }

    private entTypes SetEntityType(string eType)
    {
        if (eType == "Material")
        {
            return entTypes.MATERIAL;
        }
        else if (eType == "Consumable")
        {
            return entTypes.CONSUMABLE;
        }
        else if (eType == "Equipable")
        {
            return entTypes.EQUIPABLE;
        }
        else if (eType == "Key")
        {
            return entTypes.KEY;
        }

        return entTypes.MATERIAL;
    }

    private equipableSlot SetEquipableSlot(string slot)
    {
        if (slot == "Head")
        {
            return equipableSlot.HEAD;
        }
        else if (slot == "Shoulders")
        {
            return equipableSlot.SHOULDERS;
        }
        else if (slot == "Chest")
        {
            return equipableSlot.CHEST;
        }
        else if (slot == "Hands")
        {
            return equipableSlot.HANDS;
        }
        else if (slot == "Wrist")
        {
            return equipableSlot.WRIST;
        }
        else if (slot == "Waist")
        {
            return equipableSlot.WAIST;
        }
        else if (slot == "Legs")
        {
            return equipableSlot.LEGS;
        }
        else if (slot == "Feet")
        {
            return equipableSlot.FEET;
        }
        else if (slot == "MainHand")
        {
            return equipableSlot.MAINHAND;
        }
        else if (slot == "Finger")
        {
            return equipableSlot.FINGER;
        }
        else if (slot == "Neck")
        {
            return equipableSlot.NECK;
        }

        return equipableSlot.NONE;
    }

    public int GetDiceQuantity()
    {
        return ATKDiceNumber;
    }

    public int GetArmorQuantity()
    {
        return itemModifiers["Armor"];
    }

    public string GetGatherMessage()
    {
        return gatherMessage;
    }

    public string GetInspectMessage()
    {
        return inspectMessage;
    }

    public string GetListenMessage()
    {
        return listenMessage;
    }

    public string GetAttackMessage()
    {
        return attackMessage;
    }    
}
