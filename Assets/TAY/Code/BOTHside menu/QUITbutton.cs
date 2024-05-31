using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QUITbutton : MonoBehaviour
{
    // Method to quit the game, can be called from a UI button
    public void QUITGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    
    // Check for the Q key press in the Update method
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}

   
