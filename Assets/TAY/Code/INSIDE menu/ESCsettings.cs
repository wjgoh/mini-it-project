using UnityEngine;

public class ShowGameObjectOnKeyPress : MonoBehaviour
{
    public GameObject targetObject; // Reference to the GameObject to show/hide

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleTargetObject();
        }
    }

    void ToggleTargetObject()
    {
        if (targetObject != null)
        {
            bool isActive = targetObject.activeSelf;
            targetObject.SetActive(!isActive);
        }
        else
        {
            Debug.LogWarning("Target GameObject is not assigned!");
        }
    }
}




