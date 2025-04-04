using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace RaveTown.Items
{
    public abstract class HotbarItem : ScriptableObject
    {
        [Header("Basic Info")]
        [SerializeField] private new string name = "New Hotbar Item Name";
        [SerializeField] private Sprite icon = null;

        public string Name => name;
        public abstract string ColouredName { get; }
        public Sprite Icon => icon;
        public abstract string GetInfoDisplayText();
    }
}

// [CreateAssetMenu(fileName = "HotbarItem", menuName = "Scriptable Objects/HotbarItem")]



