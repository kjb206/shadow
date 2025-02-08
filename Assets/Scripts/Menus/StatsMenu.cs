using UnityEngine;
using UnityEngine.UI;
using TMPro; // For TextMeshPro

public class StatsMenu : MonoBehaviour
{
    public TextMeshProUGUI hpText, mpText, strengthText, defenseText, magicText, resistanceText, agilityText, luckText, levelText, expText;
    private PlayerStats playerStats;

    void Start()
    {
        // Find PlayerStats on the Player GameObject
        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        UpdateStats();
    }

    public void UpdateStats()
    {
        // Update the text elements with the player's current stats
        hpText.text = "HP: " + playerStats.currentHP + "/" + playerStats.maxHP;
        mpText.text = "MP: " + playerStats.currentMP + "/" + playerStats.maxMP;
        strengthText.text = "Strength: " + playerStats.strength;
        defenseText.text = "Defense: " + playerStats.defense;
        magicText.text = "Magic: " + playerStats.magic;
        resistanceText.text = "Resistance: " + playerStats.resistance;
        agilityText.text = "Agility: " + playerStats.agility;
        luckText.text = "Luck: " + playerStats.luck;
        levelText.text = "Level: " + playerStats.level;
        expText.text = "EXP: " + playerStats.exp;
    }

    public void ToggleStatsMenu()
{
    // Toggle the visibility of the Stats menu
    bool isActive = gameObject.activeSelf;
    gameObject.SetActive(!isActive);

    // If closing the Stats menu, ensure Pause Menu is visible
    if (!isActive)
    {
        GameObject pauseMenu = GameObject.Find("PauseMenuPanel");
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }
    }
}
}
