using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Chest : MonoBehaviour
{
    public GameObject chestUIPanel; 
    public Transform chestSlotContainer; 
    public GameObject chestSlotPrefab; 
    public List<ItemData> chestItems = new List<ItemData>(); 

    private bool isOpen = false;

    void Start()
    {
        chestUIPanel.SetActive(false); 
        PopulateChest();
    }

    public void OpenChest()
    {
        isOpen = true;
        chestUIPanel.SetActive(true);

        FindFirstObjectByType<InventoryManager>().ToggleInventory(true);
    }

    public void CloseChest()
    {
        isOpen = false;
        chestUIPanel.SetActive(false);

        FindFirstObjectByType<InventoryManager>().ToggleInventory(false);
    }

    public void PopulateChest()
    {
        foreach (Transform child in chestSlotContainer)
        {
            Destroy(child.gameObject); 
        }
        foreach (ItemData item in chestItems)
        {
            GameObject slot = Instantiate(chestSlotPrefab, chestSlotContainer);
            slot.GetComponent<ChestSlot>().Initialize(item);
        }
    }
    public void TransferItemToInventory(ItemData item)
    {
        bool added = FindFirstObjectByType<InventoryManager>().AddItemToInventory(item);
        if (added)
        {
            chestItems.Remove(item);
            PopulateChest();
        }
    }
    public void StoreItemInChest(ItemData item)
    {
        chestItems.Add(item);
        PopulateChest();
    }
}
