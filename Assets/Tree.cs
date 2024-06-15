using UnityEngine;

public class Tree : MonoBehaviour
{

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
        Destroy(gameObject);
    }
}