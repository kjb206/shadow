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

    private void Start()
    {
         // Restore player's position
    float spawnX = PlayerPrefs.GetFloat("SpawnX", transform.position.x);
    float spawnY = PlayerPrefs.GetFloat("SpawnY", transform.position.y);
    transform.position = new Vector2(spawnX, spawnY);

    // Restore player's direction
    float moveX = PlayerPrefs.GetFloat("MoveX", 0);
    float moveY = PlayerPrefs.GetFloat("MoveY", 0);

    // Find the Animator (even if it's on a child object)
    Animator animator = GetComponentInChildren<Animator>();
    
    if (animator != null)
    {
        animator.SetFloat("MoveX", moveX);
        animator.SetFloat("MoveY", moveY);
        Debug.Log($"Animator parameters restored: MoveX = {moveX}, MoveY = {moveY}");
    }
    else
    {
        Debug.LogError($"Animator not found on {gameObject.name} or its children!");
    }
}}
