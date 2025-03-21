using UnityEngine;
using RaveTown.Events;

namespace RaveTown.Items
{
[CreateAssetMenu(fileName = "New Inventory", menuName = "Items/Inventory")]
    public class Inventory : ScriptableObject
    {
        
        [SerializeField] private VoidEvent onInventoryItemsUpdated = null;
        public ItContainer ItContainer { get;} = new ItContainer(9);
        public void OnEnable() => ItContainer.OnItemsUpdated += onInventoryItemsUpdated.Raise;
        public void OnDisable() => ItContainer.OnItemsUpdated -= onInventoryItemsUpdated.Raise;
    }

}
