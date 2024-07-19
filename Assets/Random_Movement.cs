using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_random : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float changeDirectionTime = 6f;

    private Vector2 movementDirection;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        movementDirection = Vector2.right;
        StartCoroutine(ChangeDirectionRoutine());
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = movementDirection * moveSpeed;
        spriteRenderer.flipX = rb.velocity.x < 0f;
    }

    private IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeDirectionTime);
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        movementDirection = -movementDirection;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopMovement();
        }
    }

    public void StopMovement()
    {
        movementDirection = Vector2.zero;
    }
}