using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of the player's movement
    private Vector2 movement; // Stores player input
    private Rigidbody2D rb; // Reference to Rigidbody2D component
    private Animator animator; // Reference to Animator component

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

        // Update Animator parameters
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
    }

    void FixedUpdate()
    {
        // Apply movement to Rigidbody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
