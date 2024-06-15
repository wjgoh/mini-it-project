using UnityEngine;
using UnityEngine.EventSystems;

public class keyboard_map: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject objectToShow; // The object to show when hovering

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Show the object when the mouse pointer hovers over this GameObject
        objectToShow.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Hide the object when the mouse pointer leaves this GameObject
        objectToShow.SetActive(false);
    }
}