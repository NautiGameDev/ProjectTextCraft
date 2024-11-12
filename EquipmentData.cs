using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

/*
This class stores data of equiped items for each slot.
Methods allow for add and removal of items, and retrieval of information.
Class keeps track of total weight of inventory as items are added/removed.
*/

public class EquipmentData
{

    Dictionary<string, ItemEntity> equippedItems = new Dictionary<string, ItemEntity> 
    { 
        {"HeadSlot", null},
        {"ChestSlot", null},
        {"ShouldersSlot", null},
        {"HandSlot", null},
        {"WristSlot", null},
        {"WaistSlot", null},
        {"LegsSlot", null},
        {"FeetSlot", null},
        {"MainHandSlot", null},
        {"OffHandSlot", null},
        {"MainHandRingSlot", null},
        {"OffHandRingSlot", null},
        {"NeckSlot", null}
    };

    float currentWeight;
    
    Dictionary<string, int> equipmentModifiers = new Dictionary<string, int>() 
    {
        {"Armor", 0},
        {"Strength", 0},
        {"Dexterity", 0},
        {"Constitution", 0},
        {"Intelligence", 0},
        {"Charisma", 0}
    };

    public ItemEntity GetItemInSlot(string slot)
    {
        return equippedItems[slot];
    }

    public string EquipItemToSlot(ItemEntity item) //Update to return bool to prevent bugs on equip item error
    {
        switch(item.entitySlot)
        {
            case ItemEntity.equipableSlot.HEAD:
                if (equippedItems["HeadSlot"] == null)
                {
                    equippedItems["HeadSlot"] = item;
                    UpdateEquipmentModifiers(item, "add");
                    return "You equip the " + item.entityName + "to your head slot.";
                }
                else
                {
                    return "You already have an item equipped to your head slot";
                }
                
            case ItemEntity.equipableSlot.SHOULDERS:
                if (equippedItems["ShouldersSlot"] == null)
                {
                    equippedItems["ShouldersSlot"] = item;
                    UpdateEquipmentModifiers(item, "add");
                    return "You equip the " + item.entityName + " to your shoulders slot.";
                }
                else
                {
                    return "You already have an item equipped to your shoulders slot.";
                }
            
            case ItemEntity.equipableSlot.CHEST:
                if (equippedItems["ChestSlot"] == null)
                {
                    equippedItems["ChestSlot"] = item;
                    UpdateEquipmentModifiers(item, "add");
                    return "You equip the " + item.entityName + " to your chest slot.";
                }
                else
                {
                    return "You already have an item equipped to your chest slot.";
                }
                
                
            case ItemEntity.equipableSlot.WAIST:
                if (equippedItems["WaistSlot"] == null)
                {
                    equippedItems["WaistSlot"] = item;
                    UpdateEquipmentModifiers(item, "add");
                    return "You equip the " + item.entityName + " to your waist slot.";
                }
                else
                {
                    return "You already have an item equipped to your waist slot.";
                }
                
            
            case ItemEntity.equipableSlot.LEGS:
                if (equippedItems["LegsSlot"] == null)
                {
                    equippedItems["LegsSlot"] = item;
                    UpdateEquipmentModifiers(item, "add");
                    return "You equip the " + item.entityName + " to your legs slot.";
                }
                else
                {
                    return "You already have an item equipped to your legs slot.";
                }

            case ItemEntity.equipableSlot.FEET:
                if (equippedItems["FeetSlot"] == null)
                {
                    equippedItems["FeetSlot"] = item;
                    UpdateEquipmentModifiers(item, "add");
                    return "You equip the " + item.entityName + " to your feet slot.";
                }
                else
                {
                    return "You already have an item equipped to your feet slot.";
                }

            case ItemEntity.equipableSlot.HANDS:
                
                if (equippedItems["HandSlot"] == null)
                {
                    equippedItems["HandSlot"] = item;
                    UpdateEquipmentModifiers(item, "add");
                    return "You equip the " + item.entityName + " to your hands slot.";
                }
                else
                {
                    return "You already have an item equipped to your hands slot.";
                }

            case ItemEntity.equipableSlot.WRIST:
                if (equippedItems["WristSlot"] == null)
                {
                    equippedItems["WristSlot"] = item;
                    UpdateEquipmentModifiers(item, "add");
                    return "You equip the " + item.entityName + " to your wrist slot.";
                }
                else
                {
                    return "You already have an item equipped to your wrist slot.";
                }
                

            case ItemEntity.equipableSlot.MAINHAND:
                if (equippedItems["MainHandSlot"]==null)
                {
                    equippedItems["MainHandSlot"] = item;
                    UpdateEquipmentModifiers(item, "add");
                    return "You equip the " + item.entityName + " to your main hand slot.";
                }
                else
                {
                    return "You already have an item equipped to your main hand slot.";
                }

            case ItemEntity.equipableSlot.FINGER:  //Need logic here to check for empty finger slot
                if (equippedItems["MainHandRingSlot"] == null)
                {
                    equippedItems["MainHandRingSlot"] = item;
                    UpdateEquipmentModifiers(item, "add");
                    return "You equip the " + item.entityName + " to your main hand ring finger.";
                }
                else if (equippedItems["OffHandRingSlot"] == null)
                {
                    equippedItems["OffHandRingSlot"] = item;
                    UpdateEquipmentModifiers(item, "add");
                    return "You equip the " + item.entityName + " to your off hand ring finger.";
                }
                else
                {
                    return "You don't have an empty ring finger to equip " + item.entityName;
                }

            case ItemEntity.equipableSlot.OFFHAND:
                if (equippedItems["OffHandSlot"] == null)
                {
                    equippedItems["OffHandSlot"] = item;
                    UpdateEquipmentModifiers(item, "add");
                    return "You equip the " + item.entityName + " to your off hand slot.";
                }
                else
                {
                    return "You already have an item equipped to your off hand slot.";
                }
            
            case ItemEntity.equipableSlot.NECK:
                if (equippedItems["NeckSlot"] == null)
                {
                    equippedItems["NeckSlot"] = item;
                    UpdateEquipmentModifiers(item, "add");
                    return "You equip the " + item.entityName + " to your neck slot.";
                }
                else
                {
                    return "You already have an item equipped to your neck slot.";
                }

            default:
                Debug.Log(item.entityName + " couldn't be equipped.");
                break;
        }

        return "Could not equip " + item.entityName; 
    }

