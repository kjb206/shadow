using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform originalParent;
    private Vector2 originalPosition;
    private ItemData itemData;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalParent = transform.parent;
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        Transform newParent = transform.parent;

        if (newParent == transform.root) 
        {
            transform.SetParent(originalParent);
            rectTransform.anchoredPosition = originalPosition;
        }
        else
        {
            originalParent.GetComponent<InventorySlot>()?.ClearSlot(); // Ensure old slot is cleared
        }
    }
    public ItemData GetItemData()
    {
        
        return itemData;
    }
    
    public void Initialize(ItemData newItem)
    {
        itemData = newItem;
    }
}
