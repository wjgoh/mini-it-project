using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour
{
    public Collider2D WateringCollider;
    private Vector2 initialWateringPosition;

    private enum WateringDirection
    {
        Right,
        Left,
        Up,
        Down
    }

    private void Start()
    {
        initialWateringPosition = transform.localPosition;
        gameObject.tag = "Watering"; // Set the tag to "Watering"
        WateringCollider.enabled = false; // Ensure the collider is initially disabled
    }

    private void SetWateringPosition(WateringDirection direction)
    {
        WateringCollider.enabled = true;

        switch (direction)
        {
            case WateringDirection.Right:
                transform.localPosition = initialWateringPosition;
                break;
            case WateringDirection.Left:
                transform.localPosition = new Vector3(-initialWateringPosition.x, initialWateringPosition.y);
                break;
            case WateringDirection.Up:
                transform.localPosition = new Vector3(initialWateringPosition.x, initialWateringPosition.y);
                break;
            case WateringDirection.Down:
                transform.localPosition = new Vector3(initialWateringPosition.x, -initialWateringPosition.y);
                break;
        }
    }

    public void WateringRight() => SetWateringPosition(WateringDirection.Right);
    public void WateringLeft() => SetWateringPosition(WateringDirection.Left);
    public void WateringUp() => SetWateringPosition(WateringDirection.Up);
    public void WateringDown() => SetWateringPosition(WateringDirection.Down);

    public void StopWatering()
    {
        WateringCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    PlantGrowing plant = collision.gameObject.GetComponent<PlantGrowing>();
    if (plant != null)
    {
        StartCoroutine(plant.GrowPlant());
    }
    }
}

