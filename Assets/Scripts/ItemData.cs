using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")] // Create a new item in the Unity Editor (automated comment)
// Creates a new option in right click menu in Unity Editor to create a new item
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public string description;
    public ItemType itemType;
    public Vector2Int size;
    public int attackBoost;
    public int defenseBoost;
    public int magicBoost;
    public int resistanceBoost;
    public int agilityBoost;
    public int luckBoost;
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
