using System;
using UnityEngine;

namespace ECS
{
    public abstract class BaseEntity : MonoBehaviour
    {
        [SerializeField]
        protected BaseComponent[] components;

        public Action<int> OnTakeDamage;
        public Action<int> OnHealing;
        public Action OnDeath;

        protected virtual void OnValidate()
        {
            components = GetComponents<BaseComponent>();
            
            foreach (var component in components)
                component.entity = this;
        }

        protected virtual void Awake()
        {
            // Setup event
            foreach (var component in components)
            {
                if (component is IDamageable healthBehaviour)
                {
                    OnTakeDamage += healthBehaviour.TakeDamage;
                }
            }
            
            OnDeath += EntityDead;
        }

        private void Update()
        {
            foreach (var component in components)
            {
                component.DoUpdate();
            }
        }

        protected abstract void EntityDead();
    }
}
