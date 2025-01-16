using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Assign the player object in the inspector
    public float smoothSpeed = 0.125f;
    public Vector3 offset; // Adjust the offset to control camera positioning

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        desiredPosition.z = -10;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Optional: Lock camera rotation
        transform.rotation = Quaternion.identity;
    }
}
