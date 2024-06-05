using UnityEngine;

public class AxeChopping : MonoBehaviour
{
    public Collider2D AxeCollider;
    private Vector2 initialAxePosition;

    private enum AxeDirection
    {
        Right,
        Left,
        Up,
        Down
    }

    private void Start()
    {
        initialAxePosition = transform.localPosition;
        gameObject.tag = "Axe"; // Set the tag to "Axe"
        AxeCollider.enabled = false; // Ensure the collider is initially disabled
    }

    private void SetAxePosition(AxeDirection direction)
    {
        AxeCollider.enabled = true;

        switch (direction)
        {
            case AxeDirection.Right:
                transform.localPosition = initialAxePosition;
                break;
            case AxeDirection.Left:
                transform.localPosition = new Vector3(-initialAxePosition.x, initialAxePosition.y);
                break;
            case AxeDirection.Up:
                transform.localPosition = new Vector3(initialAxePosition.x, initialAxePosition.y);
                break;
            case AxeDirection.Down:
                transform.localPosition = new Vector3(initialAxePosition.x, -initialAxePosition.y);
                break;
        }
    }

    public void AxeRight() => SetAxePosition(AxeDirection.Right);
    public void AxeLeft() => SetAxePosition(AxeDirection.Left);
    public void AxeUp() => SetAxePosition(AxeDirection.Up);
    public void AxeDown() => SetAxePosition(AxeDirection.Down);

    public void StopAxe()
    {
        AxeCollider.enabled = false;
    }
}
