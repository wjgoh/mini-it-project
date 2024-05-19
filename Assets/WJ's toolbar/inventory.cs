using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public Sprite selectedImage; // The image to be displayed when selected
    public Sprite unselectedImage; // The image to be displayed when unselected
    private Image imageComponent; // Reference to the Image component
    private static InventorySlot selectedSlot; // Reference to the currently selected slot (static for easy access)

    void Start()
    {
        imageComponent = GetComponent<Image>();

        if (imageComponent == null)
        {
            Debug.LogError("No Image component found on the GameObject.");
            enabled = false;
            return;
        }

        // Set the initial image to unselected
        imageComponent.sprite = unselectedImage;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // If another slot is already selected, deselect it
            if (selectedSlot != null && selectedSlot != this)
            {
                selectedSlot.Deselect();
            }

            // Select this slot
            Select();
        }
    }

    public void Select()
    {
        imageComponent.sprite = selectedImage;
        selectedSlot = this;
    }

    public void Deselect()
    {
        imageComponent.sprite = unselectedImage;
        if (selectedSlot == this)
        {
            selectedSlot = null;
        }
    }
}