using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuickSlotUI : MonoBehaviour, IDropHandler
{
    [SerializeField] private TextMeshProUGUI itemText;
    [SerializeField] private TextMeshProUGUI keyText;

    private int slotIndex;
    private QuickSlotManager manager;

    public void Initialize(int index, QuickSlotManager quickSlotManager)
    {
        slotIndex = index;
        manager = quickSlotManager;

        keyText.text = (index + 1).ToString();
        Clear();
    }

    public void SetItem(string itemName, int quantity)
    {
        itemText.text = $"{itemName}\n×{quantity}";
    }

    public void Clear()
    {
        itemText.text = "";
    }

    public void OnDrop(PointerEventData eventData)
    {
        string itemName = InventorySlotUI.DraggedItemName;

        if (string.IsNullOrEmpty(itemName))
            return;

        if (manager == null)
            return;

        manager.AssignItem(slotIndex, itemName);

        Debug.Log(
            $"퀵슬롯 {slotIndex + 1}에 {itemName} 등록"
        );
    }
}