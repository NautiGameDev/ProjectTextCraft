using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

/*
This script is responsible for handling player input in a behavior tree,
building a string to be posted to GUI, and returning string to textHandler for
post.
*/
public class ActionHandler : MonoBehaviour
{
    public World world;
    public Player player;

    string previousBiomeDescribed;

    public string GetInputAction(string[] parsedInput)
    {
        string newMessage = "";

        switch (parsedInput[0])
        {

    #region Movement
            case "move":
                if (parsedInput.Length <= 1)
                    newMessage += "Where would you like to move? Type move [direction] to move in any direction.";
                else         
                    newMessage += Action_TravelMoveGo(parsedInput[1]);
                break;
            case "travel":
                if (parsedInput.Length <= 1)
                    newMessage += "Where would you like to travel? Type travel [direction] to travel in any direction.";
                else         
                    newMessage += Action_TravelMoveGo(parsedInput[1]);
                break;
            case "go":
                if (parsedInput.Length <= 1)
                    newMessage += "Where would you like to go? Type go [direction] to travel in any direction.";
                else         
                    newMessage += Action_TravelMoveGo(parsedInput[1]);
                break;
            case "n":
                newMessage += newMessage += Action_TravelMoveGo(parsedInput[0]);
                break;
            case "e":
                newMessage += newMessage += Action_TravelMoveGo(parsedInput[0]);
                break;
            case "s":
                newMessage += newMessage += Action_TravelMoveGo(parsedInput[0]);
                break;
            case "w":
                newMessage += newMessage += Action_TravelMoveGo(parsedInput[0]);
                break;
            case "sw":
                newMessage += newMessage += Action_TravelMoveGo(parsedInput[0]);
                break;
            case "se":
                newMessage += newMessage += Action_TravelMoveGo(parsedInput[0]);
                break;
            case "nw":
                newMessage += newMessage += Action_TravelMoveGo(parsedInput[0]);
                break;
            case "ne":
                newMessage += newMessage += Action_TravelMoveGo(parsedInput[0]);
                break;
    #endregion

    #region Gathering
            case "harvest":
                newMessage += Process_HarvestGather(parsedInput);
                break;

            case "gather":
                newMessage += Process_HarvestGather(parsedInput);
                break;

            case "g":
                newMessage += Process_HarvestGather(parsedInput);
                break;

            case "get":
                newMessage += Process_HarvestGather(parsedInput);
                break;

            case "take":
                newMessage += Process_HarvestGather(parsedInput);
                break;

            case "loot":
                newMessage += Process_Loot(parsedInput);
                break;

    #endregion

    #region Inspection
            case "look":
                newMessage += Process_InspectLookExamine(parsedInput);
                break;

            case "l":
                newMessage += Process_InspectLookExamine(parsedInput);
                break;

            case "inspect":
                newMessage += Process_InspectLookExamine(parsedInput);
                break;

            case "examine":
                newMessage += Process_InspectLookExamine(parsedInput);
                break;

            case "listen":
                newMessage += Process_Listen(parsedInput);
                break;
    #endregion

    #region Combat

            case "attack":
                newMessage += Process_AttackKill(parsedInput);
                break;
            case "a":
                newMessage += Process_AttackKill(parsedInput);
                break;
            case "kill":
                newMessage += Process_AttackKill(parsedInput);
                break;

    #endregion

    #region Inventory

            case "inventory":
                newMessage += player.GetInventory();
                break;

            case "inv":
                newMessage += player.GetInventory();
                break;

            case "i":
                newMessage += player.GetInventory();
                break;

            case "equipment":
                newMessage += player.GetEquippedItems();
                break;
            
            case "eq":
                if (parsedInput.Length == 1)
                    newMessage += player.GetEquippedItems();
                else if (parsedInput.Length > 1)
                    newMessage += Process_EquipWear(parsedInput);

                break;

            case "drop":

                break;

    #endregion

    #region equipment management
            case "equip":
                newMessage += Process_EquipWear(parsedInput);
                break;

            case "wear":
                newMessage += Process_EquipWear(parsedInput);
                break;

            case "unequip":
                newMessage += Process_Unequip(parsedInput);
                break;

    #endregion

        }

        return newMessage;
    }

#region Process Command Target
    string Process_HarvestGather(string[] parsedInput)
    {
        string appendedMessage = "";
        //Checks if player has entered at least two parameters
        if (parsedInput.Length > 1)
        {
            string target = "";
            //Checks if player has entered at least three parameters
            if (parsedInput.Length >= 3)
            {
                target+= parsedInput[1] + " " + parsedInput[2];   
            }
            else
            {
                target += parsedInput[1];    
            }

            try
            {
                appendedMessage += Action_GatherHarvest(target);
            }
            catch
            {
                appendedMessage += target + " doesn't seem to exist in your vicinity.";
            }
        }
        else
        {
            appendedMessage += parsedInput[0] + " what?";
        }

        return appendedMessage;
    }

