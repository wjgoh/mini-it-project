using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Item : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]


    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    [SerializeField]
    private string itemName;

    [SerializeField] 
    private int quantity;

    [SerializeField] 
    private Sprite sprite;

    private InventoryManager inventoryManager;

    private bool playerInRange;

    public object visual { get; private set; }

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

    public void LoadData(GameData data)
    {
        data.itemsCollected.TryGetValue(id, out playerInRange);
        if (playerInRange)
        {
            object value = visual.gameObject.SetActive(false);
        }

    }

    public void SaveData(ref GameData data)
    {
        if (data.itemsCollected.ContainsKey(id))
        {
            data.itemsCollected.Remove(id);
        }
        data.itemsCollected.Add(id, playerInRange);
    }
}