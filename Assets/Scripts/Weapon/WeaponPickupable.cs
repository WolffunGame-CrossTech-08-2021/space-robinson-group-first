using System;
using Manager;
using UnityEngine;
using Weapon.Data;

namespace Weapon
{
    public class WeaponPickupable : MonoBehaviour
    {
        public BaseWeaponData weaponData;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Nhặt được vũ khí: " + weaponData.name);
            GameManager.Instance.heroEntity.ChangeWeapon(weaponData);
            Destroy(gameObject);
        }
    }
}