    string Process_InspectLookExamine(string[] parsedInput)
    {
        string target = "";
        string appendedMessage = "";
        if (parsedInput.Length > 1)
        {
            if (parsedInput.Length >= 3)
            {
                target += parsedInput[1] + " " + parsedInput[2];
            }
            else
            {
                target += parsedInput[1];
            }

            try
            {
                appendedMessage += Action_LookInspectExamine(target);
            }
            catch
            {
                appendedMessage += target + " doesn't seem to exist in your vicinity.";
            }
        }
        else
        {
            appendedMessage += parsedInput[0] + " what?";
        }

        return appendedMessage;
    }

    string Process_Listen(string[] parsedInput)
    {
        string target = "";
        string appendedMessage = "";
        if (parsedInput.Length > 1)
        {
            if (parsedInput.Length >= 3)
            {
                target += parsedInput[1] + " " + parsedInput[2];
            }
            else
            {
                target += parsedInput[1];
            }

            try
            {
                appendedMessage += Action_Listen(target);
            }
            catch
            {
                appendedMessage += target + " doesn't seem to exist in your vicinity.";
            }
        }
        else
        {
            appendedMessage += parsedInput[0] + " to what?";
        }

        return appendedMessage;
    }

    string Process_AttackKill(string[] parsedInput)
    {
        string target = "";
        string appendedMessage = "";
        if (parsedInput.Length > 1)
        {
            if (parsedInput.Length >= 3)
            {
                target += parsedInput[1] + " " + parsedInput[2];
            }
            else
            {
                target += parsedInput[1];
            }

            try
            {
                appendedMessage += Action_AttackKill(target);
            }
            catch
            {
                appendedMessage += target + " doesn't seem to exist in your vicinity.";
            }
        }
        else
        {
            appendedMessage += parsedInput[0] + " what?";
        }

        return appendedMessage;
    }

    string Process_EquipWear(string[] parsedInput)
    {
        string target="";
        string amendedMessage = "";

        if (parsedInput.Length >= 3)
        {
            target += parsedInput[1] + " " + parsedInput[2];
            amendedMessage += Action_EquipWear(target);
        }
        else if (parsedInput.Length == 2)
        {
            target += parsedInput[1];
            amendedMessage += Action_EquipWear(target);
        }
        else if (parsedInput.Length == 1)
        {
            amendedMessage += parsedInput[0] + " what?";
        }


        return amendedMessage;
    }

    string Process_Unequip(string[] parsedInput)
    {
        string messageToReturn = "";

       if (parsedInput.Length == 1)
       {
            messageToReturn += parsedInput[0] + " what?";
       }

       else if (parsedInput.Length >= 2)
       {
            string target = parsedInput[1] + " " + parsedInput[2];
            messageToReturn += Action_Unequip(target);
       }


        return messageToReturn;
    }

