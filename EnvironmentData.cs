using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Dictionary of all environment objects for world generation, such as trees, ores, water sources, etc.
Drop Table contains items that will be randomly spawned when harvesting item.
    String will be split at "/" so string can contain multiple items.
    Drop chance is represented by %numb. A random generator that generates a float from 0 to 1 will
    be used in game and spawn the object with spawn chance number just above the generated float.
Inventory items will be dropped after harvesting with 100% probability for each item. Items are split at "/"
*/

public class EnvironmentData
{
    public Dictionary<string, Dictionary<string, string>> EnvironmentDict = new Dictionary<string, Dictionary<string, string>>()
    {
        {"Oak Tree", 
            new Dictionary<string, string>() {
                {"EntityName", "Oak Tree"},
                {"EntityType", "Tree"},
                {"Drop Table", "Oak Log"},
                {"Inventory", "Stick%0.5/Acorn%1"},
                {"AttackMessage", "You attack the oak tree, but nothing happens."},
                {"ListenMessage", "You listen to the oak tree. The leaves rustle gently in the breeze."},
                {"InspectMessage", "A tall tree grown from an acorn. The bark is dark brown, rough, and full of imperfections. Leaves fill the canopy above providing shade to the ground below."},
                {"GatherMessage", "With a swift leap into the air you manage to grab a tree branch and yank it down."},
                {"LootMessage", "With a swift leap into the air you manage to grab a tree branch and yank it down."}
            }
        }
    };
}
