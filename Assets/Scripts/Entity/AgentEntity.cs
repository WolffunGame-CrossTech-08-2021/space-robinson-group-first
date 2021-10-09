using System;
using UnityEngine;

namespace Entity
{
    public class AgentEntity : MonoBehaviour
    {
        [SerializeField]
        private BaseMonoBehaviour[] behaviours;

        public Action<float> OnTakeDamage;
        public Action<float> OnHealing;

        public Action OnDead;

        protected virtual void OnValidate()
        {
            behaviours = GetComponentsInChildren<BaseMonoBehaviour>();
        }

        protected virtual void Awake()
        {
            // Setup event
            for(int i = 0; i < behaviours.Length; i++)
            {
                if (behaviours[i] is IDamageable healthBehaviour)
                {
                    OnTakeDamage += healthBehaviour.TakeDamage;
                }
            }
        }

        private void Update()
        {
            for (int i = 0; i < behaviours.Length; i++)
            {
                behaviours[i].DoUpdate();
            }
        }
    }
}
