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
            EXISTObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Target GameObject is not assigned!");
        }
    }
}

