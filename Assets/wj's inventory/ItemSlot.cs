using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    // ITEM DATA
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;

    [SerializeField]
    private int maxNumberOfItems;

    // Add a new field for tool type
    public ToolType toolType;

    // ITEM SLOT
    [SerializeField]
    public TMP_Text quantityText;
    [SerializeField]
    public Image itemImage;

    public GameObject selectedShader;
    public bool thisItemSelected;
    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        // Check to see if the slot is full
        if (isFull)
            return quantity;

        // Update Name
        this.itemName = itemName;

        // Update image
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;

        // Update quantity
        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;

            // Return the leftovers
            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }

        // Update quantity text
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

        return 0;
    }
    
    public bool RemoveItem(int quantity)
    {
        Debug.Log($"RemoveItem called with quantity: {quantity}");

        if (this.quantity >= quantity)
        {
            Debug.Log($"Current quantity before removal: {this.quantity}");
            this.quantity -= quantity;
            Debug.Log($"Current quantity after removal: {this.quantity}");

            if (this.quantity == 0)
            {
                this.itemName = null;
                this.itemSprite = null;
                this.isFull = false;
                this.itemImage.sprite = null; // Set the item image to null
            }

            quantityText.text = this.quantity.ToString();
            return true;
        }
        else
        {
            Debug.Log("Not enough quantity to remove");
            return false;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

public void OnLeftClick()
{
        inventoryManager.selectedItemName = itemName;

        if (thisItemSelected)
        {
            inventoryManager.DeselectAllSlots();
            inventoryManager.ShowSelectedItem(null);
            thisItemSelected = false;
            Debug.Log("Deselected item: " + itemName); // Log when an item is deselected
        }
        else
        {
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
            inventoryManager.ShowSelectedItem(itemSprite);
            Debug.Log("Selected item: " + itemName);
        }

    // Notify the PlayerController about the selected tool
    PlayerController playerController = FindObjectOfType<PlayerController>();
    playerController.SetCurrentTool(toolType);
}

    public void OnRightClick()
    {
        // Add functionality for right click if needed
    }
}
