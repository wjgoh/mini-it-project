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

    // ITEM SLOT
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;

    [SerializeField]
    private Sprite selectedItemImage; // Image to use when the item is selected
    private Sprite defaultItemImage;  // Store the default image

    public bool thisItemSelected;
    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        defaultItemImage = itemImage.sprite; // Store the default image
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite)
    {
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
        inventoryManager.DeselectAllSlots();
        thisItemSelected = true;
        itemImage.sprite = selectedItemImage; // Change to selected state image
        inventoryManager.ShowSelectedItem(itemSprite);
    }

    public void OnRightClick()
    {
        // Add functionality for right click if needed
    }

    public void Deselect()
    {
        thisItemSelected = false;
        itemImage.sprite = defaultItemImage; // Reset to default state image
    }
}
