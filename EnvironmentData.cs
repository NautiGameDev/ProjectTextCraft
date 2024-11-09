using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName ="Environment Data" ,menuName ="Data/Environment Data")]
public class EnvironmentData : ScriptableObject
{
    public enum entTypes {TREE, ORE, FURNITURE} //Is this needed??

    public string entityName;
    public entTypes entityType;

    ItemData entityConnection; //Used for keys to doors and chests
    public ItemData[] dropTable;
    public ItemData[] inventoryTable;
    public string[] attackMessages;
    public string[] listenMessages;
    public string[] inspectMessages;
    public string[] gatherMessages;
    public string[] lootMessages;

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

    public ItemData GetItemFromInventory()
    {
        int randomChoice = UnityEngine.Random.Range(0, inventoryTable.Length-1);
        return inventoryTable[randomChoice];
    }

    public string GetAttackMessage()
    {
        int randomChoice = UnityEngine.Random.Range(0, attackMessages.Length-1);
        return attackMessages[randomChoice];
    }
}
