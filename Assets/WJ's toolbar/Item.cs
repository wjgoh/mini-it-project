using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite; 

    private Inventory inventorymanager;
    // Start is called before the first frame update
    void Start()
    {
        inventorymanager = GameObject.Find("Inventory Canvas").GetComponent<Inventory>();
    }

   private void OnCollisionEnter2D(Collision2D collision)
   {
        if(collision.gameObject.tag == "Player")
        {
            inventorymanager.AddItem(itemName, quantity, sprite);
            Destroy (gameObject);
        }
   }
}
