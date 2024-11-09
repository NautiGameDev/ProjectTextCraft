using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

/*
This script is responsible for chunk generation.
Create chunk at world coordinate, instantiate entities, and pass chunk to world data class.
Populate entity list in GUI
Update biome name and chunk coordinates in GUI.
*/
public class World : MonoBehaviour
{
    public Player player;
    public List<BiomeData> biomeData = new List<BiomeData>();

    //Chunk handling
    Vector2Int worldCoordinates = new Vector2Int(0,0);
    WorldData worldData = new WorldData();
    string currentBiome;

    //GUI Objects
    [SerializeField] TextMeshProUGUI biomeName;
    [SerializeField] TextMeshProUGUI mapCoordinates;
    [SerializeField] TextMeshProUGUI entityList;

    void Start()
    {
        UpdatePosition(new Vector2Int(0,0));
    }

    
    void GenerateNewChunk()
    {
        BiomeData newBiome = biomeData[0];

        UpdateBiomeGUI(newBiome.biomeName);
        currentBiome = newBiome.biomeName;

        ChunkData currentChunk = new ChunkData(worldCoordinates, newBiome.biomeName, newBiome.descriptions);        

        for (int i=0; i<newBiome.numb_enemiesToSpawn; i++)
        {
            if (UnityEngine.Random.value <= newBiome.enemySpawnChance)
            {
                int randomChoice = UnityEngine.Random.Range(0, newBiome.enemyEntities.Count - 1);
                NPCData newEnemy = newBiome.enemyEntities[randomChoice];
                currentChunk.AddNPCToList(newEnemy);
            }
        }

        for (int j=0; j<newBiome.numb_npcToSpawn; j++)
        {
            if (UnityEngine.Random.value <= newBiome.npcSpawnChance)
            {
                int randomChoice = UnityEngine.Random.Range(0, newBiome.npcEntities.Count);
                currentChunk.AddNPCToList(newBiome.npcEntities[randomChoice]);
            }
        }

        for (int i= 0; i<newBiome.numb_environmentalObjectsToSpawn; i++)
        {
            if (UnityEngine.Random.value <= newBiome.environmentSpawnChance)
            {
                int randomChoice = UnityEngine.Random.Range(0, newBiome.environmentEntities.Count);
                currentChunk.AddEnvironmentToDictionary(newBiome.environmentEntities[randomChoice]);
            }
        }

        for (int i=0; i<newBiome.numb_itemsToSpawn; i++)
        {
            if (UnityEngine.Random.value <= newBiome.itemSpawnChance)
            {
                int randomChoice = UnityEngine.Random.Range(0, newBiome.itemEntities.Count);
                currentChunk.AddItemToDictionary(newBiome.itemEntities[randomChoice]);
            }
        }

        worldData.AddChunkToDictionary(worldCoordinates, currentChunk);

        UpdateEntityList(currentChunk);
    }

#region GUI Methods
    void UpdateBiomeGUI(string newBiomeName)
    {
        biomeName.text = newBiomeName;
        mapCoordinates.text = "(X: " + worldCoordinates[0] + ", Y: " + worldCoordinates[1] + ")";
    }

    public void UpdateEntityList(ChunkData chunk)
    {

        entityList.text = "";
        entityList.text += "Nauti\n"; //Player name, needs changed

        foreach (NPCData npc in chunk.storedNPCs)
        {
            entityList.text += npc.entityName + "\n";
        }

        foreach (EnvironmentData environmentObj in chunk.storedEnvironmentObj)
        {
            entityList.text += environmentObj.entityName + "\n";
        }

        foreach (ItemData item in chunk.storedItems)
        {
            entityList.text += item.entityName + "\n";
        }
    }
#endregion

#region Setter and Getter Methods
    public ChunkData GetChunkAtWorldCoords()
    {
        return worldData.GetChunkAtPosition(worldCoordinates);
    }

    public void UpdatePosition(Vector2Int coordMovement)
    {

        //Update to generate chunks n,w,s,e of player coordinates

        worldCoordinates += coordMovement;

        try
        {
            ChunkData chunk = worldData.GetChunkAtPosition(worldCoordinates);
            UpdateBiomeGUI(chunk.biome);
            UpdateEntityList(chunk);
        }
        catch
        {
            GenerateNewChunk();
        }
    }

    public void SetPosition(Vector2Int newPos)
    {
        worldCoordinates = newPos;
        ChunkData chunk = worldData.GetChunkAtPosition(newPos);
        UpdateBiomeGUI(chunk.biome);
        UpdateEntityList(chunk);
    }
#endregion

#region Add/Remove Entities from chunk
    public void AddItemToCurrentChunk(ItemData item)
    {
        ChunkData currentChunk = GetChunkAtWorldCoords();
        currentChunk.AddItemToDictionary(item);
        UpdateEntityList(currentChunk);
    }

    public void RemoveItemFromChunk(ItemData item)
    {
        ChunkData currentChunk = GetChunkAtWorldCoords();
        currentChunk.RemoveItemFromDictionary(item);
        UpdateEntityList(currentChunk);
    }

    public void AddNPCToChunk(NPCData npc)
    {
        ChunkData currentChunk = GetChunkAtWorldCoords();
        currentChunk.AddNPCToList(npc);
        UpdateEntityList(currentChunk);
    }

    public void RemoveNPCFromChunk(NPCData npc)
    {
        ChunkData currentChunk = GetChunkAtWorldCoords();
        currentChunk.RemoveNPCFromDictionary(npc);
        UpdateEntityList(currentChunk);
    }
#endregion

}
