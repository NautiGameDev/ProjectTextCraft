using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This class stores player inventory data.
Methods allow for add, remove, and retrieval of items in inventory.
Current weight keeps track of item weights of stored inventory data.
=> Add/Subtract weight values as inventory items come in and out of inventory.
Key ring dictionary stores player keys to access locked doors and chests.
*/

public class InventoryData
{
    Dictionary<ItemData, int> inventoryDict = new Dictionary<ItemData, int>();

    float currentWeight;

    public float GetCurrentInventoryWeight()
    {
        return currentWeight;
    }

    public void PlaceItemInInventory(ItemData item)
    {
        if (!inventoryDict.ContainsKey(item))
        {
            inventoryDict.Add(item, 1);
        }
        else if (inventoryDict.ContainsKey(item))
        {
            inventoryDict[item] += 1;
        }

            currentWeight += item.weight_kg;
    }

    public void RemoveItemInInventory(string target)
    {
        foreach (ItemData item in inventoryDict.Keys)
        {
            if (item.entityName.ToLower() == target)
            {
                inventoryDict.Remove(item);
                break;
            }
        }
    }

    public ItemData GetItemInInventory(string target)
    {
        Debug.Log("Inventory Method: Get Item From Inventory: " + target);


        foreach (ItemData obj in inventoryDict.Keys)
        {
            if (obj.entityName.ToLower() == target)
            {
                return obj;
            }
        }

        return null;
    }

    public string GetInventory()
    {
        if (inventoryDict.Count == 0)
            {
                return "You pack is empty.";
            }

        string inventoryString = "Current Inventory:";

        foreach (ItemData obj in inventoryDict.Keys)
        {
            inventoryString += "\n" + obj.entityName + " x" + inventoryDict[obj];
        }

        return inventoryString;
    }
}
