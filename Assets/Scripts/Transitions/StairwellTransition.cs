using UnityEngine;
using UnityEngine.SceneManagement;

public class StairwellTransition : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; 
    [SerializeField] private Vector2 spawnPosition;  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetFloat("SpawnX", spawnPosition.x);
            PlayerPrefs.SetFloat("SpawnY", spawnPosition.y);
            FlipPlayerDirection(other);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
    private void FlipPlayerDirection(Collider2D player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            Animator animator = player.GetComponent<Animator>();
            if (animator != null)
            {
                // Get the current direction from the Animator
                float moveX = animator.GetFloat("MoveX");
                float moveY = animator.GetFloat("MoveY");

                // Flip the direction
                animator.SetFloat("MoveX", -moveX);
                animator.SetFloat("MoveY", -moveY);

                Debug.Log($"Flipped Player Direction: MoveX = {-moveX}, MoveY = {-moveY}");
            }
            else
            {
                Debug.LogError("Animator component not found on the Player GameObject!");
            }
        }
        else
        {
            Debug.LogError("PlayerMovement script not found on the Player GameObject!");
        }
    }
}
