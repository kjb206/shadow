using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorwayTransition : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // Name of the scene to load
    [SerializeField] private Vector3 spawnPosition; // Position to spawn the player in the new scene

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player triggered the door
        if (other.CompareTag("Player"))
        {
            // Store the player's spawn position for the next scene
            PlayerPrefs.SetFloat("SpawnX", spawnPosition.x);
            PlayerPrefs.SetFloat("SpawnY", spawnPosition.y);
            PlayerPrefs.SetFloat("SpawnZ", spawnPosition.z);

            // Load the target scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
