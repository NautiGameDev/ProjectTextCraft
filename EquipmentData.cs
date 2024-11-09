using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This class stores data of equiped items for each slot.
Methods allow for add and removal of items, and retrieval of information.
Class keeps track of total weight of inventory as items are added/removed.
*/

public class EquipmentData
{
    ItemData headSlot = null;
    ItemData chestSlot = null;
    ItemData shouldersSlot = null;
    ItemData beltSlot = null;
    ItemData bootSlot = null;
    ItemData legsSlot = null;
    ItemData wristSlot = null;
    ItemData glovesSlot = null;
    ItemData mainHandSlot = null;
    ItemData offHandSlot = null;
    ItemData mainHandRingSlot = null;
    ItemData offHandRingSlot = null;
    ItemData necklaceSlot = null;

    float currentWeight;
    int armorStat = 0;

    int strengthModifier;
    int dexterityModifier;
    int constitutionModifier;
    int intelligenceModifier;
    int wisdomModifier;
    int charismaModifier;

    public ItemData GetItemInSlot(string slot)
    {
        switch(slot)
        {
            case "head":
                return headSlot;
                
            case "shoulders":
                return shouldersSlot;
            
            case "chest":
                return chestSlot;
                
            case "belt":
                return beltSlot;
            
            case "legs":
                return legsSlot;

            case "boots":
                return bootSlot;

            case "gloves":
                return glovesSlot;

            case "wrist":
                return wristSlot;

            case "mainHand":
                return mainHandSlot;

            case "mainHandRing":
                return mainHandRingSlot;

            case "offHand":
                return offHandSlot;
            
            case "offHandRing":
                return offHandRingSlot;

            case "amulet":
                return necklaceSlot;

            default:
                return null;
        }
    }

    public void EquipItemToSlot(ItemData item)
    {
        switch(item.entitySlot)
        {
            case ItemData.equipableSlot.HEAD:
                headSlot = item;
                break;
                
            case ItemData.equipableSlot.SHOULDERS:
                shouldersSlot = item;
                break;
            
            case ItemData.equipableSlot.CHEST:
                chestSlot = item;
                break;
                
            case ItemData.equipableSlot.WAIST:
                beltSlot = item;
                break;
            
            case ItemData.equipableSlot.LEGS:
                legsSlot = item;
                break;

            case ItemData.equipableSlot.FEET:
                bootSlot = item;
                break;

            case ItemData.equipableSlot.HANDS:
                glovesSlot = item;
                break;

            case ItemData.equipableSlot.WRIST:
                wristSlot = item;
                break;

            case ItemData.equipableSlot.MAINHAND:
                mainHandSlot = item;
                break;

            case ItemData.equipableSlot.FINGER:  //Need logic here to check for empty finger slot
                mainHandRingSlot = item;
                break;

            case ItemData.equipableSlot.OFFHAND:
                offHandSlot = item;
                break;
            
            case ItemData.equipableSlot.NECK:
                necklaceSlot = item;
                break;

            default:
                Debug.Log("Item " + item.entityName + " couldn't be equipped.");
                break;
        }

        currentWeight += item.weight_kg;
        armorStat += item.ArmorModifier;
    }

    public float GetEquipmentWeight()
    {
        return currentWeight;
    }

    public int GetArmorStat()
    {
        return armorStat;
    }

    public string GetEquipedItems()
    {
        string equippedItems = "-=Equipped Items=-";
        
        if (mainHandSlot != null)
        {
            equippedItems += "\nMain Hand: " + mainHandSlot.entityName;
        }
        else if (mainHandSlot == null)
        {
            equippedItems += "\nMain Hand: empty";
        }

        if (offHandSlot != null)
        {
            equippedItems += "\nOff Hand: " + offHandSlot.entityName;
        }
        else if (offHandSlot == null)
        {
            equippedItems += "\nOff Hand: empty";
        }

        if (headSlot != null)
        {
            equippedItems += "\nHead: " + headSlot.entityName;
        }
        else if (headSlot == null)
        {
            equippedItems += "\nHead: empty";
        }

        if (shouldersSlot != null)
        {
            equippedItems += "\nShoulders: " + shouldersSlot.entityName;
        }
        else if (shouldersSlot == null)
        {
            equippedItems += "\nShoulders: empty";
        }

        if (chestSlot != null)
        {
            equippedItems += "\nChest: " + chestSlot.entityName;
        }
        else if (chestSlot == null)
        {
            equippedItems += "\nChest: empty";
        }

        if (glovesSlot != null)
        {
            equippedItems += "\nGloves: " + glovesSlot.entityName;
        }
        else if (glovesSlot == null)
        {
            equippedItems += "\nGloves: empty";
        }

        if (wristSlot != null)
        {
            equippedItems += "\nWrist: " + wristSlot.entityName;
        }
        else if (wristSlot == null)
        {
            equippedItems += "\nWrist: empty";
        }
        
        if (beltSlot != null)
        {
            equippedItems += "\nWaist: " + beltSlot.entityName;
        }
        else if (beltSlot == null)
        {
            equippedItems += "\nWaist: empty";
        }

        if (legsSlot != null)
        {
            equippedItems += "\nLegs: " + legsSlot.entityName;
        }
        else if (legsSlot == null)
        {
            equippedItems += "\nLegs: empty";
        }

        if (bootSlot != null)
        {
            equippedItems += "\nBoots: " + bootSlot.entityName;
        }
        else if (bootSlot == null)
        {
            equippedItems += "\nBoots: empty";
        }
        
        if (mainHandRingSlot != null)
        {
            equippedItems += "\nRing(Main Hand): " + mainHandRingSlot.entityName;
        }
        else if (mainHandRingSlot == null)
        {
            equippedItems += "\nRing(Main Hand): empty";
        }

        if (offHandRingSlot != null)
        {
            equippedItems += "\nRing(Off Hand): " + offHandRingSlot.entityName;
        }
        else if (offHandRingSlot == null)
        {
            equippedItems += "\nRing(Off Hand): empty";
        }

        if (necklaceSlot != null)
        {
            equippedItems += "\nAmulet: " + necklaceSlot.entityName;
        }
        else if (necklaceSlot == null)
        {
            equippedItems += "\nAmulet: empty";
        }


        return equippedItems;
    }

    public Dictionary<string, int> GetModifiers()
    {
        Dictionary<string, int> modifierDict = new Dictionary<string, int>();

        modifierDict.Add("str", strengthModifier);
        modifierDict.Add("dex", dexterityModifier);
        modifierDict.Add("int", intelligenceModifier);
        modifierDict.Add("wis", wisdomModifier);
        modifierDict.Add("con", constitutionModifier);
        modifierDict.Add("cha", charismaModifier);

        return modifierDict;
    }

}
