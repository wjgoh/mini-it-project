using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerSeller : MonoBehaviour
{
    public dialogueseller dialogueseller;
    public GameObject seller;
    private bool playerDetected;
    private bool menuActive = false;

    //Detect trigger with player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If we triggerd the player enable playerdeteced and show indicator
        if(collision.tag == "Player")
        {
            playerDetected = true;
            dialogueseller.ToggleIndicator(playerDetected);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //If we lost trigger  with the player disable playerdeteced and hide indicator
        if (collision.tag == "Player")
        {
            playerDetected = false;
            dialogueseller.ToggleIndicator(playerDetected);
           
        }
    }
    //While detected if we interact start the dialogue
    private void Update()
    {
        if(playerDetected)
        {
            if(Input.GetKeyDown(KeyCode.Q) && !menuActive)
            {
                seller.SetActive(true);
                menuActive = true;
            }
            else if (Input.GetKeyDown(KeyCode.Q) && menuActive)
            {
                seller.SetActive(false);
                menuActive = false;
            }
        }
        
        else if(playerDetected == false)
        {
            seller.SetActive(false);
            menuActive = false;
        }
        
    }
        
        
        
        
        
        
        
        
    }
