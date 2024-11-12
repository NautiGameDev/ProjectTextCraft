using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Chunk class created when new chunk data is instantiated.
This class stores chunk coordinates, noisemap values, and spawned entities.
Methods will allow removal and addition of entities that are used dynamically
    during gameplay.
*/

public class ChunkData
{
    public string biomeName;
    public Vector2Int chunkPosition;
    float altitude;
    float humidity;
    float temperature;
    
    public string[] descriptions;
    public List<NPCEntity> storedNPCs = new List<NPCEntity>();
    public List<ItemEntity> storedItems = new List<ItemEntity>();
    public List<EnvironmentEntity> storedEnvironmentObj = new List<EnvironmentEntity>();

    public ChunkData(Vector2Int worldPosition, BiomeEntity currentBiome)
    {
        Debug.Log("Chunk created at " + worldPosition);
        chunkPosition = worldPosition;
        biomeName = currentBiome.biomeName;
        altitude = currentBiome.altitude;
        temperature = currentBiome.temperature;
        humidity = currentBiome.humidty;
        descriptions = currentBiome.descriptions;
    }

#region Add/Remove Items in World
    public void AddNPCToList(NPCEntity npc)
    {
        storedNPCs.Add(npc);
    }

    public void AddItemToList(ItemEntity item)
    {
        storedItems.Add(item);
    }

    public void AddEnvironmentToList(EnvironmentEntity environment)
    {
        storedEnvironmentObj.Add(environment);
    }

    public void RemoveItemFromList(ItemEntity targetItem)
    {
        foreach (ItemEntity item in storedItems)
        {
            if (item.entityName == targetItem.entityName)
            {
                Debug.Log(item.entityName + " removed from chunk.");
                storedItems.Remove(item);
                break;
            }
        }
    }

    public void RemoveNPCFromList(NPCEntity targetNPC)
    {
        foreach (NPCEntity npc in storedNPCs)
        {
            if (npc.entityName == targetNPC.entityName)
            {
                Debug.Log(npc.entityName + " removed from chunk.");
                storedNPCs.Remove(npc);
                break;
            }
        }
    }
#endregion

    public string GetRandomDescription()
    {
        int randomChoice = UnityEngine.Random.Range(0, descriptions.Length - 1);
        return descriptions[randomChoice];
    }

#region Get Entities In Chunk Methods
    public NPCEntity GetTargetNPC(string target)
    {
        foreach (NPCEntity npc in storedNPCs)
        {
            if (npc.entityName.ToLower() == target)
            {
                return npc;
            }
        }

        return null;
    }

    public ItemEntity GetTargetItem(string target)
    {
        foreach (ItemEntity item in storedItems)
        {
            if (item.entityName.ToLower() == target)
            {
                return item;
            }
        }

        return null;
    }

    public EnvironmentEntity GetTargetEnvironmentObj(string target)
    {
        foreach (EnvironmentEntity obj in storedEnvironmentObj)
        {
            if (obj.entityName.ToLower() == target)
            {
                return obj;
            }
        }

        return null;
    }
#endregion

}