    public ItemEntity UnequipItemFromSlot(string target)
    {
        foreach (string slot in equippedItems.Keys)
        {
            if (equippedItems[slot].entityName.ToLower() == target)
            {
                ItemEntity item = equippedItems[slot];
                equippedItems[slot] = null;
                return item;
            }
        }
        
        return null;
    }

    public ItemEntity GetItemEquiped(string target)
    {
        foreach (string slot in equippedItems.Keys)
        {
            if (equippedItems[slot].entityName.ToLower() == target)
            {
                ItemEntity item = equippedItems[slot];
                return item;
            }
        }
        
        return null;
    }

    public void UpdateEquipmentModifiers(ItemEntity item, string command)
    {
        if (command == "add")
        {
            foreach (string modifier in item.itemModifiers.Keys)
            {
                equipmentModifiers[modifier] += item.itemModifiers[modifier];
                currentWeight += item.weight_kg;
            }
        }

        if (command == "remove")
        {
            foreach (string modifier in item.itemModifiers.Keys)
            {
                equipmentModifiers[modifier] -= item.itemModifiers[modifier];
                currentWeight -= item.weight_kg;
            }
        }
    }

    public float GetEquipmentWeight()
    {
        return currentWeight;
    }

    public int GetArmorStat()
    {
        return equipmentModifiers["Armor"];
    }

    public string GetEquipedItems()
    {
        string messageToReturn = "Equipped Items:";

        foreach (string slot in equippedItems.Keys)
        {
            string[] cleanedString = slot.Split("Slot");

            if (equippedItems[slot] != null)
            {
                messageToReturn += "\n" + cleanedString[0] + ": " + equippedItems[slot].entityName;
            }
            else
            {
                messageToReturn += "\n" + cleanedString[0] + ": [empty]";
            }
        }
        
        return messageToReturn;
    }
}
