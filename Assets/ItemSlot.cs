using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;


    [SerializeField]
    private TMP_Text quatityText;

    [SerializeField]
    private Image itemImage;
    public void AddItem(string itemName, int quantity, Sprite itemSprite)
        {
            this.itemName = itemName;
            this.quantity = quantity;
            this.itemSprite = itemSprite;
            isFull = true;

            quantityText.text = quantity.ToString();
            quantity.Text.enabled = true;
            itemImage.sprite = itemSprite;


        }

}

