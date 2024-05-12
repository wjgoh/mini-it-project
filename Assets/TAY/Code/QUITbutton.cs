using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QUITbutton : MonoBehaviour
{
  public void QUITGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        #else
            Application.Quit();
        
        #endif

    }

    
}
   
