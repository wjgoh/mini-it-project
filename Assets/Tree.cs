using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject droppedSprite; // The sprite to drop when the tree is destroyed

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe"))
        {
            Debug.Log("Tree hit by axe.");
            Disappear();
        }
    }

    private void Disappear()
    {
        // Instantiate the dropped sprite at the tree's position
        Instantiate(droppedSprite, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}