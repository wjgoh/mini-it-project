using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogueseller : MonoBehaviour
{
    

    //Indicator
    public GameObject indicator;

    

    //Index on dialogue
    private int index;

    //Character index
    private int charIndex;

    //Started boolean
    private bool started;

    //Wait for next boolean
    private bool waitForNext;

    private void Awake()
    {
        ToggleIndicator(false);
      
    }

    
    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }
}
   