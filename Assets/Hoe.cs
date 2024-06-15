using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : MonoBehaviour
{
    public Collider2D HoeCollider;
    private Vector2 initialHoePosition;

    private enum HoeDirection
    {
        Right,
        Left,
        Up,
        Down
    }

    private void Start()
    {
        initialHoePosition = transform.localPosition;
        gameObject.tag = "Hoe"; // Set the tag to "Hoe"
        HoeCollider.enabled = false; // Ensure the collider is initially disabled
    }

    private void SetHoePosition(HoeDirection direction)
    {
        HoeCollider.enabled = true;

        switch (direction)
        {
            case HoeDirection.Right:
                transform.localPosition = initialHoePosition;
                break;
            case HoeDirection.Left:
                transform.localPosition = new Vector3(-initialHoePosition.x, initialHoePosition.y);
                break;
            case HoeDirection.Up:
                transform.localPosition = new Vector3(initialHoePosition.x, initialHoePosition.y);
                break;
            case HoeDirection.Down:
                transform.localPosition = new Vector3(initialHoePosition.x, -initialHoePosition.y);
                break;
        }
    }

    public void HoeRight() => SetHoePosition(HoeDirection.Right);
    public void HoeLeft() => SetHoePosition(HoeDirection.Left);
    public void HoeUp() => SetHoePosition(HoeDirection.Up);
    public void HoeDown() => SetHoePosition(HoeDirection.Down);

    public void StopHoe()
    {
        HoeCollider.enabled = false;
    }
}
