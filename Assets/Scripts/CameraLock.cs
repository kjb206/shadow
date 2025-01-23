using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The object the camera will follow
    public float smoothing = 5f; // Smoothing factor for camera movement

    private Vector3 offset; // Offset between the camera and target

    void Start()
    {
        // Calculate the initial offset
        if (target != null)
        {
            offset = transform.position - target.position;
        }
    }

    void FixedUpdate()
    {
        // Follow the target smoothly
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.fixedDeltaTime);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        if (target != null)
        {
            offset = transform.position - target.position;
        }
    }
}
