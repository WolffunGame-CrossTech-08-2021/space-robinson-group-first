using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : BaseMonoBehaviour, IDamageable
{
    public float maxHealth = 100f;
    public Image healthBar;

    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        float newHealth = _currentHealth - damage;
        if (newHealth <= 0)
        {
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

    public override void DoUpdate()
    {
    }
}
