using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private readonly List<string> items = new();

    public void AddItem(string itemName)
    {
        items.Add(itemName);

        Debug.Log($"아이템 획득: {itemName}");
        Debug.Log($"인벤토리 아이템 수: {items.Count}");
    }

    public IReadOnlyList<string> GetItems()
    {
        return items;
    }
}