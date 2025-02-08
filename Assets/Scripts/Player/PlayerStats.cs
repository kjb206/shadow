using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int level = 1;
    public int exp = 0;
    public int maxHP = 100;
    public int currentHP;
    public int maxMP = 50;
    public int currentMP;
    public int strength = 10;
    public int defense = 5;
    public int magic = 8;
    public int resistance = 4;
    public int agility = 7;
    public int luck = 5;

    void Start()
    {
        // Initialize HP and MP at max values
        currentHP = maxHP;
        currentMP = maxMP;
    }
    public void TakeDamage(int damage)
    {
        int damageTaken = Mathf.Max(damage - defense, 1); // Minimum damage is 1
        currentHP -= damageTaken;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
    }
    public void Heal(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
    }

    public bool UseMP(int amount)
    {
        if (currentMP >= amount)
        {
            currentMP -= amount;
            return true; // Successfully used MP
        }
        return false; // Not enough MP
    }
    public void GainEXP(int amount)
    {
        exp += amount;
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        int expThreshold = level * 100; 
        while (exp >= expThreshold)
        {
            exp -= expThreshold;
            LevelUp();
            expThreshold = level * 100;
        }
    }

    private void LevelUp()
    {
        level++;
        maxHP += 10;
        maxMP += 5;        
        // Random stat boosts every 5 levels
        if (level % 5 == 0)
        {
            ApplyRandomStatBoost();
        }
        else
        {
            strength += 2;
            defense += 2;
            magic += 2;
            resistance += 1;
            agility += 1;
            luck += 1;
        }    
        // Restore HP and MP upon leveling up
        currentHP = maxHP;
        currentMP = maxMP;
    }

    private void ApplyRandomStatBoost()
    {
        int bonusPoints = 5; // Number of bonus stat points to distribute
        for (int i = 0; i < bonusPoints; i++)
        {
            int randomStat = Random.Range(0, 6); // 6 possible stats
            switch (randomStat)
            {
                case 0: strength += 1; break;
                case 1: defense += 1; break;
                case 2: magic += 1; break;
                case 3: resistance += 1; break;
                case 4: agility += 1; break;
                case 5: luck += 1; break;
            }
        }
    }
}
