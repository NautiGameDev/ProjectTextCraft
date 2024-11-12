using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentEntity
{
 public enum entTypes {NONE, TREE, ORE, WATER, FURNITURE}

    public string entityName;
    public entTypes entityType;


    public List<ItemEntity> dropTable = new List<ItemEntity>();
    public Dictionary<ItemEntity, float> inventoryTable = new Dictionary<ItemEntity, float>();

    public string attackMessage;
    public string listenMessage;
    public string inspectMessage;
    public string gatherMessage;
    public string lootMessage;

    //References
    World gameWorld;

    public EnvironmentEntity(EnvironmentData envData, string envObj, World world)
    {
        Dictionary<string, string> environmentObj = envData.EnvironmentDict[envObj];
        gameWorld = world;

        entityName = environmentObj["EntityName"];
        entityType = SetEntityType(environmentObj["EntityType"]);
        
        string[] dropTableArray = environmentObj["Drop Table"].Split("/");
        PopulateDropTable(dropTableArray);

        string[] inventoryTableArray = environmentObj["Inventory"].Split("/");
        PopulateInventory(inventoryTableArray);


        attackMessage = environmentObj["AttackMessage"];
        listenMessage = environmentObj["ListenMessage"];
        inspectMessage = environmentObj["InspectMessage"];
        gatherMessage = environmentObj["GatherMessage"];
        lootMessage = environmentObj["LootMessage"];

        
    }

    private entTypes SetEntityType(string eType)
    {
        if (eType == "Tree")
        {
            return entTypes.TREE;
        }
        else if (eType == "Ore")
        {
            return entTypes.ORE;
        }
        else if (eType == "Water")
        {
            return entTypes.WATER;
        }
        else if (eType == "Furniture")
        {
            return entTypes.FURNITURE;
        }

        return entTypes.NONE;
    }

    void PopulateDropTable(string[] dropTableArray)
    {
        if (dropTableArray[0] != "")
        {
            for (int i=0; i < dropTableArray.Length; i++)
            {
                ItemEntity newItem = gameWorld.CreateItemFromData(dropTableArray[i]);
                dropTable.Add(newItem);
            }
        }
    }

    void PopulateInventory(string[] inventoryTableArray)
    {
        foreach (string itemString in inventoryTableArray)
        {
            string[] parsedItemString = itemString.Split("%");
            if (parsedItemString[0] != "")
            {
                ItemEntity newItem = gameWorld.CreateItemFromData(parsedItemString[0]);
                inventoryTable.Add(newItem, float.Parse(parsedItemString[1]));
            }
        }
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

    public ItemEntity GetItemFromInventory()
    {
        //Returns random item upon gather/harvest commands

        float randomNumb = UnityEngine.Random.value;
        float highestChance = 1f;
        ItemEntity chosenItem = null;

        foreach (ItemEntity item in inventoryTable.Keys)
        {
            if (randomNumb < inventoryTable[item] && inventoryTable[item] <= highestChance)
            {
                highestChance = inventoryTable[item];
                chosenItem = item;
            }
        }

        return chosenItem;
    }

    
}
