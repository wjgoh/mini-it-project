using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskanimationscript : MonoBehaviour
{
    public InventoryManager inventoryManager; // Reference to the InventoryManager script
    public Component task1; // The task component that should be removed
    public GameObject task1i2; // The other component that should be activated when task1 is deactivated
    public Component task2;
    public GameObject task2i2;
    public CustomLogger customLogger; // Reference to the CustomLogger script

    private bool task1Completed = false; // Flag to track if the task has been completed
    private bool task1i2Completed = false;
    private bool task2Completed = false;
    private bool task2i2Completed = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize or setup if necessary
    }

    // Update is called once per frame
    void Update()
    {
        int appleCount = 0;
        int hoeCount = 0;

        // Check the quantity of apples and hoes in the inventory
        foreach (var slot in inventoryManager.itemSlot)
        {
            if (slot.itemName != null)
            {
                if (string.Equals(slot.itemName.Trim(), "apple", StringComparison.OrdinalIgnoreCase))
                {
                    appleCount += slot.quantity;
                }
                else if (string.Equals(slot.itemName.Trim(), "hoe", StringComparison.OrdinalIgnoreCase))
                {
                    hoeCount += slot.quantity;
                }
            }
        }

        // If the quantity of apples is 2 or more and the quantity of hoes is 1 or more, hide the GameObject of the task
        if (appleCount >= 2 && hoeCount >= 1)
        {
            task1.gameObject.SetActive(false);
        }

        // If task1 is deactivated and the task has not been completed yet, activate the other component and log the message
        if (!task1.gameObject.activeSelf && !task1Completed)
        {
            task1i2.SetActive(true);
            customLogger.Log("task 1 finished"); // Use the custom logger to log the message
            task1Completed = true; // Set the flag to true to indicate that the task has been completed
        }

        // Check if the custom logger's message is "visits tutorial world" and task2 is not completed
        if (customLogger.message == "visits tutorial world" && !task2Completed)
        {
            task2Completed = true;
            task2.gameObject.SetActive(false);
            task2i2.gameObject.SetActive(true);
        }
    }

    // Public method to mark task2 as done
    public void task2done()
    {
        task2Completed = true;
        task2.gameObject.SetActive(false);
        task2i2.gameObject.SetActive(true);
    }
}
