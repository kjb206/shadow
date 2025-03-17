using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image itemIcon;  // Reference to the slot's image
    public ItemData item;   // The current item in the slot

    // Adds an item to the slot
    public void AddItem(ItemData newItem)
    {
        item = newItem;

        if (itemIcon != null && item != null)
        {
            itemIcon.sprite = item.icon; // Assign the sprite
            itemIcon.enabled = true; // Make sure it's visible
        }
    }

    // Clears the slot (empty state)
    public void ClearSlot()
    {
        item = null;
        itemIcon.sprite = null;
        itemIcon.enabled = false; // Hide the icon when no item is assigned
    }
}
