using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public abstract class BaseWeapon : MonoBehaviour
{
    public BaseWeaponData weaponData;
    public Transform firePoint;
    
    public Action OnFired;
    
    private HeroShooting shooting;
    
    protected float interval;

    private void Awake()
    {
        shooting = GetComponentInParent<HeroShooting>();
        if (OnFired == null)
        {
            OnFired += shooting.PlayShootAudio;
            OnFired += shooting.CameraShakeOnFire;
        }
    }

    void Update()
    {
        if (interval > 0f)
        {
            interval -= Time.deltaTime;
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            weaponData.Fire(firePoint);
            interval = weaponData.fireRate;
            
            OnFired?.Invoke();
        }
    }
}
