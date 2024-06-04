using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IDataPersistence
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public AxeChopping axeChopping;

    Vector2 movementInput;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if (movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);

                if (!success)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));
                }

                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }

                SetAnimationParameters(movementInput, success);
            }
            else
            {
                SetAnimationParameters(Vector2.zero, false);
            }
        }
    }

    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void SetAnimationParameters(Vector2 movement, bool moving)
    {
        animator.SetBool("Moving", moving);

        if (movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
    }

    // Play the chopping animation and enable axe collider when mouse 1 is pressed
    void OnFire()
    {
        animator.SetTrigger("Chop");
        HandleAxeChopping();
    }

    public void ControlAxeChopping(Vector2 movement, bool moving)
    {
        LockMovement();

        SetAnimationParameters(movement, moving);

        if (moving)
        {
            if (movement.x > 0)
            {
                axeChopping.AxeRight();
            }
            else if (movement.x < 0)
            {
                axeChopping.AxeLeft();
            }
            else if (movement.y > 0)
            {
                axeChopping.AxeUp();
            }
            else if (movement.y < 0)
            {
                axeChopping.AxeDown();
            }
        }
        else
        {
            axeChopping.StopAxe();
        }

        UnlockMovement();
    }

    public void HandleAxeChopping()
    {
        ControlAxeChopping(movementInput, movementInput != Vector2.zero);
    }

    private void LockMovement()
    {
        canMove = false;
    }

    private void UnlockMovement()
    {
        canMove = true;
    }
}
    // save load feature

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
    }
}
