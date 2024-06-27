using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventoryItemData
{
    public string itemName;
    public int quantity;
    public string spriteName;
}

public class InventoryManager : MonoBehaviour, IDataPersistence
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;
    public Image selectedItemImage;
    public Sprite hoeSprite;
    private bool hasGivenHoe = false;
    public Sprite blankSprite;
    private ToolUse toolUse; // Reference to the ToolUse script
    private Dictionary<string,ToolType> itemToolMapping;

    void Start()
    {
        itemToolMapping = new Dictionary<string, ToolType>
        {
            { "Axe", ToolType.Axe },
            { "Hoe", ToolType.Hoe },
            { "Watering", ToolType.Watering }
        };

        selectedItemImage.gameObject.SetActive(false);

        toolUse = FindObjectOfType<ToolUse>(); // Find the ToolUse script in the scene

        // Commented out the section that selects the first item by default
        /*
        if (itemSlot.Length > 0)
        {
            itemSlot[0].selectedShader.SetActive(true);
            if (itemSlot[0].itemSprite != null)
            {
                ShowSelectedItem(itemSlot[0].itemSprite);
                toolUse.SetCurrentTool(itemSlot[0].toolType); // Set the initial tool
            }
        }
        */
    }

    public bool HasGivenHoe()
    {
        return hasGivenHoe;
    }

    private bool hasLoggedApple = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && menuActivated)
        {
            Time.timeScale = 1; // Resume the game
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && !menuActivated)
        {
            Time.timeScale = 0; // Pause the game
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
        
        foreach (var slot in itemSlot)
        {
            if (slot.itemName == "apple" && slot.quantity >= 2)
            {
                if (!hasLoggedApple)
                {
                    Debug.Log("Apple quantity is 3 or more");
                    hasLoggedApple = true;
                }
                if (!hasGivenHoe)
                {
                    AddItem("hoe", 1, hoeSprite); 
                    hasGivenHoe = true;
                }
                break;
            }
        }

        // Clear inventory on 'K' key press
        if (Input.GetKeyDown(KeyCode.K))
        {
            ClearInventory();
        }

        if (itemSlot.Length > 0 && itemSlot[0].itemSprite != null && !selectedItemImage.gameObject.activeSelf)
        {
            ShowSelectedItem(itemSlot[0].itemSprite);
            toolUse.SetCurrentTool(itemSlot[0].toolType); // Update tool when selecting an item
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
            if (itemSlot[i].isFull == false && (itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0))
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite);
            
                // Assign the tag to the item
                itemSlot[i].gameObject.tag = itemName;

                // New: Assign ToolType based on the item name
                if (itemToolMapping.TryGetValue(itemName, out ToolType toolType))
                {
                    itemSlot[i].toolType = toolType;
                }

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
            var player = GameObject.FindWithTag("Player");
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/" + itemSlot.itemName), player.transform.position, Quaternion.identity);

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
        foreach (var itemData in data.inventoryItems)
        {
            Sprite itemSprite = GetSpriteForItem(itemData.spriteName);
            AddItem(itemData.itemName, itemData.quantity, itemSprite);

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
    }

    private Sprite GetSpriteForItem(string spriteName)
    {
        if (spriteName == hoeSprite.name)
        {
            return hoeSprite;
        }

        // Add additional conditions for other item sprites
        return blankSprite;
    }
}

