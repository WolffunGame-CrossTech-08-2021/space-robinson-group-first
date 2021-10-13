using System;
using UnityEngine;
using UnityEngine.UI;
using Weapon.Data;

namespace UI
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField]
        private Text bulletCount;
        
        [SerializeField]
        private Image weaponIcon;
        
        [SerializeField]
        private Text clock;

        private int _numSeconds;

        private float _nextSecondTime = 0f;
        
        private void Update()
        {
            if (Time.time >= _nextSecondTime)
            {
                _nextSecondTime += 1f;
                _numSeconds++;
                clock.text = $"{(_numSeconds / 60):00}:{(_numSeconds % 60):00}";
            }
        }

        public void ChangeWeaponIcon(BaseWeaponData weapon)
        {
            weaponIcon.sprite = weapon.icon;
            weaponIcon.SetNativeSize();
        }
        
        public void SetBulletCount(int current, int total)
        {
            bulletCount.text = $"Bullets: {current} ({total})";
        }
    }
}
