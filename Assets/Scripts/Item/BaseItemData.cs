using UnityEngine;

namespace Item
{
    public abstract class BaseItemData : ScriptableObject
    {
        public Sprite icon;
        public ItemType type;
        [Range(0, 1)]
        public float dropRate = 1f;
    }
}
