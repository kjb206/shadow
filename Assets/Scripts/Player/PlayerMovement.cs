using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Vector2 movement; 
    private Rigidbody2D rb; 
    private Animator animator; 

    private float lastMoveX = 0; 
    private float lastMoveY = -1; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical");  
        movement = movement.normalized;
        bool isMoving = movement.magnitude > 0;

        if (isMoving)
        {
            animator.SetFloat("MoveX", movement.x);
            animator.SetFloat("MoveY", movement.y);
            lastMoveX = movement.x;
            lastMoveY = movement.y;
        }
        else
        {
            animator.SetFloat("MoveX", lastMoveX);
            animator.SetFloat("MoveY", lastMoveY);
        }
        animator.speed = isMoving ? 1 : 0;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}