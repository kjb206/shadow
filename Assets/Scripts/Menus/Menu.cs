using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Press ESC to toggle menu
        {
            if (isPaused)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
    }

    public void OpenMenu()
    {
        isPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pause game time
    }

    public void CloseMenu()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume game time
    }

    public void OpenInventory()
    {
        Debug.Log("Opening Inventory (Placeholder)");
        // Implement inventory system here
    }

    public void OpenStat()
    {
        Debug.Log("Opening Stat (Placeholder)");
        // Implement inventory system here
    }
    public void OpenSettings()
    {
        Debug.Log("Opening Settings (Placeholder)");
        // Implement settings menu here
    }

    public void QuitToMainMenu()
    {
        Debug.Log("Returning to Main Menu (Placeholder)");
        // Implement scene transition to Main Menu later
    }
}
