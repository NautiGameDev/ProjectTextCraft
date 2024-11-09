using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
The purpose of this script is to store all entities within a dictionary.
Each entity is stored with key = entity name and value = entity object.
This script builds dictionary of entity data at run time.
Allows the program to retrieve the entity object with return method.
Entity object should be transferred to UI object for in-game interactions.
*/

public class EntityData
{
    Dictionary<string, NPCData> npcDictionary = new Dictionary<string, NPCData>();
    Dictionary<string, ItemData> itemsDictionary = new Dictionary<string, ItemData>();
    Dictionary<string, EnvironmentData> environmentDictionary = new Dictionary<string, EnvironmentData>();

}
