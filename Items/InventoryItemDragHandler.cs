using UnityEngine;
using UnityEngine.EventSystems;

namespace RaveTown.Items
{

public class InventoryItemDragHandler : ItemDragHandler
{
        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            if(eventData.hovered.Count == 0)
            {
                //destroy or drop item
            }
        }
    }
}
