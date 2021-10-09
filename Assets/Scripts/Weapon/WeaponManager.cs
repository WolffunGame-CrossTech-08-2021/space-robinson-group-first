using System.Collections.Generic;
using UnityEngine;
using Weapon.Data;

namespace Weapon
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField]
        private HeroShooting heroShooting;

        [SerializeField]
        private List<BaseWeaponData> weapons;

        private int _currentWeaponIndex = 0;
    
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
                ChangeWeapon();
        }

        private void ChangeWeapon()
        {
            heroShooting.weaponData = weapons[(_currentWeaponIndex + 1) % weapons.Count];
            heroShooting.InitWeapon();
            _currentWeaponIndex++;
        }
    }
}
