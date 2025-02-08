using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    void Awake()
    {
        // Check if an instance already exists to prevent duplicates
        if (Object.FindObjectsByType<DontDestroyOnLoad>(FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject); // Destroy duplicate canvas
            return;
        }

        // Make this object persistent
        DontDestroyOnLoad(gameObject);
    }
}
