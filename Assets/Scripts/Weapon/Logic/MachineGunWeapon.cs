using System;
using UnityEngine;

public class MachineGunWeapon : BaseWeapon
{
    private bool isFire;
    
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
            isFire = false;

        if (interval > 0f)
        {
            interval -= Time.deltaTime;
            return;
        }

        if (Input.GetButtonDown("Fire1"))
            isFire = true;

        if (isFire)
        {
            if (Firing())
            {
                interval = weaponData.fireRate;
                OnFired?.Invoke();
            }
        }
    }
}
