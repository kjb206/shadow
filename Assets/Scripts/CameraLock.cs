using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float smoothSpeed = 5f; // Smooth follow speed
    public Vector3 offset = new Vector3(0, -5, -10); // Offset from the player's position

    void LateUpdate()
    {
        if (player == null)
        {
            // Attempt to find the player dynamically if the reference is missing
            GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");
            if (foundPlayer != null)
            {
                player = foundPlayer.transform;
            }
        }

        if (player != null)
        {
            // Smoothly follow the player
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = desiredPosition;
        }
    }
}
