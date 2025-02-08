using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5f;
    public Vector3 offset = new Vector3(0, -5, -10);

    void Start()
    {
        if (player == null) 
        {
            FindPlayer();
        }
    }
    void LateUpdate()
    {
        if (player == null) return;

        Vector3 desiredPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
    void Awake()
    {
        if (Object.FindObjectsByType(GetType(), FindObjectsSortMode.None).Length > 1)
        {
           Destroy(gameObject); // Destroy duplicate instance
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }
    
}