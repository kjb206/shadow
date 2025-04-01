using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Image itemIcon;
    public ItemData item;

    private Transform originalParent;
    private CanvasGroup canvasGroup;

    void Start()
    {
        if (item != null)
            AddItem(item);

        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    public void AddItem(ItemData newItem)
    {
        item = newItem;
        if (item != null && item.icon != null)
        {
            itemIcon.sprite = item.icon;
            itemIcon.enabled = true;
            itemIcon.gameObject.SetActive(true);
        }
    }

    public void ClearSlot()
    {
        item = null;
        itemIcon.sprite = null;
        itemIcon.enabled = false;
        itemIcon.gameObject.SetActive(false);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item == null) return;

        InventoryDragManager.Instance.BeginDrag(this, itemIcon.sprite);
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (InventoryDragManager.Instance != null)
            InventoryDragManager.Instance.OnDrag(eventData);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        InventoryDragManager.Instance.EndDrag();
    }
    public void OnDrop(PointerEventData eventData)
    {
        InventorySlot sourceSlot = InventoryDragManager.Instance.CurrentSlot;
        if (sourceSlot == this) return;

        ItemData temp = item;
        AddItem(sourceSlot.item);
        sourceSlot.AddItem(temp);
    }
}
