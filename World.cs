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

    //Chunk handling
    Vector2Int worldCoordinates = new Vector2Int(0,0);
    WorldData worldData = new WorldData();
    BiomeEntity currentBiome;

    //Data
    BiomeData biomeData = new BiomeData();
    ItemData itemData = new ItemData();
    NPCData npcData = new NPCData();
    EnvironmentData environmentData = new EnvironmentData();

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
        //Needs improved when implementing world generation
        BiomeEntity currentBiome = new BiomeEntity(biomeData, "Dark Forest");

        UpdateBiomeGUI(currentBiome.biomeName);

        ChunkData currentChunk = new ChunkData(worldCoordinates, currentBiome);        

        //Populate NPCs in Chunk Data
        for (int i=0; i < currentBiome.numbNPCObj; i++)
        {
            float randFloat = UnityEngine.Random.value;
            float highestChance = 1f;
            string chosenNPC = "";

            foreach (string npc in currentBiome.npcEntities)
            {
                string[] npcArray = npc.Split("%");

                if (float.Parse(npcArray[1]) > randFloat && float.Parse(npcArray[1]) <= highestChance)
                {
                    highestChance = float.Parse(npcArray[1]);
                    chosenNPC = npcArray[0];
                }
            }

            if (chosenNPC != "")
            {
                NPCEntity newNPC = new NPCEntity(npcData, chosenNPC, this);
                currentChunk.AddNPCToList(newNPC);
            }
        }

        //Populate Environment Objects in chunk data
        for (int i=0; i < currentBiome.numbEnvironmentObj; i++)
        {
            float randFloat = UnityEngine.Random.value;
            float highestChance = 1f;
            string chosenObj = "";

            foreach (string obj in currentBiome.environmentEntities)
            {
                string[] objArray = obj.Split("%");

                if (float.Parse(objArray[1]) > randFloat && float.Parse(objArray[1]) <= highestChance)
                {
                    highestChance = float.Parse(objArray[1]);
                    chosenObj = objArray[0];
                }
            }

            if (chosenObj != "")
            {
                EnvironmentEntity newEnvironmentObj = new EnvironmentEntity(environmentData, chosenObj, this);
                currentChunk.AddEnvironmentToList(newEnvironmentObj);
            }
        }

        //Populate items in chunk data
        for (int i=0; i < currentBiome.numbItemObj; i++)
        {
            float randFloat = UnityEngine.Random.value;
            float highestChance = 1f;
            string chosenItem = "";

            foreach (string item in currentBiome.itemEntities)
            {
                string[] itemArray = item.Split("%");

                if (float.Parse(itemArray[1]) > randFloat && float.Parse(itemArray[1]) <= highestChance)
                {
                    highestChance = float.Parse(itemArray[1]);
                    chosenItem = itemArray[0];
                }
            }

            if (chosenItem != "")
            {
                ItemEntity newItem = new ItemEntity(itemData, chosenItem);
                currentChunk.AddItemToList(newItem);
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
        entityList.text += "Nauti\n"; //Player name, needs changed when character creation is added

        foreach (NPCEntity npc in chunk.storedNPCs)
        {
            entityList.text += npc.entityName + "\n";
        }

        foreach (EnvironmentEntity environmentObj in chunk.storedEnvironmentObj)
        {
            entityList.text += environmentObj.entityName + "\n";
        }

        foreach (ItemEntity item in chunk.storedItems)
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
            ChunkData chunk = GetChunkAtWorldCoords();
            UpdateBiomeGUI(chunk.biomeName);
            UpdateEntityList(chunk);
        }
        catch
        {
            Debug.Log("Generating new chunk at " + coordMovement);
            GenerateNewChunk();
        }
    }

    public void SetPosition(Vector2Int newPos)
    {
        worldCoordinates = newPos;
        ChunkData chunk = GetChunkAtWorldCoords();
        UpdateBiomeGUI(chunk.biomeName);
        UpdateEntityList(chunk);
    }

    public ItemEntity CreateItemFromData(string item)
    {
        ItemEntity newItem = new ItemEntity(itemData, item);
        return newItem;
    }

#endregion

#region Add/Remove Entities from chunk
    public void AddItemToCurrentChunk(ItemEntity item)
    {
        ChunkData currentChunk = GetChunkAtWorldCoords();
        currentChunk.AddItemToList(item);
        UpdateEntityList(currentChunk);
    }

    public void RemoveItemFromChunk(ItemEntity item)
    {
        ChunkData currentChunk = GetChunkAtWorldCoords();
        currentChunk.RemoveItemFromList(item);
        UpdateEntityList(currentChunk);
    }

    public void AddNPCToChunk(NPCEntity npc)
    {
        ChunkData currentChunk = GetChunkAtWorldCoords();
        currentChunk.AddNPCToList(npc);
        UpdateEntityList(currentChunk);
    }

    public void RemoveNPCFromChunk(NPCEntity npc)
    {
        ChunkData currentChunk = GetChunkAtWorldCoords();
        currentChunk.RemoveNPCFromList(npc);
        UpdateEntityList(currentChunk);
    }
#endregion

}
