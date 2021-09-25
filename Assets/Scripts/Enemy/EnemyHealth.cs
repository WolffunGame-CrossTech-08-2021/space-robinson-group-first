using System.Collections;
using UnityEngine;

public class EnemyHealth : BaseMonoBehaviour, IDamageable
{
    public float maxHealth = 100f;

    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        float newHealth = currentHealth - damage;
        if (newHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
            return;
        }

        if (newHealth > maxHealth)
        {
            currentHealth = maxHealth;
            return;
        }

        currentHealth = newHealth;
    }

    public override void DoUpdate()
    {
    }
}