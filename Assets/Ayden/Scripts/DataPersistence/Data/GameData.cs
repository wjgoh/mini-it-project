using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData 
{
    public Dictionary<string,bool> itemsCollected = new Dictionary<string,bool>();
    public Vector3 playerPosition;

    public GameData()
    {
        playerPosition = Vector3.zero;
    }
}
