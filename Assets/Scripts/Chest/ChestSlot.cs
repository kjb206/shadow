using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChestSlot : MonoBehaviour, IDropHandler
{
    public Image itemIcon;
    private ItemData itemData;
    private Chest chest;

    public void Initialize(ItemData item)
    {
        itemData = item;
        itemIcon.sprite = item.icon;
        chest = FindFirstObjectByType<Chest>();
    }

    public void OnClick()
    {
        chest.TransferItemToInventory(itemData);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DraggableItem draggedItem = eventData.pointerDrag.GetComponent<DraggableItem>();
            if (draggedItem != null)
            {
                chest.StoreItemInChest(draggedItem.GetItemData());
                Destroy(eventData.pointerDrag);
            }
        }
    }
}
