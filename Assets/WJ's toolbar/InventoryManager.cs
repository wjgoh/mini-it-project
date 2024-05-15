using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject InventoryMenu;
    public GameObject InventoryButton;
    private bool menuActivated;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && menuActivated)
        {
            InventoryMenu.SetActive(false);
            InventoryButton.SetActive(true);
            menuActivated = false;
        }
        
        else if(Input.GetKeyDown(KeyCode.E) && !menuActivated)
        {
            InventoryMenu.SetActive(true);
            InventoryButton.SetActive(false);
            menuActivated = true;
        }
        
        
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        Debug.Log("itemName = " + itemName + "quantity =" + quantity + "itemSprite =" + itemSprite);
    }

}
