using UnityEngine;
using System.Collections.Generic;
public class PersistenceManager : MonoBehaviour
{
    private static HashSet<string> persistentObjects = new HashSet<string>();

    void Awake()
    {
        // Ensure only one instance of each object persists
        if (!persistentObjects.Contains(gameObject.name))
        {
            persistentObjects.Add(gameObject.name);
            DontDestroyOnLoad(gameObject);
            Debug.Log($"{gameObject.name} is now persistent.");
        }
        else
        {
            Debug.Log($"Destroying duplicate {gameObject.name}.");
            Destroy(gameObject);
        }
    }
}
