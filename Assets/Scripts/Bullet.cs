using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public PooledObject HitEffect;
    public Rigidbody2D Rb2D;
    public float damage = 5f;

    private PooledObject _pooledObject;

    private void Awake()
    {
        if (Rb2D == null)
            Rb2D = GetComponent<Rigidbody2D>();
        _pooledObject = GetComponent<PooledObject>();
    }

    public virtual void Setup()
    {
        // Cài đặt hướng bay của viên đạn, ...
        // Vị trí xuất phát, hướng bay
        // 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            EnemyEntity enemyEntity = collision.gameObject.GetComponent<EnemyEntity>();
            enemyEntity.OnTakeDamage?.Invoke(damage);
        }

        PooledObject effect = Pool.Instance.Spawn(HitEffect, transform.position, Quaternion.identity);

        effect.FinishDelayed(1f);
        _pooledObject.Finish();
    }
}
