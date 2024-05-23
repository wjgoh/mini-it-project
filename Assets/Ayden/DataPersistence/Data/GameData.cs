using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public Vector3 playerPosition;

    // the values defined in this constructor wil be the default values
    // the game starts when there's no data to load
 
    public GameData()
    {
        playerPosition = Vector3.zero;
    }
}
