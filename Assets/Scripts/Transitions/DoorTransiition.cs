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
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
{
    // Retrieve spawn position
    float x = PlayerPrefs.GetFloat("SpawnX", 0);
    float y = PlayerPrefs.GetFloat("SpawnY", 0);

    // Reposition the player
    Transform player = GameObject.FindGameObjectWithTag("Player").transform;
    player.position = new Vector3(x, y, 0);

    // Re-align the camera
    Camera.main.transform.position = player.position + new Vector3(0, 0, -10);
}

private void OnEnable()
{
    SceneManager.sceneLoaded += OnSceneLoaded;
}

private void OnDisable()
{
    SceneManager.sceneLoaded -= OnSceneLoaded;
}

}
