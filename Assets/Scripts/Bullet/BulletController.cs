using ObjectPooling;
using UnityEngine;

namespace Bullet
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class BulletController : MonoBehaviour
    {
        [HideInInspector]
        public Rigidbody2D rb2d;
        [HideInInspector]
        public PooledObject pooledObject;
    
        public PooledObject explosionEffect;
        public float damage = 5f;

        private void OnValidate()
        {
            if (rb2d == null)
                rb2d = GetComponent<Rigidbody2D>();
            if (pooledObject == null)
                pooledObject = GetComponent<PooledObject>();
        }

        public void Setup()
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

            // Create explosion effect
            PooledObject effect = Pool.Instance.Spawn(explosionEffect, transform.position, Quaternion.identity);
            effect.FinishDelayed(1f);
            pooledObject.Finish();
        }
    }
}
