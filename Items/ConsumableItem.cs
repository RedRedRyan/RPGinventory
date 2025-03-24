using System.Text;
using UnityEngine;

namespace RaveTown.Items
{
[CreateAssetMenu(fileName = "New Consumable item", menuName = "Items/Consumable Item")]
public class ConsumableItem : InventoryItem
{
        [Header("Consumable Data")]
        [SerializeField] private string useText = "Use";
        public override string GetInfoDisplayText()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Name).AppendLine();
            builder.Append("<color=green>").Append(useText).Append("</color>").AppendLine();
            builder.Append("Sell Price: ").Append(SellPrice).Append("Gold");
            builder.Append("Max Stack: ").Append(MaxStack).AppendLine();

            return builder.ToString();
        }
    }
}
