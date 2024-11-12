using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/*
Stores dictionaries of all NPC data.
Items in droptable and equipment are split by "/" when instantiating NPC entity. Upon death, all equipment is lootable by the player.
Items in drop table are randomly chosen to be looted by the player based on probability, and is noted by %numb next to the item's name.
    When choosing an item to give to player, a random float is generated between 0 and 1. The item with the next probability above the
    random float is given. Example: a 0.32 roll will give an item that has 0.4 probability if no other item probabilities exist between 0.32 and 0.4.
    
*/

public class NPCData
{

    public Dictionary<string, Dictionary<string, string>> NPCDict = new Dictionary<string, Dictionary<string, string>>()
    {
        {"Goblin",
            new Dictionary<string, string>()
            {
                {"EntityName", "Goblin"},
                {"EntityRace", "Goblin"},
                {"Constitution", "5"},
                {"Strength", "5"},
                {"Dexterity", "5"},
                {"Intelligence", "5"},
                {"Wisdom", "5"},
                {"Charisma", "5"},
                {"DropTable", ""},
                {"Equipment", "Leather Leggings/Leather Shoulders/Leather Boots/Bronze Scimitar"},
                {"AttackMessage", "The goblin grunts in agony."},
                {"ListenMessage", "The goblin mumbles something in its' own language. You can't understand it."},
                {"InspectMessage", "A small green creature with pointy ears. It's wearing leather pants, boots, and shoulder pads. In its' hand it maintains a firm grip on a bronze scimitar."},
                {"GatherMessage", "Though small, the goblin isn't going to fit in your pack."},
                {"LootMessage", "You can't loot the goblin while it's still alive."},
                {"DeadAttackMessage", "The goblin is already dead. Attacking it won't accomplish anything."},
                {"DeadListenMessage", "You listen to the dead goblin, but you don't hear anything"},
                {"DeadInspectMessage", "A small green creature clearly deceased."},
                {"DeadGatherMessage", "Though small, the goblin isn't going to fit in your pack."},
                {"DeadLootMessage", "You rummage the Goblin's corpse and salvage any remaining items."}
            }
        }
    };

}
