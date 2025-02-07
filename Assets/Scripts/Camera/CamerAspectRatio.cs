using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraAspectRatio : MonoBehaviour
{
    public float targetAspect = 16f / 9f; // Change this to your desired aspect ratio (e.g., 4f/3f for 4:3)

    void Start()
    {
        Camera cam = GetComponent<Camera>();

        // Calculate the target aspect ratio
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = screenAspect / targetAspect;

        // If screen is wider than the target, apply pillarboxing
        if (scaleHeight < 1.0f)
        {
            Rect rect = cam.rect;
            rect.width = scaleHeight;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleHeight) / 2.0f;
            rect.y = 0.0f;
            cam.rect = rect;
        }
        // If screen is narrower than the target, apply letterboxing
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = cam.rect;
            rect.width = 1.0f;
            rect.height = scaleWidth;
            rect.x = 0.0f;
            rect.y = (1.0f - scaleWidth) / 2.0f;
            cam.rect = rect;
        }
    }
}
