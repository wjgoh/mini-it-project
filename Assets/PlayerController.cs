using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IDataPersistence
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public AxeChopping axeChopping;
    public Hoe hoeDirt;
    public Watering watering;

    Vector2 movementInput;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    bool canMove = true;
    private ToolType currentTool = ToolType.None; // The current selected tool


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
        if (currentTool == ToolType.Axe)
        {
            animator.SetTrigger("Chop");
            HandleAxeChopping();
        }
        else if (currentTool == ToolType.Hoe)
        {
            animator.SetTrigger("Hoe");
            HandleHoeDirt();
        }
        else if (currentTool == ToolType.Watering)
        {
            animator.SetTrigger("Water");
            HandleWatering();
        }
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

    public void ControlHoeDirt(Vector2 movement, bool moving)
    {
        LockMovement();

        SetAnimationParameters(movement, moving);

        if (moving)
        {
            if (movement.x > 0)
            {
                hoeDirt.HoeRight();
            }
            else if (movement.x < 0)
            {
                hoeDirt.HoeLeft();
            }
            else if (movement.y > 0)
            {
                hoeDirt.HoeUp();
            }
            else if (movement.y < 0)
            {
                hoeDirt.HoeDown();
            }
        }
        else
        {
            hoeDirt.StopHoe();
        }

        UnlockMovement();
    }

    public void ControlWatering(Vector2 movement, bool moving)
    {
        LockMovement();

        SetAnimationParameters(movement, moving);

        if (moving)
        {
            if (movement.x > 0)
            {
                watering.WateringRight();
            }
            else if (movement.x < 0)
            {
                watering.WateringLeft();
            }
            else if (movement.y > 0)
            {
                watering.WateringUp();
            }
            else if (movement.y < 0)
            {
                watering.WateringDown();
            }
        }
        else
        {
            watering.StopWatering();
        }

        UnlockMovement();
    }

    public void HandleAxeChopping()
    {
        ControlAxeChopping(movementInput, movementInput != Vector2.zero);
    }

    public void HandleHoeDirt()
    {
        ControlHoeDirt(movementInput, movementInput != Vector2.zero);
    }

    public void HandleWatering()
    {
        ControlWatering(movementInput, movementInput != Vector2.zero);
    }

    private void LockMovement()
    {
        canMove = false;
    }

    private void UnlockMovement()
    {
        canMove = true;
    }

    public void SetCurrentTool(ToolType tool)
    {
        currentTool = tool;
    }

    // Save/load feature
    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
    }
}

public enum ToolType
{
    None,
    Axe,
    Hoe,
    Watering
}
