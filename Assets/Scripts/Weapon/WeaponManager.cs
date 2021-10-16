using System;
using System.Collections.Generic;
using Manager;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Weapon.Data;

namespace Weapon
{
    public class WeaponManager : Singleton<WeaponManager>
    {
        [SerializeField]
        private List<BaseWeaponData> weapons;

        private int _currentWeaponIndex;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
                ChangeWeapon();
        }

        private void ChangeWeapon()
        {
            var weapon = weapons[(_currentWeaponIndex + 1) % weapons.Count];
            GameManager.Instance.heroEntity.ChangeWeapon(weapon);
            _currentWeaponIndex++;
        }
    }
}
