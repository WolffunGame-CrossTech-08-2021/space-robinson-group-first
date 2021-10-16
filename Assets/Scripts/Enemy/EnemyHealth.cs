using ECS;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyHealth : BaseComponent, IDamageable
    {
        public int maxHealth = 100;
        public Image healthBar;
        
        private int _currentHealth;

        private void Awake()
        {
            _currentHealth = maxHealth;
            if (healthBar != null)
                healthBar.fillAmount = 1f;
        }

        public void TakeDamage(int damage)
        {
            int newHealth = _currentHealth - damage;
            if (newHealth <= 0)
            {
                entity.OnDeath?.Invoke();
                _currentHealth = 0;
                gameObject.SetActive(false);
                return;
            }

            if (newHealth > maxHealth)
            {
                _currentHealth = maxHealth;
                return;
            }

            _currentHealth = newHealth;

            if (healthBar != null)
            {
                healthBar.fillAmount = _currentHealth / maxHealth;
            }
        }
    }
}
