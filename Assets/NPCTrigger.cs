using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    // The message that the NPC will say when the player enters the trigger area
    public string message = "Hello, traveler!";

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Display the message
            SayMessage();
            Debug.Log("Player entered the NPC's area");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object that exited the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Optionally, you can handle logic when the player exits the area
            Debug.Log("Player exited the NPC's area");
        }
    }

    private void SayMessage()
    {
        // For simplicity, just log the message to the console
        Debug.Log(message);
        // In a real game, you would probably show this message in a UI element
    }
}