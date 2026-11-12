using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler
{
    [SerializeField] private TextMeshProUGUI itemText;

    private InventorySlot currentItem;

    public static string DraggedItemName { get; private set; }

    public void SetItem(InventorySlot slot)
    {
        currentItem = slot;

        itemText.text =
            $"{slot.ItemName}\n× {slot.Quantity}";
    }

    public void Clear()
    {
        currentItem = null;
        itemText.text = "";
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (currentItem == null)
            return;

        DraggedItemName = currentItem.ItemName;

        Debug.Log($"드래그 시작: {DraggedItemName}");
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 드래그 중에는 아이템 정보를 유지
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DraggedItemName = null;
    }
}