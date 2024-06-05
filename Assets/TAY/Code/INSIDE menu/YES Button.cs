using UnityEngine;

public class QuitButtonShowExist : MonoBehaviour
{
 public GameObject EXISTObject; // Reference to the GameObject to show

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ShowEXISTObject();
        }
    }

    void ShowEXISTObject()
    {
        if (EXISTObject != null)
        {
             bool isActive = EXISTObject.activeSelf;
            EXISTObject.SetActive(!isActive);
        }
        else
        {
            Debug.LogWarning("Target GameObject is not assigned!");
        }
    }
}

