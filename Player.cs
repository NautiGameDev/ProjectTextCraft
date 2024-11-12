using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerData playerData = new PlayerData("Nauti", 5, 5, 5, 5, 5, 5);
    InventoryData playerInventory = new InventoryData();

    EquipmentData playerEquipment = new EquipmentData();

    public World world;

    public string playerName;
    float maxCarryWeight = 25f;

    

    // Start is called before the first frame update
    void Start()
    {
        playerName = playerData.GetPlayerName();
    }

#region Inventory Methods

    public string AddItemToInventory(ItemEntity item)
    {
        //Test if item can be placed in inventory based on weight
        //If true return message informing player that item has been added
        //If false return message saying the player can't carry anymore weight

        float currentWeight = playerInventory.GetCurrentInventoryWeight();
        if ((currentWeight + item.weight_kg) > maxCarryWeight)
        {
            string errorString = "You can't carry anymore weight. The " + item.entityName + " has been dropped to the ground.";
            world.AddItemToCurrentChunk(item);
            return errorString;
        }

        string stringToReturn = "The " + item.entityName + " has been placed in your pack.";
        playerInventory.PlaceItemInInventory(item);
        return stringToReturn;
    }

    public void RemoveItemFromInventory(string target)
    {
        playerInventory.RemoveItemInInventory(target);
    }

    public ItemEntity GetItemFromInventory(string target)
    {
        
        ItemEntity item = playerInventory.GetItemInInventory(target);
        return item;
    }

    public string GetInventory()
    {
        return playerInventory.GetInventory();
    }
#endregion

#region Equipment Methods

    public string EquipItem(ItemEntity item)
    {
        return playerEquipment.EquipItemToSlot(item);
    }

    public ItemEntity UnequipItem(string target)
    {
        ItemEntity item = playerEquipment.UnequipItemFromSlot(target);
        return item;

    }

    public ItemEntity GetItemEquipped(string target)
    {
        ItemEntity item = playerEquipment.GetItemEquiped(target);
        return item;
    }

    public string GetEquippedItems()
    {
        string equippedItems = playerEquipment.GetEquipedItems();
        return equippedItems;
    }

    public ItemEntity GetEquippedItemInSlot(string slot)
    {
        ItemEntity item = playerEquipment.GetItemInSlot(slot);

        return item;
    }

#endregion

#region set/get methods



#endregion

#region Combat Methods

    public int[] ResolveDamage(int damage)
    {
        int[] returnedHealth = playerData.ResolveDamage(damage);
        return returnedHealth;
    }

    public void RespawnPlayer()
    {
        world.SetPosition(new Vector2Int(0,0));
        playerData.RespawnPlayer();
    }

    public int GetDamage()
    {
        int dmg = playerData.GetMeleeDamage();
        return dmg;
    }

    public int GetArmorStat()
    {
        return playerEquipment.GetArmorStat();
    }

#endregion 
    
}
