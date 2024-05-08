using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeDoor : MonoBehaviour
{
    // Inspector variables
    public Animator doorAnimator; // Reference to the door's Animator component
    public BoxCollider2D triggerCollider; // Reference to the door's BoxCollider2D
    public bool isOpen = false; // Flag to track door state

    void Start()
    {
        // Ensure doorAnimator is assigned
        if (doorAnimator == null)
        {
            Debug.LogError("Please assign the door's Animator component in the Inspector!");
        }
        
        // Ensure triggerCollider is assigned (assuming it's attached to this GameObject)
        if (triggerCollider == null)
        {
            Debug.LogError("Please add a BoxCollider2D to this GameObject and assign it to the triggerCollider variable in the Inspector!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if colliding object is tagged "Player"
        if (other.CompareTag("Player"))
        {
            ToggleDoor();
        }
    }

    void ToggleDoor()
    {
        isOpen = !isOpen; // Flip the isOpen flag

        // Trigger animation based on isOpen
        if (isOpen)
        {
            doorAnimator.Play("OpenDoor"); // Replace "OpenDoor" with your animation name
        }
        else
        {
            doorAnimator.Play("CloseDoor"); // Replace "CloseDoor" with your animation name
        }
    }
}