    string Process_Loot(string[] parsedInput)
    {
        string amendedMessage = "";
        string target = "";

        if (parsedInput.Length >= 3)
        {
            target += parsedInput[1] + " " + parsedInput[2];
            amendedMessage += Action_Loot(target);
        }
        else if (parsedInput.Length == 2)
        {
            target += parsedInput[1] + " corpse";
            amendedMessage += Action_Loot(target);
        }
        else if (parsedInput.Length == 1)
        {
            amendedMessage += parsedInput[0] + " what?";
        }

        return amendedMessage;
    }

#endregion

#region Process Actions
    string Action_TravelMoveGo(string actionInput)
    {
        string actionResponse = "\n";

        if (actionInput == "north" || actionInput == "n")
            {
                actionResponse += "You travel north ";
                world.UpdatePosition(Vector2Int.up);
            }
        else if (actionInput == "east" || actionInput == "e")
            {  
                actionResponse += "You travel east ";
                world.UpdatePosition(Vector2Int.right); 
            }
        else if (actionInput == "west" || actionInput == "w")
            { 
                actionResponse += "You travel west ";
                world.UpdatePosition(Vector2Int.left);
            }
        else if (actionInput == "south" || actionInput == "s")
            { 
                actionResponse += "You travel south ";
                world.UpdatePosition(Vector2Int.down); 
            }
        else if (actionInput == "southwest" || actionInput == "sw")
            {
                actionResponse += "You travel southwest ";
                world.UpdatePosition(new Vector2Int(-1, -1));
            }
        else if (actionInput == "southEast" || actionInput == "se")
            {
                actionResponse += "You travel southeast ";
                world.UpdatePosition(new Vector2Int(1, -1));
            }

        else if (actionInput == "northEast" || actionInput == "ne")
            {
                actionResponse += "You travel northeast ";
                world.UpdatePosition(new Vector2Int(1, 1));
            }
        else if (actionInput == "northWest" || actionInput == "nw")
            {
                actionResponse += "You travel northwest ";
                world.UpdatePosition(new Vector2Int(-1, 1));
            }


        ChunkData currentChunk = world.GetChunkAtWorldCoords();

        if (currentChunk.biome != previousBiomeDescribed)
        {
            previousBiomeDescribed = currentChunk.biome;
            actionResponse += "into the " + currentChunk.biome + ". " + currentChunk.GetRandomDescription();
        }

        return actionResponse;
    }

    string Action_GatherHarvest(string target)
    {
        //Perform checks to see if target exists within current chunk.
        //If true, build and return strings.
        //If false, return string saying target cannot be found.


        ChunkData currentChunk = world.GetChunkAtWorldCoords();
        string messageToReturn = "";

        EnvironmentData environmentObj = GetEnvironmentObj(target, currentChunk);
        
        //Check if target exists in current chunk
        if (environmentObj != null)
        {
            messageToReturn += environmentObj.GetGatherMessage();
            ItemData lootedItem = environmentObj.GetItemFromInventory(); //Returns random ItemData from inventory array
            messageToReturn += lootedItem.GetGatherMessage();
            messageToReturn += player.AddItemToInventory(lootedItem);
            return messageToReturn;

        }

        ItemData item = GetItemInWorld(target, currentChunk);

        if (item != null)
        {
            messageToReturn += item.GetGatherMessage();
            messageToReturn += player.AddItemToInventory(item);
            world.RemoveItemFromChunk(item);
            return messageToReturn;

        }

        NPCData npc = GetNPC(target, currentChunk);

        if (npc != null)
        {
            messageToReturn += npc.GetGatherMessage();
            //Add some logic here for using gather/harvest on NPCs?
            return messageToReturn;
        }

        messageToReturn += "There doesn't seem to be a " + target + " in the area.";
        return messageToReturn;
    }

    string Action_LookInspectExamine(string target)
    {
        //Perform check if target object exists in current chunk and inventory
        //If object exists, return random message from array of strings in object
        //If null, return message stating object cannot be found
        
        string messageToReturn = "";

        ChunkData currentChunk = world.GetChunkAtWorldCoords();

        EnvironmentData environmentObj = GetEnvironmentObj(target, currentChunk);

        if (environmentObj != null)
        {
            messageToReturn += environmentObj.GetInspectMessage();
            return messageToReturn;
        }

        ItemData itemInChunk = GetItemInWorld(target, currentChunk);

        if (itemInChunk != null)
        {
            messageToReturn += itemInChunk.GetInspectMessage();
            return messageToReturn;
        }

        NPCData npc = GetNPC(target, currentChunk);
        
        if (npc != null)
        {
            messageToReturn += npc.GetInspectMessage();
            return messageToReturn;
        }

        ItemData itemInInventory = GetItemInInventory(target);

        if (itemInInventory != null)
        {
            messageToReturn += itemInInventory.GetInspectMessage();
            return messageToReturn;
        }

        ItemData itemInEquipment = GetItemInEquipment(target);


        messageToReturn += "There doesn't seem to be a " + target + " in the area.";
        return messageToReturn = "";
    }

