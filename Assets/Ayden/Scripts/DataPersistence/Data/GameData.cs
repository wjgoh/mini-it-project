using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData 
{
    public int deathCount;

    //the values defined in this constructor will be the default values
    //the game starts with when there's no data to load

    public GameData()
    {
        this.deathCount = 0;
    }
}
