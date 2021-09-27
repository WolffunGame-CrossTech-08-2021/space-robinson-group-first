using System.Collections;
using UnityEngine;

public class EnemyHealth : BaseMonoBehaviour, IDamageable
{
    public float maxHealth = 100f;

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
    }

    public override void DoUpdate()
    {
    }
}
