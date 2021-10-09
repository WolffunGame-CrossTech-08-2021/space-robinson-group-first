using System;
using Manager;
using UnityEngine;
using Weapon.Data;

namespace Weapon.Logic
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        public BaseWeaponData weaponData;
        [HideInInspector]
        public Transform firePoint;

        public Action OnFired;
        public Action OnNotEnoughBullet;

        private HeroShooting shooting;
        protected float interval;

        private void OnValidate()
        {
            if (firePoint == null)
                firePoint = transform.Find("FirePoint");
        }

        private void Awake()
        {
            shooting = GetComponentInParent<HeroShooting>();
            if (OnFired == null)
            {
                OnFired += shooting.PlayShootAudio;
                OnFired += shooting.CameraShakeOnFire;
            }

            if (OnNotEnoughBullet == null)
                OnNotEnoughBullet += RechargeBullet;
        }

        void Update()
        {
            if (interval > 0f)
            {
                interval -= Time.deltaTime;
                return;
            }

            if (InputManager.IsPressFire)
            {
                if (Firing())
                {
                    interval = weaponData.fireRate;
                    OnFired?.Invoke();
                }
            }
        }

        protected bool Firing()
        {
            if (shooting.currentBulletsCount >= weaponData.numBulletsToFire)
            {
                shooting.currentBulletsCount -= weaponData.numBulletsToFire;
                shooting.SetBulletCount();
                weaponData.Fire(firePoint);

                if (shooting.currentBulletsCount == 0)
                    OnNotEnoughBullet.Invoke();

                return true;
            }

            return false;
        }

        public void RechargeBullet()
        {
            if (shooting.totalBulletsCount > 0)
            {
                StartCoroutine(shooting.RechargeBulletAnimation());
            }
        }
    }
}
