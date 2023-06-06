using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Public variables
    [Range(1, 20)]
    public float speed;
    public float jumpVelocity;
    public float fallMultiplier = 2.5f;
    public float playerMass = 1f;

    // Private variables
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    private PlayerInputActions playerInputActions;
    private InputAction movement;
    [SerializeField]
    private LayerMask groundedLayerMask;
    private Vector2 moveVector;
    [SerializeField]
    private bool jumpCancelled = false;

    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        rb = gameObject.GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Cast ray from center of box collider. if collision occurs, you're grounded and can jump 
    private bool IsGrounded()
    {
        float extraHeight = 0.2f;
        RaycastHit2D hit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeight, groundedLayerMask);
        return hit.collider != null;
    }

    // Move player object given the move direction, using MovePlayer function
    private void FixedUpdate()
    {
        // If falling (vel.y < 0), multiply gravity by fall multiplier and add to move vector
        if (rb.velocity.y < 0)
        {
            moveVector += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        MovePlayer(moveVector);
    }    

    private void Update()
    {
        // Set moveVector according to "movement" 1D axis composite and current y velocity
        moveVector = new Vector2(movement.ReadValue<float>(), rb.velocity.y);
        GetComponent<Rigidbody2D>().mass = playerMass;
    }

    void MovePlayer(Vector2 moveVector)
    {
        rb.velocity = new Vector2(moveVector.x * speed, moveVector.y);
    }

    // Jump key is pressed, adding an upward burst of force
    private void OnJumpStarted(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            rb.velocity = Vector2.up * jumpVelocity;
            jumpCancelled = false;
        }
    }
    // Jump key is released in the air before jump apex, resulting in decreased jump height
    private void OnJumpCanceled(InputAction.CallbackContext context)
    {
        if (!IsGrounded() && !jumpCancelled)
        {
            // Cancel upward jump force
            rb.velocity = new Vector2(moveVector.x, 0f);
            jumpCancelled = true;
        }
    }

    // Enable and disable actions
    void OnEnable()
    {
        movement = playerInputActions.gameplay.move;
        movement.Enable();

        playerInputActions.gameplay.jump.started += OnJumpStarted;
        playerInputActions.gameplay.jump.canceled += OnJumpCanceled;
        playerInputActions.gameplay.jump.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
        playerInputActions.gameplay.jump.Disable();
    }
}
