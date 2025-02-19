using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public int gridX, gridY;
    private GameObject occupyingItem;

    public bool IsOccupied => occupyingItem != null;
    public void SetGridPosition(int x, int y)
    {
        gridX = x;
        gridY = y;
    }
    public void SetOccupied(bool occupied, GameObject item)
    {
        occupyingItem = occupied ? item : null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!IsOccupied && eventData.pointerDrag != null)
        {
            occupyingItem = eventData.pointerDrag;
            occupyingItem.transform.SetParent(transform);
            occupyingItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }

    public void ClearSlot()
    {
        occupyingItem = null;
    }
}
