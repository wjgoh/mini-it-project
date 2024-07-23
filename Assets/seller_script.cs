using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class seller_script : MonoBehaviour
{
    
    public Button button1;
    public Button button2;
    public Button button3;
    
    public InventoryManager inventoryManager; 
    public Sprite eggSprite; 
    public Sprite appleSprite;
    public Sprite milkSprite;
    public Currency currencyManager; // Add this line

    
     
    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(Button1Clicked);
        button2.onClick.AddListener(Button2Clicked);        
        button3.onClick.AddListener(Button3Clicked);
    }

    // Update is called once per frame
    void Update()
    {
        int eggCount = 0;
        int appleCount = 0;
        int milkCount = 0;

        // Check the quantity of apples, eggs, and milk in the inventory
        foreach (var slot in inventoryManager.itemSlot)
        {
            if (slot.itemName != null)
            {
                if (string.Equals(slot.itemName.Trim(), "apple", StringComparison.OrdinalIgnoreCase))
                {
                    appleCount += slot.quantity;
                }
                else if (string.Equals(slot.itemName.Trim(), "egg", StringComparison.OrdinalIgnoreCase))
                {
                    eggCount += slot.quantity;
                }
                else if (string.Equals(slot.itemName.Trim(), "milk", StringComparison.OrdinalIgnoreCase))
                {
                    milkCount += slot.quantity;
                }
            }
        }
    
        // Set button1 interactable if there are eggs, otherwise not interactable
        button1.interactable = eggCount > 0;

        // Set button2 interactable if there are apples, otherwise not interactable
        button2.interactable = appleCount > 0;

        // Set button3 interactable if there is milk, otherwise not interactable
        button3.interactable = milkCount > 0;
        
        if (button1.interactable == false && button2.interactable == false && button3.interactable == false)
        {
            Debug.Log("No items to sell");
        }
        
        
    }
    
    void Button1Clicked()
    {
        if (button1.interactable)
        {
            inventoryManager.RemoveItem("egg", 1);
            Debug.Log("egg sold");
            inventoryManager.RefreshInventory();
            currencyManager.AddCurrency(200); // Add this line
        }
    }

    void Button2Clicked()
    {
        if (button2.interactable)
        {
            inventoryManager.RemoveItem("apple", 1);
            Debug.Log("apple sold");
            inventoryManager.RefreshInventory();
            currencyManager.AddCurrency(100); // Add this line

        }
    }

    void Button3Clicked()
    {
        if (button3.interactable)
        {
            inventoryManager.RemoveItem("milk", 1);
            Debug.Log("milk sold");
            inventoryManager.RefreshInventory();
            currencyManager.AddCurrency(200); // Add this line

        }
    }
}