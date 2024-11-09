using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Handles player data set at character creation as well as dynamic stats that change
    with progression.
Methods will allow main game to retrieve and update dynamic player data for resolving
    actions in game.
*/
public class PlayerData
{
    string playerName;
    string playerRace; //Change to enums for character creator
    int playerAge;

    //Change to enums for character creator
    string playerSex;

    //Change to enums for character creator
    string playerSkinTone;
    string playerHairColor;
    string playerHairType;
    string playerEyeColor;
    string playerFacialHair;


    //Base stats
    int playerConstitution;
    int playerStrength;
    int playerDexterity;
    int playerIntelligence;
    int playerWisdom;
    int playerCharisma;

    //Dynamic stats
    int playerMaxHealth;
    int playerCurrentHealth;
    int playerMana;
    int playerMeleeDamage;
    int playerRangeDamage;
    int playerMagicDamage;
    int playerArmor;
    int playerHunger = 100;
    int playerThirst = 100;
    int playerSanity = 100;
    float maxCarryWeight;

    //Dynamic progression
    float playerMorality = 0.5f;
    string[] playerAchievements;

    public PlayerData(string pName, int pConstitution, int pStrength, int pDexterity, int pIntelligence, int pWisdom, int pCharisma)
    {
        playerName = pName;
        playerConstitution = pConstitution;
        playerStrength = pStrength;
        playerDexterity = pDexterity;
        playerIntelligence = pIntelligence;
        playerWisdom = pWisdom;
        playerCharisma = pCharisma;

        UpdateDynamicStats();
    }

#region methods to update dynamic stats
    public void UpdateDynamicStats()
    {
        //Get base stats at character creation in world

        CalculateHealth();
        CalculateMeleeDamage();
        CalculateRangedDamage();
        CalculateMagicDamage();
        CalculateMana();
        CalculateCarryWeight();
    }

    public void UpdateDynamicStats(EquipmentData equipment)
    {
        //Update stats based on inventory
    }

    void CalculateHealth()
    {
        //Player starts at a base HP determined by class.
        //For each point in constituion add 2hp to the player.
        //Will need to add methods in future to get const modifiers from inventory

        int baseHP = 25;
        playerMaxHealth = baseHP + (playerConstitution * 2);
        playerCurrentHealth = playerMaxHealth;
    }

    void CalculateMeleeDamage()
    {
        //Player starts with a base damage determined by race.
        //For each point in strength add 2 melee damage to the player.
        //Will need to add methods in future to get str modifiers from inventory

        int baseDMG = 3;
        playerMeleeDamage = baseDMG + (playerStrength * 1);
    }

    void CalculateRangedDamage()
    {
        //Player starts with a base ranged damage determined by race.
        //For each point in dexterity add 2 range damage to the player.
        //Will need to add methods in the future to get dex modifiers from inventory.

        int baseDMG = 3;
        playerRangeDamage = baseDMG + (playerDexterity * 1);
    }

    void CalculateMagicDamage()
    {
        //Player starts with a base magic damage determined by race.
        //For each point in intelligence add 2 magic damage to the player.
        //Will need to add methods in the future to get int modifiers from inventory.

        int baseDMG = 3;
        playerMagicDamage = baseDMG + (playerIntelligence * 1);
    }

    void CalculateMana()
    {
        //Player starts with base mana determined by race.
        //For each point in wisdom add 2 mana to the player.
        //Will need to add methods in the future to get wis modifiers from inventory.

        int baseMana = 5;
        playerMana = baseMana + (playerWisdom * 1);
    }

    void CalculateCarryWeight()
    {
        //Player starts with base carry weight determined by race.
        //For each point in strength add a KG to carry weight.
        //Will need to add methods in future to get str modifiers from inventory.

        float baseCarryWeight = 25f;
        maxCarryWeight = baseCarryWeight + playerStrength;
    }

#endregion

#region Combat Methods

    public int[] ResolveDamage(int dmg)
    {
        playerCurrentHealth -= dmg;
        int[] playerHealthStats = new int[] {playerCurrentHealth, playerMaxHealth};
        return playerHealthStats;
    }

    public int GetMeleeDamage()
    {
        Debug.Log("Getting player melee damage");
        return playerMeleeDamage;
    }

    public int GetRangeDamage()
    {
        return playerRangeDamage;
    }

    public int GetMagicDamage()
    {
        return playerMagicDamage;
    }

    public void RespawnPlayer()
    {
        playerCurrentHealth = playerMaxHealth;
    }

#endregion

#region player getter methods
    public string GetPlayerName()
    {
        return playerName;
    }
#endregion

#region player setter methods

#endregion

}
