using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

/*
This script stores biome data and lists of spawnable entities for each biome
Entity strings contain a spawn chance for each entity whic is noted by "%numb".
    This spawn chance will be split and converted to a float in world generation.
Likewise variable strings are split by % between variable names and data.
    Example: NumbEnemies%3 will roll the dice 3 times to randomly generate an enemy.
        Entity generation will produce random float between 0 and 1. Algorithm will search for
            entity with probably just above rolled number.
            Example: Game rolls 0.4 and Siren has a 0.45 chance of spawning, while crab has 0.7 chance of spawning,
            the siren will be spawned.

*/

public class BiomeData
{

    public Dictionary<string, Dictionary<string, string>> biomeDict = new Dictionary<string, Dictionary<string, string>>()
    {
        {"Dark Forest", 
            new Dictionary<string, string>()
            {
                {"Name", "Dark Forest"},
                {"NumbNPCObj", "1"},
                {"NumbEnvironmentObj","5"},
                {"NumbItemObj","1"},
                {"Humidity","0"},
                {"Temperature","0"},
                {"Altitude","0"},
                {"Description","You enter a dark forest. A shroud of miss surrounds you./You enter a dark forest. The surrounding mist greatly impairs your vision."},
                {"NPCEntities", "Goblin%1"},
                {"ItemEntities", "Acorn%1"},
                {"EnvironmentEntities", "Oak Tree%1"}
            }
         }         
    };
}
        
    

