using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour, IDataPersistence
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;
    public Image selectedItemImage; // Reference to the UI Image for the selected item
    public Sprite axeSprite; // Add this line
    private bool hasGivenAxe = false; // Add this line
    public Sprite blankSprite;
    
    void Start()
    {
        selectedItemImage.gameObject.SetActive(false); // Hide the image initially

        // Comment out or remove the following lines
        // if (itemSlot.Length > 0)
        // {
        //     itemSlot[0].selectedShader.SetActive(true);
        //     if (itemSlot[0].itemSprite != null) // Check if the first slot has an item
        //     {
        //         ShowSelectedItem(itemSlot[0]
        //             .itemSprite); // Update the selectedItemImage with the sprite of the first slot's item
        //     }
        // }
    }
    
    public bool HasGivenAxe()
    {

        return hasGivenAxe;
    }

    
    private bool hasLoggedApple = false;
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

        // Check for apple quantity
        foreach (var slot in itemSlot)
        {
            if (slot.itemName == "apple" && slot.quantity >= 3)
            {
                if (!hasLoggedApple)
                {
                    Debug.Log("Apple quantity is 3 or more");
                    hasLoggedApple = true;
                }
                if (!hasGivenAxe)
                {
                    AddItem("axe", 1, axeSprite); 
                    hasGivenAxe = true;
                }

                break;
            }
        }
        // Clear inventory on 'K' key press
        if (Input.GetKeyDown(KeyCode.K))
        {
            ClearInventory();
        }
    }


    public void ClearInventory()
    {
        foreach (var slot in itemSlot)
        {
            slot.itemName = null;
            slot.itemSprite = null;
            slot.quantity = 0;
            slot.isFull = false;
        }
        // Deselect all slots and update UI (if needed)
        DeselectAllSlots();
        ShowSelectedItem(null); // Clear selected item image or hide it
    
     }

    public int AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite);
                if (leftOverItems > 0)
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite);

                return leftOverItems;
            }
        }

        return quantity;
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }

    public void ShowSelectedItem(Sprite itemSprite)
    {
        if (itemSprite == null)
        {
            selectedItemImage.sprite = blankSprite; // Set to blank sprite
            selectedItemImage.gameObject.SetActive(true); // Keep the image active
        }
        else
        {
            selectedItemImage.sprite = itemSprite;
            selectedItemImage.gameObject.SetActive(true);
        }
    }
    
    public void DropItem(ItemSlot itemSlot)
    {
        if (itemSlot.quantity > 0)
        {
            // Instantiate the item at the player's position
            var player = GameObject.FindWithTag("Player");
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/" + itemSlot.itemName), player.transform.position, Quaternion.identity);

            // Decrease the quantity of the item in the inventory
            itemSlot.quantity--;
            if (itemSlot.quantity == 0)
            {
                itemSlot.itemName = null;
                itemSlot.itemSprite = null;
                itemSlot.isFull = false;
            }
        }
    }

    //Save Load System

    public void SaveData(ref GameData data)
    {
        data.inventoryItems.Clear();
        foreach (var slot in itemSlot)
        {
            if (slot.quantity > 0)
            {
                InventoryItemData itemData = new InventoryItemData
                {
                    itemName = slot.itemName,
                    quantity = slot.quantity, 
                    spriteName = slot.itemSprite.name
                };
                data.inventoryItems.Add(itemData);
            }
        }
    }

    public void LoadData(GameData data)
    {
        ClearInventory();

        foreach (var itemData in data.inventoryItems)
        {
            Sprite itemSprite = GetSpriteForItem(itemData.spriteName);
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (itemSlot[i].quantity == 0)
                {
                    itemSlot[i].AddItem(itemData.itemName, itemData.quantity, itemSprite);
                    break;
                }
            }
        }
    }



    private Sprite GetSpriteForItem(string spriteName)
    {
        if (spriteName == axeSprite.name)
        {
            return axeSprite;
        }

        // Add additional conditions for other item sprites
        return blankSprite;
    }

    [System.Serializable]
    public class InventoryItemData
    {
        public string itemName;
        public int quantity;
        public string spriteName;
    }
}    