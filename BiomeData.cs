using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script stores biome data with lists of entities that can potentially
spawn when a chunk is created.
Chance to spawn sets the probability 0-100% of an entity spawning.
Max spawn sets the number of times the program will attempt to spawn an entity of
x type.
*/

[CreateAssetMenu(fileName ="Biome" ,menuName ="Data/Biome")]
public class BiomeData : ScriptableObject
{
    public string biomeName;
    public string[] descriptions;
    public List<EnvironmentData> environmentEntities;
    public List<NPCData> enemyEntities;
    public List<NPCData> npcEntities;
    public List<ItemData> itemEntities;
    public int numb_environmentalObjectsToSpawn;
    public float environmentSpawnChance;
    public int numb_enemiesToSpawn;
    public float enemySpawnChance;
    public int numb_npcToSpawn;
    public float npcSpawnChance;
    public int numb_itemsToSpawn;
    public float itemSpawnChance;
}
