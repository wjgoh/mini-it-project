using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeChopping : MonoBehaviour
{
    public Collider2D AxeCollider;
    Vector2 rightAxeOffset;

    private void Start() {
        rightAxeOffset = transform.position;
    }

    public void AxeRight() {
        AxeCollider.enabled = true;
        transform.localPosition = rightAxeOffset;
    }

    public void AxeLeft() {
        AxeCollider.enabled = true;
        transform.localPosition = new Vector3(rightAxeOffset.x * -1, rightAxeOffset.y);
    }

    public void AxeUp() {
        AxeCollider.enabled = true;
        transform.localPosition = new Vector3(rightAxeOffset.x, rightAxeOffset.y * 1);
    }

    public void AxeDown() {
        AxeCollider.enabled = true;
        transform.localPosition = new Vector3(rightAxeOffset.x, rightAxeOffset.y * -1);
    }
    
    public void StopAxe() {
        AxeCollider.enabled = false;
    }
}