    string Action_Listen(string target)
    {
        //Perform check if target object exists in current chunk and inventory
        //If object exists, return random message from array of strings in object
        //If null, return message stating object cannot be found
        
        string messageToReturn = "";

        ChunkData currentChunk = world.GetChunkAtWorldCoords();

        EnvironmentData environmentObj = GetEnvironmentObj(target, currentChunk);

        if (environmentObj != null)
        {
            messageToReturn += environmentObj.GetListenMessage();
            return messageToReturn;
        }

        ItemData itemInChunk = GetItemInWorld(target, currentChunk);

        if (itemInChunk != null)
        {
            messageToReturn += itemInChunk.GetListenMessage();
            return messageToReturn;
        }

        NPCData npc = GetNPC(target, currentChunk);
        
        if (npc != null)
        {
            messageToReturn += npc.GetListenMessage();
            return messageToReturn;
        }

        ItemData itemInInventory = GetItemInInventory(target);

        if (itemInInventory != null)
        {
            messageToReturn += itemInInventory.GetListenMessage();
            return messageToReturn;
        }

        messageToReturn += "There doesn't seem to be a " + target + " in the area.";
        return messageToReturn = "";
    }

    string Action_AttackKill(string target)
    {
        string messageToReturn = "";

        ChunkData currentChunk = world.GetChunkAtWorldCoords();

        EnvironmentData environmentObj = GetEnvironmentObj(target, currentChunk);

        if (environmentObj != null)
        {
            Debug.Log(target + " found in chunk. Getting attack message.");
            messageToReturn += environmentObj.GetAttackMessage();
            return messageToReturn;
        }

        ItemData itemInChunk = GetItemInWorld(target, currentChunk);

        if (itemInChunk != null)
        {
            Debug.Log(target + " found in chunk. Getting attack message.");
            messageToReturn += itemInChunk.GetAttackMessage();
            return messageToReturn;
        }

        NPCData npc = GetNPC(target, currentChunk);
        
        if (npc != null)
        {
            if (npc.currentState == NPCData.NPCState.ALIVE)
            {
                
                
                //Resolve player damage against NPC and append message
                ItemData playerWeapon = player.GetEquippedItemInSlot("mainHand");
                ItemData playerOffhand = player.GetEquippedItemInSlot("offHand");
                
                int rollDmg = 0;
                int numbOfRolls = 0;

                if (playerWeapon != null)
                {
                    numbOfRolls += playerWeapon.ATKDiceNumber;   
                }

                if (playerOffhand != null)
                {
                    numbOfRolls = playerOffhand.ATKDiceNumber;
                }

                rollDmg += RollWeaponDamage(numbOfRolls);
                int baseDmg = player.GetDamage();

                int damage = rollDmg +  baseDmg;
                int[] npcHealth = npc.ResolveDamage(damage);
                messageToReturn += "You attack the " + npc.entityName + " and deal " + (damage-npc.GetArmorStat()) + " damage.\n{Roll Damage[" + numbOfRolls + "d12]: " + rollDmg + "} + {Base Damage: " + baseDmg + "} - {Damage Blocked: " + npc.GetArmorStat() + "}\n\n";
                
                //If NPC is alive: Append attack string, get damage from NPC, append NPC attacking string, resolve damage against player.
                //If NPC has died: Append string message describing NPC death

                messageToReturn += npc.GetAttackMessage();
                int[] playerHealth = new int[] {100, 100};

                if (npcHealth[0] > 0)
                {
                    int playerArmor = player.GetArmorStat();
                    int npcDiceCount = npc.GetWeaponDice();
                    int npcRollDmg = RollWeaponDamage(npcDiceCount);
                    int npcBaseDmg = npc.GetMeleeDamage();
                    int npcDamage = npcRollDmg + npcBaseDmg - playerArmor;

                    messageToReturn += npc.entityName + " retaliates against you and hits you for " + npcDamage + ".\n{Roll Damage[" + npcDiceCount + "d12]: " + npcRollDmg + "} + {Base Damage: " + npcBaseDmg +"} - {Damage Blocked: " + playerArmor + ")\n";
                    playerHealth = player.ResolveDamage(npcDamage);
                }
                else
                {
                    messageToReturn += "\nIt dies with a final breath, and its' lifeless corpse falls to the ground.";
                    world.RemoveNPCFromChunk(npc);
                    world.AddNPCToChunk(npc.corpseObj);
                    playerHealth = player.ResolveDamage(0);
                }

                //Player death logic
                if (playerHealth[0] < 0)
                {
                    messageToReturn += "\nThe pain is too much to take. You have been deceased.";
                    player.RespawnPlayer();
                    messageToReturn += "You respawn at your last saved respawn point.";

                }
                else {
                    messageToReturn += "\nYour health: " + playerHealth[0] + "/" + playerHealth[1];
                    messageToReturn += "\n" + npc.entityName + "'s health: " + npcHealth[0] + "/" + npcHealth[1];
                }
            }

            else
            {
                messageToReturn += target + " is already dead.";
            }

            return messageToReturn;
        }

        ItemData itemInInventory = GetItemInInventory(target);

        if (itemInInventory != null)
        {
            messageToReturn += itemInInventory.GetAttackMessage();
            return messageToReturn;
        }

        messageToReturn += "There doesn't seem to be a " + target + " in the area.";

        return messageToReturn;
    }

