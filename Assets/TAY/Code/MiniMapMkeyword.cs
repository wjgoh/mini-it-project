using UnityEngine;

public class MiniMapkeyword : MonoBehaviour
{
    public GameObject targetObject1; // Reference to the GameObject to show/hide
    public GameObject targetObject2;
void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleTargetObjects();
        }
    }

    void ToggleTargetObjects()
    {
        ToggleTargetObject(targetObject1);
        ToggleTargetObject(targetObject2);
    }

    void ToggleTargetObject(GameObject targetObject)
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
    
