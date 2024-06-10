using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskanimationscript : MonoBehaviour
{
    public InventoryManager inventoryManager; // Reference to the InventoryManager script
    public Component taskComponent; // The task component that should be removed
    public GameObject Component2; // The other component that should be activated when taskComponent is deactivated

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per fram
    void Update()
    {
        int appleCount = 0;
        int hoeCount = 0;

        // Check the quantity of apples and hoes in the inventory
        foreach (var slot in inventoryManager.itemSlot)
        {
            if (slot.itemName == "apple")
            {
                appleCount += slot.quantity;
            }
            else if (slot.itemName == "hoe")
            {
                hoeCount += slot.quantity;
            }
        }
        
        // If the quantity of apples is 3 or more and the quantity of hoes is 1 or more, hide the GameObject of the task
        if (appleCount >= 3 && hoeCount >= 1)
        {
            taskComponent.gameObject.SetActive(false);
        }

        // If taskComponent is deactivated, activate the other component
        if (!taskComponent.gameObject.activeSelf)
        {
            Component2.SetActive(true);
        }
    }
}