using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventorySlot
{
    public string ItemName
    {
        get; private set;
    }
    
    public int Quantity
    {
        get; private set;
    }

    public InventorySlot(string itemName, int quantity)
    {
        ItemName = itemName;
        Quantity = quantity;
    }
    
    public void AddQuantity(int amount)
    {
        Quantity += amount;
    }
    
    
    public void RemoveQuantity(int amount)
    {
        Quantity = System.Math.Max(0, Quantity - amount);
    }

}
