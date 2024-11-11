using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Base stats and information for items to be used to create items in game.
*/

[CreateAssetMenu(fileName ="Item Data" ,menuName ="Data/Item Data")]
public class ItemData : ScriptableObject
{
    
    public enum entTypes {MATERIAL, CONSUMABLE, EQUIPABLE, KEY}
    public enum equipableSlot {NONE, HEAD, SHOULDERS, CHEST, WRIST, HANDS, WAIST, LEGS, FEET, MAINHAND, OFFHAND, FINGER, NECK}

    public string entityName;
    public entTypes entityType;
    public equipableSlot entitySlot;
    public float weight_kg;

    public Dictionary<string, int> itemModifiers = new Dictionary<string, int>() 
    {
        {"Armor", 0},
        {"Strength", 0},
        {"Dexterity", 0},
        {"Constitution", 0},
        {"Intelligence", 0},
        {"Charisma", 0}
    };

    public int ATKDiceNumber;
    
    
    public string[] attackMessages;
    public string[] listenMessages;
    public string[] inspectMessages;
    public string[] gatherMessages;
    public string[] lootMessages;

    public int GetDiceQuantity()
    {
        return ATKDiceNumber;
    }

    public int GetArmorQuantity()
    {
        return itemModifiers["Armor"];
    }

    public string GetGatherMessage()
    {
        int randomChoice = UnityEngine.Random.Range(0, gatherMessages.Length-1);
        return gatherMessages[randomChoice];
    }

    public string GetInspectMessage()
    {
        int randomChoice = UnityEngine.Random.Range(0, inspectMessages.Length-1);
        return inspectMessages[randomChoice];
    }

    public string GetListenMessage()
    {
        int randomChoice = UnityEngine.Random.Range(0, listenMessages.Length-1);
        return listenMessages[randomChoice];
    }

    public string GetAttackMessage()
    {
        int randomChoice = UnityEngine.Random.Range(0, attackMessages.Length-1);
        return attackMessages[randomChoice];
    }
}
