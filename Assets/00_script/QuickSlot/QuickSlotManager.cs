
using System.Collections.Generic;
using UnityEngine;

public class QuickSlotManager : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private Transform quickSlotBar;
    [SerializeField] private QuickSlotUI slotPrefab;

    private readonly List<QuickSlotUI> slotUIs = new();

    private readonly string[] assignedItems = new string[5];

    private void Start()
    {
        for (int i = 0; i < assignedItems.Length; i++)
        {
            QuickSlotUI slot = Instantiate(
                slotPrefab,
                quickSlotBar
            );

            slot.Initialize(i, this);
            slotUIs.Add(slot);
        }

        RefreshSlots();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            UseSlot(0);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            UseSlot(1);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            UseSlot(2);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            UseSlot(3);

        if (Input.GetKeyDown(KeyCode.Alpha5))
            UseSlot(4);

        RefreshSlots();
    }

    public void AssignItem(int index, string itemName)
    {
        if (index < 0 || index >= assignedItems.Length)
            return;

        IReadOnlyList<InventorySlot> items =
            inventoryManager.GetItems();

        foreach (InventorySlot item in items)
        {
            if (item.ItemName == itemName && item.Quantity > 0)
            {
                assignedItems[index] = itemName;
                RefreshSlots();
                return;
            }
        }
    }

    private void UseSlot(int index)
    {
        string itemName = assignedItems[index];

        if (string.IsNullOrEmpty(itemName))
            return;

        bool used = inventoryManager.UseItem(itemName);

        if (used)
        {
            Debug.Log(
                $"퀵슬롯 {index + 1} 사용: {itemName}"
            );
        }

        RefreshSlots();
    }

    private void RefreshSlots()
    {
        IReadOnlyList<InventorySlot> items =
            inventoryManager.GetItems();

        for (int i = 0; i < slotUIs.Count; i++)
        {
            string assignedName = assignedItems[i];

            InventorySlot foundItem = null;

            foreach (InventorySlot item in items)
            {
                if (item.ItemName == assignedName)
                {
                    foundItem = item;
                    break;
                }
            }

            if (foundItem != null && foundItem.Quantity > 0)
            {
                slotUIs[i].SetItem(
                    foundItem.ItemName,
                    foundItem.Quantity
                );
            }
            else
            {
                slotUIs[i].Clear();
            }
        }
    }
}
