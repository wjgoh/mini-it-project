using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IDataPersistence
{
    //Ayden from here 

    [SerializeField]
    private string id;
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = Guid.NewGuid().ToString();
    }
    //To here

    [SerializeField]
    private string itemName;

    [SerializeField] 
    private int quantity;

    [SerializeField] 
    private Sprite sprite;

    private InventoryManager inventoryManager;
    private bool playerInRange;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            CollectItem();
        }
    }

    private void CollectItem()
    {
        int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite);
        if (leftOverItems <= 0)
            Destroy(gameObject);
        else
            quantity = leftOverItems;
    }

    // Save load system

    public void LoadData(GameData data)
    {
        if (data.itemsCollected.TryGetValue(id, out bool isCollected) && isCollected)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData(ref GameData data)
    {
        if (data.itemsCollected.ContainsKey(id))
        {
            data.itemsCollected[id] = true;
        }
        else
        {
            data.itemsCollected.Add(id, true);
        }
    }
}