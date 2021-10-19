using System;
using UnityEngine;
using Weapon.Data;

namespace Item
{
    [CreateAssetMenu(menuName = "Items/Weapon")]
    public class WeaponItemData : BaseItemData
    {
        public BaseWeaponData data;

        private void OnValidate()
        {
            // Cast type to weapon
            type = ItemType.Weapon;
        }
    }
}
