using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryDragManager : MonoBehaviour
{
    public static InventoryDragManager Instance;
    public RectTransform inventoryPanelBounds;

    [Header("UI References")]
    public Image dragIcon; 
    public RectTransform canvasTransform;
    public GameObject itemTossPanel;
    public TMP_Text tossPromptText;

    [HideInInspector] public InventorySlot CurrentSlot;
    private ItemData draggedItem;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        dragIcon.gameObject.SetActive(false);
    }

    public void BeginDrag(InventorySlot fromSlot, Sprite iconSprite)
    {
        CurrentSlot = fromSlot;
        draggedItem = fromSlot.item;

        dragIcon.sprite = iconSprite;
        dragIcon.raycastTarget = false;
        dragIcon.gameObject.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragIcon.transform.position = Input.mousePosition;
    }

    public void EndDrag()
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(inventoryPanelBounds, Input.mousePosition))
{
    ShowTossPrompt(draggedItem);
}


        draggedItem = null;
        CurrentSlot = null;
    }

    private void ShowTossPrompt(ItemData item)
    {
        itemTossPanel.SetActive(true);
        tossPromptText.text = $"Toss {item.itemName}?";
    }
    public void CancelToss()
{
    itemTossPanel.SetActive(false);
    draggedItem = null;
    CurrentSlot = null;
}
public void ConfirmToss()
{
    if (CurrentSlot != null)
    {
        CurrentSlot.ClearSlot();
    }

    itemTossPanel.SetActive(false);
    draggedItem = null;
    CurrentSlot = null;
}

}
