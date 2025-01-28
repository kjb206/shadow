using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player's movement
    private Vector2 movement; // Stores player input
    private Rigidbody2D rb; // Reference to Rigidbody2D component
    private Animator animator; // Reference to Animator component

    private float lastMoveX = 0; // Stores the last MoveX direction
    private float lastMoveY = -1; // Default facing Down

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Capture raw input
        movement.x = Input.GetAxisRaw("Horizontal"); // Left/right input
        movement.y = Input.GetAxisRaw("Vertical");   // Up/down input

        // Normalize movement
        movement = movement.normalized;

        // Check if the player is moving
        bool isMoving = movement.magnitude > 0;

        // Update Animator parameters
        if (isMoving)
        {
            // Update direction parameters
            animator.SetFloat("MoveX", movement.x);
            animator.SetFloat("MoveY", movement.y);

            // Store the last direction
            lastMoveX = movement.x;
            lastMoveY = movement.y;
        }
        else
        {
            // When not moving, use the last direction
            animator.SetFloat("MoveX", lastMoveX);
            animator.SetFloat("MoveY", lastMoveY);
        }

        // Pause/Resume animation
        animator.speed = isMoving ? 1 : 0; // 1 for playing, 0 for pausing
    }

    void FixedUpdate()
    {
        // Apply movement to Rigidbody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}