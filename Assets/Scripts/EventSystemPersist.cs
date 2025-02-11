using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemPersist : MonoBehaviour
{
    private static EventSystemPersist instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
