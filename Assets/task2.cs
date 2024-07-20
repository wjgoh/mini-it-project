using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class task2 : MonoBehaviour
{
    public InventoryManager inventoryManager; 
    public GameObject [] Tasks;   
    public GameObject taskPanel;
    private bool menuActivated;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && menuActivated)
        {
            taskPanel.SetActive(false);
            menuActivated = false;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && !menuActivated)
        {
            taskPanel.SetActive(true);
            menuActivated = true;
        }
    }



    // Update is called once per frame
   
}
