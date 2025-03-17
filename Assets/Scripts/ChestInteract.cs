using UnityEngine;

public class ChestInteract : MonoBehaviour
{
    private Chest chest;
    private bool isPlayerNearby = false;

    void Start()
    {
        chest = GetComponent<Chest>();
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.Space))
        {
            chest.OpenChest();
        }
    }

    void OnTriggerEnter2D(Collider2D other) // ✅ Changed to 2D version
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) // ✅ Changed to 2D version
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
