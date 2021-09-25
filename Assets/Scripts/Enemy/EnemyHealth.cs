using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;

    private bool _isDeath = false;
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
            // var enemyEntity = gameObject.GetComponent<EnemyEntity>();
            _currentHealth = 0;
            _isDeath = true;
            // enemyEntity.movement.isRunning = false;
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
}