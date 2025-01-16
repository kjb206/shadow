using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Assign the player object in the Inspector
    public float smoothSpeed = 0.125f;
    public Vector3 offset; // Adjust the offset to control camera positioning

    void Start()
    {
        // Set the camera's position to the player's position immediately
        if (player != null)
        {
            Vector3 startPosition = player.position + offset;
            startPosition.z = -10; // Ensure the Z-position is correct
            transform.position = startPosition;
        }
        else
        {
            Debug.LogError("Player not assigned in CameraFollow script!");
        }
    }

    void LateUpdate()
    {
        // Smoothly follow the player
        if (player != null)
        {
            Vector3 desiredPosition = player.position + offset;
            desiredPosition.z = -10; // Lock the Z-position for 2D
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
