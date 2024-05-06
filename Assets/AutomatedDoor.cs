using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AutomatedDoor : MonoBehaviour
{
    private Animator animator;

    bool triggerOpen = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        PlayerInput playerInput = col.GetComponent<PlayerInput>();

        if(playerInput){
            this.triggerOpen = true; 
            animator.SetBool("triggerOpen", triggerOpen);
        }

    }

    void OnTriggerExit2D(Collider2D col){
        PlayerInput playerInput = col.GetComponent<PlayerInput>();

        if(playerInput){
            triggerOpen = false; 
            animator.SetBool("triggerOpen", triggerOpen);
        }
    }
}
