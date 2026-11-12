using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private readonly List<InventorySlot> items = new();

    public void AddItem(string itemName)
    {
        InventorySlot slot = items.Find(
            item => item.ItemName == itemName
        );

        if (slot != null)
        {
            slot.AddQuantity(1);
        }
        else
        {
            items.Add(new InventorySlot(itemName, 1));
        }

        Debug.Log($"아이템 획득: {itemName}");
    }

    public IReadOnlyList<InventorySlot> GetItems()
    {
        return items;
    }
    
    
    public bool UseItem(string itemName)
    {
        InventorySlot slot = items.Find(
            item => item.ItemName == itemName
        );

        if (slot == null || slot.Quantity <= 0)
            return false;

        slot.RemoveQuantity(1);

        if (slot.Quantity == 0)
            items.Remove(slot);

        Debug.Log($"아이템 사용: {itemName}");

        return true;
    }

}