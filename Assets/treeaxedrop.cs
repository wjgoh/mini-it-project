using UnityEngine;

public class treeaxedrop : MonoBehaviour
{
    public GameObject applePrefab;  // Prefab of the apple object
    public Vector3 dropPosition;  // Position where the apple will be dropped
    private bool playerInRange;
    private InventoryManager InventoryManager;  // Reference to the InventoryManager

    
    // Existing code...

    private void Start()
    {
        // Find the InventoryManager instance
        InventoryManager = FindObjectOfType<InventoryManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
            Debug.Log("Player is in range");
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
            Debug.Log("Player is not in range");
        }
    }
    
    

    private void DropApple()
    {
        // Instantiate an apple object at the specified position
        Instantiate(applePrefab, dropPosition, Quaternion.identity);
    }
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && playerInRange && InventoryManager.selectedItemName == "Axe")
        {
            DropApple();
        }
    }
}