using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace RaveTown.Items
{

public interface ItemContainer
{
    ItemSlot AddItem(ItemSlot itemSlot); 

    void RemoveItem(ItemSlot itemSlot);
    void RemoveAt(int slotIndex);
    void Swap(int indexOne, int indexTwo);
    bool HasItem(InventoryItem item);
    int GetTotalQuantity(InventoryItem item);
     
}
}
