using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI itemListText;
    [SerializeField] private InventoryManager inventoryManager;

    private bool isOpen = false;

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
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
        IReadOnlyList<string> items = inventoryManager.GetItems();

        if (items.Count == 0)
        {
            itemListText.text = "인벤토리가 비어 있습니다.";
            return;
        }

        itemListText.text = "";

        foreach (string item in items)
        {
            itemListText.text += item + "\n";
        }
    }
}