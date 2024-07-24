using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class buyer_script : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    
    public InventoryManager inventoryManager; 
    public Sprite HoeSprite; 
    public Sprite WateringSprite;
    public Sprite AxeSprite;
    public Currency currencyManager; 

    void Start()
    {
        button1.onClick.AddListener(Button1Clicked);
        button2.onClick.AddListener(Button2Clicked);        
        button3.onClick.AddListener(Button3Clicked);
    }

    void Update()
    {
        // Set button1 interactable if there is enough currency to buy an egg
        button1.interactable = currencyManager.currency >= 200;

        // Set button2 interactable if there is enough currency to buy an apple
        button2.interactable = currencyManager.currency >= 100;

        // Set button3 interactable if there is enough currency to buy milk
        button3.interactable = currencyManager.currency >= 300;
        
        if (!button1.interactable && !button2.interactable && !button3.interactable)
        {
            Debug.Log("Not enough currency to buy items");
        }
        
    }
    
    void Button1Clicked()
    {
        if (button1.interactable)
        {
            inventoryManager.AddItem("Hoe", 1, HoeSprite);
            Debug.Log("Hoe bought");
            inventoryManager.RefreshInventory();
            currencyManager.SubtractCurrency(200);
        }
    }

    void Button2Clicked()
    {
        if (button2.interactable)
        {
            inventoryManager.AddItem("Watering", 1, WateringSprite);
            Debug.Log("Watering bought");
            inventoryManager.RefreshInventory();
            currencyManager.SubtractCurrency(100);
        }
    }
    
    void Button3Clicked()
    {
        if (button3.interactable)
        {
            inventoryManager.AddItem("Axe", 1, AxeSprite);
            Debug.Log("Axe bought");
            inventoryManager.RefreshInventory();
            currencyManager.SubtractCurrency(300);
        }
    }

   

    
}