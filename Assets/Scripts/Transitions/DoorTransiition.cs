using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorwayTransition : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private Vector3 spawnPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetFloat("SpawnX", spawnPosition.x);
            PlayerPrefs.SetFloat("SpawnY", spawnPosition.y);
            PlayerPrefs.SetFloat("SpawnZ", spawnPosition.z);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
{
    float x = PlayerPrefs.GetFloat("SpawnX", 0);
    float y = PlayerPrefs.GetFloat("SpawnY", 0);

    Transform player = GameObject.FindGameObjectWithTag("Player").transform;
    player.position = new Vector3(x, y, 0);

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
