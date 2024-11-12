using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
Base stats and information for items to be used to create item entities in game.
*/

public class ItemData
{
    public Dictionary<string, Dictionary<string, string>> itemDictionary = new Dictionary<string, Dictionary<string, string>>()
    {

#region MATERIALS
        {"Acorn", 
            new Dictionary<string, string>() {
                {"EntityName", "Acorn"},
                {"EntityType", "Material"},
                {"EquipableSlot", "None"},
                {"Weight_KG", "0.01"},
                {"Armor", "0"},
                {"Strength", "0"},
                {"Dexterity", "0"},
                {"Constitution", "0"},
                {"Intelligence", "0"},
                {"Charisma", "0"},
                {"DiceAmount", "0"},
                {"AttackMessage", "You attack the acorn, but it doesn't do anything."},
                {"ListenMessage", "You tap on the acorn gently. It sounds slightly hollow."},
                {"InspectMessage", "The acorn is small and slightly rounded with a rough top where it once hung from a tree. Light brown in color, the acorn blends in with it's natural environment."},
                {"GatherMessage", "You gather an acorn."},
                {"LootMessage", ""}
            }},
        {"Oak Log", new Dictionary<string, string>() {
                {"EntityName", "Oak Log"},
                {"EntityType", "Material"},
                {"EquipableSlot", "None"},
                {"Weight_KG", "2.5"},
                {"Armor", "0"},
                {"Strength", "0"},
                {"Dexterity", "0"},
                {"Constitution", "0"},
                {"Intelligence", "0"},
                {"Charisma", "0"},
                {"DiceAmount", "0"},
                {"AttackMessage", "You attack an oak log, but nothing happens."},
                {"ListenMessage", "You tap on an oak log. A deep thud echoes through the air."},
                {"InspectMessage", "A piece of an oak tree cut to a portable size."},
                {"GatherMessage", "You gather a small log cut from an oak tree."},
                {"LootMessage", ""}
        }},
        {"Stick", new Dictionary<string, string>() {
                {"EntityName", "Stick"},
                {"EntityType", "Material"},
                {"EquipableSlot", "None"},
                {"Weight_KG", "0.5"},
                {"Armor", "0"},
                {"Strength", "0"},
                {"Dexterity", "0"},
                {"Constitution", "0"},
                {"Intelligence", "0"},
                {"Charisma", "0"},
                {"DiceAmount", "0"},
                {"AttackMessage", "You attack the stick, but nothing happens."},
                {"ListenMessage", "You tap on the stick. A light thud resonates through the air."},
                {"InspectMessage", "A rough, small piece of a tree. Long and skinny, and just big enough to be useful."},
                {"GatherMessage", "You gather a stick. Rough and imperfect, but large enough to make use of."},
                {"LootMessage", ""}
        }},
#endregion

#region EQUIPABLE

#region leather
        {"Leather Belt", new Dictionary<string, string>() {
                {"EntityName", "Leather Belt"},
                {"EntityType", "Equipable"},
                {"EquipableSlot", "Waist"},
                {"Weight_KG", "1"},
                {"Armor", "1"},
                {"Strength", "0"},
                {"Dexterity", "0"},
                {"Constitution", "0"},
                {"Intelligence", "0"},
                {"Charisma", "0"},
                {"DiceAmount", "0"},
                {"AttackMessage", "You attack the leather belt, but nothing happens."},
                {"ListenMessage", "You tap on the leather belt. A dull sound fills the air."},
                {"InspectMessage", "A crude belt made of warn leather. It provides little protection to the wearer."},
                {"GatherMessage", "You pick up the leather belt."},
                {"LootMessage", "You pick up the leather belt."}
        }},
        {"Leather Boots", new Dictionary<string, string>() {
                {"EntityName", "Leather Boots"},
                {"EntityType", "Equipable"},
                {"EquipableSlot", "Feet"},
                {"Weight_KG", "2"},
                {"Armor", "1"},
                {"Strength", "0"},
                {"Dexterity", "0"},
                {"Constitution", "0"},
                {"Intelligence", "0"},
                {"Charisma", "0"},
                {"DiceAmount", "0"},
                {"AttackMessage", "You attack the leather boots, but nothing happens."},
                {"ListenMessage", "You tap on the leather boots, a dull sound fills the air."},
                {"InspectMessage", "Crude boots made from worn leather. It provides some protection to the wearer."},
                {"GatherMessage", "You pick up the leather boots."},
                {"LootMessage", "You pick up the leather boots."}
        }},
        {"Leather Bracers", new Dictionary<string, string>() {
                {"EntityName", "Leather Bracers"},
                {"EntityType", "Equipable"},
                {"EquipableSlot", "Wrist"},
                {"Weight_KG", "1"},
                {"Armor", "1"},
                {"Strength", "0"},
                {"Dexterity", "0"},
                {"Constitution", "0"},
                {"Intelligence", "0"},
                {"Charisma", "0"},
                {"DiceAmount", "0"},
                {"AttackMessage", "You attack the leather bracers, but nothing happens."},
                {"ListenMessage", "You tap on the leather bracers, a faint sound fills the air."},
                {"InspectMessage", "A crude set of bracers. They provide a little protection to the wearer."},
                {"GatherMessage", "You pick up a pair of leather bracers."},
                {"LootMessage", "You pick up a pair of leather bracers."}
        }},
        {"Leather Chest", new Dictionary<string, string>() {
                {"EntityName", "Leather Chest"},
                {"EntityType", "Equipable"},
                {"EquipableSlot", "Chest"},
                {"Weight_KG", "3"},
                {"Armor", "2"},
                {"Strength", "0"},
                {"Dexterity", "0"},
                {"Constitution", "0"},
                {"Intelligence", "0"},
                {"Charisma", "0"},
                {"DiceAmount", "0"},
                {"AttackMessage", "You attack the leather chest, but nothing happens."},
                {"ListenMessage", "You tap on the leather chest, a dull sound fills the air."},
                {"InspectMessage", "A crude chest piece made of worn leather. It provides a little protection to the wearer."},
                {"GatherMessage", "You pick up the leather chest."},
                {"LootMessage", "You pick up the leather chest."}
        }},
        {"Leather Gloves", new Dictionary<string, string>() {
                {"EntityName", "Leather Gloves"},
                {"EntityType", "Equipable"},
                {"EquipableSlot", "Hands"},
                {"Weight_KG", "1"},
                {"Armor", "1"},
                {"Strength", "0"},
                {"Dexterity", "0"},
                {"Constitution", "0"},
                {"Intelligence", "0"},
                {"Charisma", "0"},
                {"DiceAmount", "0"},
                {"AttackMessage", "You attack the leather gloves, but nothing happens."},
                {"ListenMessage", "You tap on the leather gloves. A dull sound fills the air."},
                {"InspectMessage", "A crude pair of leather gloves made of worn leather. It provides a little protection to the wearer."},
                {"GatherMessage", "You pick up the leather gloves."},
                {"LootMessage", "You pick up the leather gloves."}
        }},
        {"Leather Helmet", new Dictionary<string, string>() {
                {"EntityName", "Leather Helmet"},
                {"EntityType", "Equipable"},
                {"EquipableSlot", "Head"},
                {"Weight_KG", "2"},
                {"Armor", "1"},
                {"Strength", "0"},
                {"Dexterity", "0"},
                {"Constitution", "0"},
                {"Intelligence", "0"},
                {"Charisma", "0"},
                {"DiceAmount", "0"},
                {"AttackMessage", "You attack the leather helmet, but nothing happens."},
                {"ListenMessage", "You tap on the leather helmet. A dull sound echoes through the air."},
                {"InspectMessage", "A crude helmet made from leather."},
                {"GatherMessage", "You obtain the leather helmet."},
                {"LootMessage", "You obtain the leather helmet."}
        }},
        {"Leather Leggings", new Dictionary<string, string>() {
                {"EntityName", "Leather Leggings"},
                {"EntityType", "Equipable"},
                {"EquipableSlot", "Legs"},
                {"Weight_KG", "3"},
                {"Armor", "2"},
                {"Strength", "0"},
                {"Dexterity", "0"},
                {"Constitution", "0"},
                {"Intelligence", "0"},
                {"Charisma", "0"},
                {"DiceAmount", "0"},
                {"AttackMessage", "You attack the leather leggings, but nothing happens."},
                {"ListenMessage", "You tap on the leather leggings. A dull sound fills the air."},
                {"InspectMessage", "A crude pair of leggings made from worn leather. It provides a little protection to the wearer."},
                {"GatherMessage", "You pick up the leather leggings."},
                {"LootMessage", "You pick up the leather leggings."}
        }},
        {"Leather Shoulders", new Dictionary<string, string>() {
                {"EntityName", "Leather Shoulders"},
                {"EntityType", "Equipable"},
                {"EquipableSlot", "Shoulders"},
                {"Weight_KG", "2"},
                {"Armor", "1"},
                {"Strength", "0"},
                {"Dexterity", "0"},
                {"Constitution", "0"},
                {"Intelligence", "0"},
                {"Charisma", "0"},
                {"DiceAmount", "0"},
                {"AttackMessage", "You attack the leather shoulder pads, but nothing happens."},
                {"ListenMessage", "You tap on the leather shoulder pads. A dull sound fills the air."},
                {"InspectMessage", "A pair of shoulder pads made of crude leather. It provides a little protection to the wearer."},
                {"GatherMessage", "You pick up the leather shoulders."},
                {"LootMessage", "You pick up the leather shoulders."}
        }},



#endregion

#region bronze

        {"Bronze Scimitar", new Dictionary<string, string>() {
                {"EntityName", "Bronze Scimitar"},
                {"EntityType", "Equipable"},
                {"EquipableSlot", "MainHand"},
                {"Weight_KG", "4"},
                {"Armor", "0"},
                {"Strength", "0"},
                {"Dexterity", "0"},
                {"Constitution", "0"},
                {"Intelligence", "0"},
                {"Charisma", "0"},
                {"DiceAmount", "2"},
                {"AttackMessage", "You attack the bronze scimitar, but nothing happens."},
                {"ListenMessage", "You tap on the bronze scimitar. The high pitch clink vibrates off the metal."},
                {"InspectMessage", "A crude scimitar made of cheap metal."},
                {"GatherMessage", "You take up the bronze scimitar."},
                {"LootMessage", "You take up the bronze scimitar."}
        }},
#endregion

#endregion

    };

}