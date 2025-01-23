using UnityEngine;

public class PlayerPersistence : MonoBehaviour
{
    private static PlayerPersistence instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps the player object alive between scenes
        }
        else
        {
            Destroy(gameObject); // Prevents duplicate players in new scenes
        }
    }
}
