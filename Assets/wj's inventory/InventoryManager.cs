using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InventoryManager : MonoBehaviour
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
        LoadInventory(); // Load the inventory at the start
    }

    public bool HasGivenAxe()
    {
        return hasGivenAxe;
    }

    private bool hasLoggedApple = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && menuActivated)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActivated = false;
            SaveInventory(); // Save the inventory when the menu is closed
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

    // Save Load Feature

    public void SaveInventory()
    {
        InventoryData inventoryData = new InventoryData();
        foreach (var slot in itemSlot)
        {
            if (slot.quantity > 0)
            {
                ItemData itemData = new ItemData
                {
                    itemName = slot.itemName,
                    quantity = slot.quantity
                };
                inventoryData.items.Add(itemData);
            }
        }
        string json = JsonUtility.ToJson(inventoryData);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, "inventory.json"), json);
        Debug.Log("Inventory saved.");
    }

    public void LoadInventory()
    {
        string path = Path.Combine(Application.persistentDataPath, "inventory.json");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            InventoryData inventoryData = JsonUtility.FromJson<InventoryData>(json);

            foreach (var itemData in inventoryData.items)
            {
                Sprite itemSprite = GetSpriteForItem(itemData.itemName); // Implement this method to get the correct sprite
                AddItem(itemData.itemName, itemData.quantity, itemSprite);
            }

            Debug.Log("Inventory loaded.");
        }
        else
        {
            Debug.Log("No save file found.");
        }
    }

    private Sprite GetSpriteForItem(string itemName)
    {
        // Implement logic to return the correct sprite for the item name
        if (itemName == "axe")
        {
            return axeSprite;
        }

        // Add additional conditions for other item sprites
        return blankSprite; // Return a default sprite if no match is found
    }
}

[System.Serializable]
public class InventoryData
{
    public List<ItemData> items = new List<ItemData>();
}

[System.Serializable]
public class ItemData
{
    public string itemName;
    public int quantity;
}
