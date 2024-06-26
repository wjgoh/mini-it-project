using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public Vector3 playerPosition;
    public Dictionary<string, bool> itemsCollected = new Dictionary<string, bool>();
    public List<InventoryItemData> inventoryItems = new List<InventoryItemData>();
    public GameData()
    {
        playerPosition = Vector3.zero;
    }
}