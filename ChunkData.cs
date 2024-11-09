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
    public Vector2Int chunkPosition;
    float altitude;
    float moisture;
    float temperature;
    public string biome;
    string[] descriptions;
    public List<NPCData> storedNPCs = new List<NPCData>();
    public List<ItemData> storedItems = new List<ItemData>();
    public List<EnvironmentData> storedEnvironmentObj = new List<EnvironmentData>();

    public ChunkData(Vector2Int worldPosition, string chunkBiome, string[] biomeDescriptions)
    {
        chunkPosition = worldPosition;
        biome = chunkBiome;
        descriptions = biomeDescriptions;
    }

#region Add/Remove Items in World
    public void AddNPCToList(NPCData npc)
    {
        storedNPCs.Add(npc);
        npc.UpdateDynamicStats();
    }

    public void AddItemToDictionary(ItemData item)
    {
        storedItems.Add(item);
    }

    public void AddEnvironmentToDictionary(EnvironmentData environment)
    {
        storedEnvironmentObj.Add(environment);
    }

    public void RemoveItemFromDictionary(ItemData targetItem)
    {
        foreach (ItemData item in storedItems)
        {
            if (item.entityName == targetItem.entityName)
            {
                Debug.Log(item + " removed from chunk.");
                storedItems.Remove(item);
                break;
            }
        }
    }

    public void RemoveNPCFromDictionary(NPCData targetNPC)
    {
        foreach (NPCData npc in storedNPCs)
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
    public NPCData GetTargetNPC(string target)
    {
        foreach (NPCData npc in storedNPCs)
        {
            if (npc.entityName.ToLower() == target)
            {
                return npc;
            }
        }

        return null;
    }

    public ItemData GetTargetItem(string target)
    {
        foreach (ItemData item in storedItems)
        {
            if (item.entityName.ToLower() == target)
            {
                return item;
            }
        }

        return null;
    }

    public EnvironmentData GetTargetEnvironmentObj(string target)
    {
        foreach (EnvironmentData obj in storedEnvironmentObj)
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

