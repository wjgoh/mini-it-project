using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_random : MonoBehaviour
{
// random npc movement script 
    public float moveSpeed = 2f;  // The speed at which the NPC moves
    public float changeDirectionTime = 2f;  // Time between direction changes

    private Vector2 movementDirection;  // The direction in which the NPC will move
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeDirectionRoutine());
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = movementDirection * moveSpeed;
        spriteRenderer.flipX = rb.velocity.x <0f;
    }

    private IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            ChooseRandomDirection();
            yield return new WaitForSeconds(changeDirectionTime);
        }
    }

    private void ChooseRandomDirection()
    {
        // Randomly choose left or right direction
        int direction = Random.Range(0, 2);  // 0 for left, 1 for right
        if (direction == 0)
        {
            movementDirection = Vector2.left;
        }
        else
        {
            movementDirection = Vector2.right;
        }
    }

}
