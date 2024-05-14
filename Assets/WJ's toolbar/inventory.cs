using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeImageOnSelect : MonoBehaviour, IPointerClickHandler
{
    public Sprite newImage; // The new image to be displayed when selected
    private Image imageComponent; // Reference to the Image component

    void Start()
    {
        // Get the Image component attached to the same GameObject
        imageComponent = GetComponent<Image>();

        // Ensure that there is an Image component attached
        if (imageComponent == null)
        {
            Debug.LogError("No Image component found on the GameObject.");
            enabled = false; // Disable the script
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Check if the left mouse button is clicked
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Change the sprite to the new image
            imageComponent.sprite = newImage;
        }
    }
}
