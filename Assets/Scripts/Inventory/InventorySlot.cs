using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image itemIcon;
    public ItemData item;

    void Start()
    {
        Debug.Log("InventorySlot Script is Running on: " + gameObject.name);

        if (item != null)
        {
            Debug.Log("Auto-Assigning item in Start(): " + item.itemName);
            AddItem(item);
        }
    }

    public void AddItem(ItemData newItem)
{
    item = newItem;

    Debug.Log("🔍 AddItem() called - Item: " + (item != null ? item.itemName : "NULL"));

    if (itemIcon != null)
    {
        if (item != null)
        {
            if (item.icon != null)
            {
                Debug.Log("✅ Setting sprite for: " + item.itemName);
                itemIcon.sprite = item.icon;  
                itemIcon.enabled = true; 
                itemIcon.gameObject.SetActive(true);  
                Debug.Log("✅ ItemIcon should now be visible!");
            }
            else
            {
                Debug.LogWarning("❌ item.icon is NULL for: " + item.itemName);
            }
        }
        else
        {
            Debug.LogWarning("❌ item is NULL when calling AddItem()");
        }
    }
    else
    {
        Debug.LogWarning("❌ itemIcon is NULL in InventorySlot");
    }
}


    public void ClearSlot()
    {
        item = null;
        itemIcon.sprite = null;
        itemIcon.enabled = false;
        Debug.Log("Slot cleared");
    }
}
