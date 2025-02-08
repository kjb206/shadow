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
    bool isActive = gameObject.activeSelf;
    gameObject.SetActive(!isActive);

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
