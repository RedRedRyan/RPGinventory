using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RaveTown.Items

//Item Container
{
    [Serializable]
    public class ItContainer : ItemContainer
    {
        private ItemSlot[] itemSlots = new ItemSlot[0];
        public Action OnItemsUpdated=  delegate{}; 
        public ItContainer (int size)=> itemSlots = new ItemSlot[size];
        public ItemSlot GetSlotByIndex(int index) => itemSlots[index];

#region ADD ITEM
        public ItemSlot AddItem(ItemSlot itemSlot)
        {
          for(int i = 0; i < itemSlots.Length; i++)
          {
              if(itemSlots[i].item != null)
              {
                  if(itemSlots[i] == itemSlot)
                  {
                    int SlotRemainingSpace = itemSlots[i].item.MaxStack - itemSlots[i].quantity;
                    if(itemSlot.quantity <= SlotRemainingSpace)
                    {
                        itemSlots[i].quantity += itemSlot.quantity;
                        itemSlot.quantity   = 0;
                        OnItemsUpdated.Invoke();

                        return itemSlot;
                    }
                    else if (SlotRemainingSpace > 0)
                    {
                        itemSlots[i].quantity += SlotRemainingSpace;
                        itemSlot.quantity -= SlotRemainingSpace;
                    }
                  }

              }
          }
          for (int i = 0; i < itemSlots.Length; i++)
          {
              if(itemSlots[i].item == null)
              {
                  if(itemSlot.quantity <= itemSlot.item.MaxStack)
                  {
                      itemSlots[i] = itemSlot;
                      itemSlot.quantity = 0;
                      OnItemsUpdated.Invoke();


                      return itemSlot;
                  }
                  else
                  {
                      itemSlots[i] = new ItemSlot(itemSlot.item, itemSlot.item.MaxStack);
                      itemSlot.quantity -= itemSlot.item.MaxStack;
                  }
              }
          }
          OnItemsUpdated.Invoke();
          return itemSlot;
        }
#endregion
#region GetTotalQuantity
        public int GetTotalQuantity(InventoryItem item)
        {
            int totalCount = 0;
            foreach (ItemSlot itemSlot in itemSlots)
            {
                if (itemSlot.item == null){continue;}
                if (itemSlot.item != item){continue;}
                totalCount += itemSlot.quantity;
                
            }
            return totalCount;
        }
#endregion
#region HasItem

        public bool HasItem(InventoryItem item)
        {
            foreach (ItemSlot itemSlot in itemSlots)
            {
                if (itemSlot.item == null){continue;}
                if (itemSlot.item != item){continue;}
                return true;
            }
            return false;
        }
#endregion

#region RemoveAt

        public void RemoveAt(int slotIndex)
        {
            if(slotIndex<0||slotIndex>=itemSlots.Length){return;}
            itemSlots[slotIndex] = new ItemSlot();

            OnItemsUpdated.Invoke();
        }
#endregion

#region RemoveItem

        public void RemoveItem(ItemSlot itemSlot)
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if(itemSlots[i].item != null)
                {
                    if(itemSlots[i].item == itemSlot.item)
                    {
                        if(itemSlots[i].quantity < itemSlot.quantity)
                        {
                            itemSlot.quantity -= itemSlots[i].quantity;
                            itemSlots[i]= new ItemSlot();
                        }
                        else
                        {
                            itemSlots[i].quantity -= itemSlot.quantity;
                            if(itemSlots[i].quantity == 0)
                            {
                                itemSlots[i] = new ItemSlot();
                                OnItemsUpdated.Invoke();

                                return;
                            }
                        }
                    }
                } 
            }
        }
#endregion

#region Swap

        public void Swap(int indexOne, int indexTwo)
        {
            ItemSlot firstSlot = itemSlots[indexOne];
            ItemSlot secondSlot = itemSlots[indexTwo];

            if(firstSlot == secondSlot){return;}
            if(secondSlot.item != null)
            {
                if(firstSlot.item == secondSlot.item)
                {
                    int secondSlotRemainingSpace = secondSlot.item.MaxStack - secondSlot.quantity;
                    if(firstSlot.quantity <= secondSlotRemainingSpace)
                    {
                        itemSlots[indexTwo].quantity += firstSlot.quantity;
                        itemSlots[indexOne] = new ItemSlot();
                        OnItemsUpdated.Invoke();
                        return;

                        
                    }
                }
            }
            itemSlots[indexOne] = secondSlot;
            itemSlots[indexTwo] = firstSlot;
            OnItemsUpdated.Invoke();
        }
#endregion
    }
}
