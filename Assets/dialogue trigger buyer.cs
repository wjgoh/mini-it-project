using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerBuyer : MonoBehaviour
{
    public dialoguebuyer dialoguebuyer;
    public GameObject buyer;
    private bool playerDetected;
    private bool menuActive = false;

    //Detect trigger with player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If we triggerd the player enable playerdeteced and show indicator
        if(collision.tag == "Player")
        {
            playerDetected = true;
            dialoguebuyer.ToggleIndicator(playerDetected);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //If we lost trigger  with the player disable playerdeteced and hide indicator
        if (collision.tag == "Player")
        {
            playerDetected = false;
            dialoguebuyer.ToggleIndicator(playerDetected);

        }
    }
    //While detected if we interact start the dialogue
    private void Update()
    {
        if(playerDetected)
        {
            if(Input.GetKeyDown(KeyCode.Q) && !menuActive)
            {
                buyer.SetActive(true);
                menuActive = true;
            }
            else if (Input.GetKeyDown(KeyCode.Q) && menuActive)
            {
                buyer.SetActive(false);
                menuActive = false;
            }
        }

        else if(playerDetected == false)
        {
            buyer.SetActive(false);
            menuActive = false;
        }

    }








}