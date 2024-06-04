using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D normalCursor; // Picture A
    public Texture2D clickCursor; // Picture B

    void Start()
    {
        // Set Picture A as the default cursor
        Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
    }

    void Update()
    {
        // Check if the mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Set Picture B as the cursor when clicked
            Cursor.SetCursor(clickCursor, Vector2.zero, CursorMode.Auto);
        }
        // Check if the mouse button is released
        else if (Input.GetMouseButtonUp(0))
        {
            // Set Picture A as the cursor when released
            Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
        }
    }
}



