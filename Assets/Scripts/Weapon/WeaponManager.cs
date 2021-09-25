using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private HeroShooting heroShooting;

    [SerializeField]
    private List<BaseWeaponData> weapons;

    private int currentWeaponIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            ChangeWeapon();
    }

    private void ChangeWeapon()
    {
        heroShooting.weaponData = weapons[(currentWeaponIndex + 1) % weapons.Count];
        heroShooting.InitWeapon();
        currentWeaponIndex++;
    }
}
