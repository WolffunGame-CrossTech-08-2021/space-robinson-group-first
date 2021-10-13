using Entity;
using UI;
using UnityEngine;
using Weapon.Data;

namespace Hero
{
    public class HeroEntity : AgentEntity
    {
        [SerializeField]
        private HeroShooting shooting;

        protected override void OnValidate()
        {
            base.Awake();
            
            foreach (var behaviour in behaviours)
            {
                if (behaviour is HeroShooting heroShooting)
                {
                    shooting = heroShooting;
                }
            }
        }

        public void ChangeWeapon(BaseWeaponData weapon)
        {
            shooting.weaponData = weapon;
            shooting.InitWeapon();
        }
    }
}