    string Action_Loot(string target)
    {
        string messageToReturn = "";

        ChunkData chunk = world.GetChunkAtWorldCoords();

        NPCData npc = GetNPC(target, chunk);

        if (npc != null)
        {
            if (npc.currentState == NPCData.NPCState.DEAD)
            {
                Debug.Log("Loot Target: " + target);

                messageToReturn += npc.GetLootMessage();
                List<ItemData> lootedItems = npc.GetRandomLoot();

                foreach (ItemData item in lootedItems)
                {
                    messageToReturn += "\n" + player.AddItemToInventory(item);
                }

                world.RemoveNPCFromChunk(npc);
            }
            else
            {
                messageToReturn += target + " is still alive. You can't loot it right now.";
            }
        }
        else
        {
            string[] targetArray = target.Split(" ");
            if (targetArray[1] == "corpse") target = targetArray[0];
            messageToReturn += "There isn't a " + target + " in the area.";
        }

        return messageToReturn;
    }

    string Action_EquipWear(string target)
    {
        string messageToReturn = "";


        ItemData itemInInventory = player.GetItemFromInventory(target);

        if (itemInInventory != null && itemInInventory.entityType == ItemData.entTypes.EQUIPABLE)
        {
            messageToReturn += player.EquipItem(itemInInventory);
            player.RemoveItemFromInventory(target);
        }
        else if (itemInInventory != null && itemInInventory.entityType != ItemData.entTypes.EQUIPABLE)
        {
            messageToReturn += target + " cannot be equipped.";
        }
        else
        {
            messageToReturn += target + " isn't in your inventory.";
        }

        Debug.Log("Equip: " + messageToReturn);
        return messageToReturn;
    }

    string Action_Unequip(string target)
    {
        string messageToReturn = "";

        ItemData item = player.UnequipItem(target);

        if (item != null)
        {
            messageToReturn += item.entityName + " has been unequiped.";
            messageToReturn += player.AddItemToInventory(item);
        }
        else
        {
            messageToReturn += "You don't have a " + target + " equipped.";
        }

        return messageToReturn;
    }

#endregion

    int RollWeaponDamage(int numbOfRolls)
    {
        int damage = 0;

        if (numbOfRolls == 0) numbOfRolls = 1;

        for (int i=0; i< numbOfRolls; i++)
        {
            int randDmg = UnityEngine.Random.Range(1, 12);
            damage += randDmg;
        }

        return damage;
    }

#region Get Entities
    EnvironmentData GetEnvironmentObj(string target, ChunkData currentChunk)
    {
        EnvironmentData environmentObj = currentChunk.GetTargetEnvironmentObj(target);

        if (environmentObj != null)
        {
            return environmentObj;
        }

        return null;
    }

    ItemData GetItemInWorld(string target, ChunkData currentChunk)
    {
        ItemData item = currentChunk.GetTargetItem(target);

        if (item != null)
        {
            return item;
        }

        return null;
    }

    ItemData GetItemInInventory(string target)
    {
        ItemData item = player.GetItemFromInventory(target);
        return item;
    }

    ItemData GetItemInEquipment(string target)
    {
        ItemData item = player.GetItemEquipped(target);
        return item;
    }

    NPCData GetNPC(string target, ChunkData currentChunk)
    {
        NPCData NPC = currentChunk.GetTargetNPC(target);

        if (NPC != null)
            return NPC;

        return null;
    }

#endregion


}
