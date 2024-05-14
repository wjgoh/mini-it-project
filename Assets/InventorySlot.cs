using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image image;
    public Sprite selectedSprite;
    public Sprite unselectedSprite;

    private void Awake() {
        Deselect();
    }

    public void Select() {
        if (image != null && selectedSprite != null) {
            image.sprite = selectedSprite;
        }
    }

    public void Deselect() {
        if (image != null && unselectedSprite != null) {
            image.sprite = unselectedSprite;
        }
    }
}
