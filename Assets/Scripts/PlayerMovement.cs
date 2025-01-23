using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player's movement

    private Vector2 movement; // Stores player input
    private Rigidbody2D rb; // Reference to Rigidbody2D component
    private Animator animator; // Reference to Animator component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get Rigidbody2D
        animator = GetComponent<Animator>(); // Get Animator
    }

    void Update()
    {
        // Capture raw input
        movement.x = Input.GetAxisRaw("Horizontal"); // Left/right input
        movement.y = Input.GetAxisRaw("Vertical");   // Up/down input

        // Normalize movement to maintain consistent speed for diagonals
        movement = movement.normalized;

        // Determine if the player is moving
        bool isMoving = movement.magnitude > 0;

        // Handle diagonal movement
        if (movement.x != 0 && movement.y != 0) // Diagonal movement
        {
            if (movement.x < 0 && movement.y > 0) // NW
            {
                animator.SetFloat("MoveX", -1);
                animator.SetFloat("MoveY", 1);
                animator.SetInteger("isDiagonal", 2); // NW quadrant
            }
            else if (movement.x > 0 && movement.y > 0) // NE
            {
                animator.SetFloat("MoveX", 1);
                animator.SetFloat("MoveY", 1);
                animator.SetInteger("isDiagonal", 1); // NE quadrant
            }
            else if (movement.x < 0 && movement.y < 0) // SW
            {
                animator.SetFloat("MoveX", -1);
                animator.SetFloat("MoveY", -1);
                animator.SetInteger("isDiagonal", 3); // SW quadrant
            }
            else if (movement.x > 0 && movement.y < 0) // SE
            {
                animator.SetFloat("MoveX", 1);
                animator.SetFloat("MoveY", -1);
                animator.SetInteger("isDiagonal", 4); // SE quadrant
            }
        }
        else // Cardinal directions
        {
            animator.SetFloat("MoveX", movement.x);
            animator.SetFloat("MoveY", movement.y);
            animator.SetInteger("isDiagonal", 0); // Not diagonal
        }

        // Update Animator's IsMoving parameter
        animator.SetBool("IsMoving", isMoving);
    }

    void FixedUpdate()
    {
        // Apply movement to Rigidbody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

