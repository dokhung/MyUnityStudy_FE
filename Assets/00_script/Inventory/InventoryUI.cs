using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("인벤토리")]
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private InventoryManager inventoryManager;

    [Header("슬롯")]
    [SerializeField] private Transform inventoryGrid;
    [SerializeField] private InventorySlotUI slotPrefab;
    [SerializeField] private int slotCount = 15;

    private readonly List<InventorySlotUI> slots = new();

    private bool isOpen = false;

    private void Start()
    {
        CreateSlots();
        inventoryPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    private void CreateSlots()
    {
        for (int i = 0; i < slotCount; i++)
        {
            InventorySlotUI slot = Instantiate(
                slotPrefab,
                inventoryGrid
            );

            slot.Clear();
            slots.Add(slot);
        }
    }

    private void ToggleInventory()
    {
        isOpen = !isOpen;
        inventoryPanel.SetActive(isOpen);

        if (isOpen)
        {
            RefreshInventory();
        }
    }

    private void RefreshInventory()
    {
        IReadOnlyList<InventorySlot> items =
            inventoryManager.GetItems();

        for (int i = 0; i < slots.Count; i++)
        {
            if (i < items.Count)
            {
                slots[i].SetItem(items[i]);
            }
            else
            {
                slots[i].Clear();
            }
        }
    }
}