using UnityEngine;

public class ToolUse : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    private ToolType currentTool = ToolType.None; // Current selected tool

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Assume 'Space' key is used for using tools
        {
            UseTool();
        }
    }

    public void SetCurrentTool(ToolType tool)
    {
        currentTool = tool;
    }

    void UseTool()
    {
        switch (currentTool)
        {
            case ToolType.Axe:
                animator.SetTrigger("Chopping");
                break;
            case ToolType.Hoe:
                animator.SetTrigger("Hoe");
                break;
            case ToolType.None:
                Debug.Log("No tool selected");
                break;
        }
    }
}
