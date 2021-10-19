using System;
using Manager;
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
        
        [SerializeField]
        private Image[] healthCells;
        
        [SerializeField]
        private GameObject gameOver;
        
        [SerializeField]
        private GameObject pickupItem;
        
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

        public void SetHealth(int currentHealth)
        {
            if (currentHealth < 0 || currentHealth > healthCells.Length)
                return;
            
            for(int i = 0; i < healthCells.Length; i++)
            {
                if (i + 1> currentHealth)
                {
                    healthCells[i].enabled = false;
                    continue;
                }

                healthCells[i].enabled = true;
            }
        }

        public void SetPickupItem(bool isShow)
        {
            pickupItem.SetActive(isShow);
        }

        public void GameOver()
        {
            gameOver.SetActive(true);
        }
        
        public void Restart()
        {
            gameOver.SetActive(false);
            ChangeWeaponIcon(GameManager.Instance.defaultWeapon);
            _numSeconds = 0;
            _nextSecondTime = 0f;
            SetHealth(5);
        }
    }
}
