using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventorySlotPrefab; 
    public GameObject inventoryPanel;     
    public GameObject itemPrefab;
    public List<ItemData> availableItems;

    private int inventoryWidth = 5; 
    private int inventoryHeight = 6; 
    private InventorySlot[,] inventoryGrid; // 2D grid for slots

    void Start()
    {
        GenerateInventoryGrid();
    }

    void GenerateInventoryGrid()
    {
        inventoryGrid = new InventorySlot[inventoryWidth, inventoryHeight];
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }
        for (int y = 0; y < inventoryHeight; y++)
        {
            for (int x = 0; x < inventoryWidth; x++)
            {
                GameObject slot = Instantiate(inventorySlotPrefab, inventoryPanel.transform);
                InventorySlot slotComponent = slot.GetComponent<InventorySlot>();
               // slotComponent.SetGridPosition(x, y);
                inventoryGrid[x, y] = slotComponent;
            }
        }
    }

    public bool AddItemToInventory(ItemData itemData)
    {
        for (int y = 0; y < inventoryHeight; y++) // Iterate rows
        {
            for (int x = 0; x < inventoryWidth; x++) // Iterate columns
            {
              //  if (!inventoryGrid[x, y].IsOccupied)
              //  {
              //      PlaceItem(itemData, x, y);
              //      return true;
              //  }
            }
        }
        return false; // No available space
    }

    private void PlaceItem(ItemData itemData, int x, int y)
    {
        GameObject newItem = Instantiate(itemPrefab, inventoryPanel.transform);
        Image itemImage = newItem.GetComponent<Image>();

        itemImage.sprite = itemData.icon;
        newItem.transform.SetParent(inventoryGrid[x, y].transform);
        newItem.transform.localPosition = Vector3.zero;

        //inventoryGrid[x, y].SetOccupied(true, newItem);
    }
    public void ToggleInventory(bool isOpen)
    {
        inventoryPanel.SetActive(isOpen);
    }
}
