using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")] 
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public string description;
    public ItemType itemType;
    public int attackBoost;
    public int defenseBoost;
    public int magicBoost;
    public int resistanceBoost;
    public int agilityBoost;
    public int luckBoost;
    public int critBonus; //1 = 1%
}
public enum ItemType
{
    Helmet,
    Body,
    Legs,
    Feet,
    Weapon,
    Accessory
}
