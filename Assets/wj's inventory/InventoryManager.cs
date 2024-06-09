using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;
    public Image selectedItemImage; // Reference to the UI Image for the selected item

    void Start()
    {
        selectedItemImage.gameObject.SetActive(false); // Hide the image initially
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && menuActivated)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && !menuActivated)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        int appleCount = 0;

        // First check if the item already exists in the inventory
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].itemName == itemName)
            {
                appleCount += itemSlot[i].quantity;

                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite);
                if (leftOverItems > 0)
                {
                    return AddItem(itemName, leftOverItems, itemSprite);
                }

                // Check the apple condition
                if (itemName == "Apple" && appleCount + quantity == 3)
                {
                    Debug.Log("There are now exactly 3 apples in the inventory.");
                }

                return 0; // All items added successfully
            }
        }

        // If the item does not exist, find an empty slot
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite);
                if (leftOverItems > 0)
                {
                    return AddItem(itemName, leftOverItems, itemSprite);
                }

                // Check the apple condition
                if (itemName == "Apple" && quantity == 3)
                {
                    Debug.Log("There are now exactly 3 apples in the inventory.");
                }

                return 0; // All items added successfully
            }
        }

        return quantity; // Inventory is full, return remaining quantity
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].Deselect();
        }
    }

    public void ShowSelectedItem(Sprite itemSprite)
    {
        selectedItemImage.sprite = itemSprite;
        selectedItemImage.gameObject.SetActive(true);
    }
}
