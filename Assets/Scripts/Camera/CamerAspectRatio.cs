using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraAspectRatio : MonoBehaviour
{
    public float targetAspect = 16f / 9f; // 4f/3f for 4:3, 16f/9f for 16:9, 16f/10f for 16:10
    void Start()
    {
        Camera cam = GetComponent<Camera>();
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = screenAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            cam.rect = new Rect((1.0f - scaleHeight) / 2.0f, 0.0f, scaleHeight, 1.0f);
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            cam.rect = new Rect(0.0f, (1.0f - scaleWidth) / 2.0f, 1.0f, scaleWidth);
        }
    }
}
