using UnityEngine;

public class ESCsettings : MonoBehaviour
{
    public GameObject targetObject; // Reference to the GameObject to show

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            ShowTargetObject();
        }
    }

    void ShowTargetObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Target GameObject is not assigned!");
        }
    }
}




