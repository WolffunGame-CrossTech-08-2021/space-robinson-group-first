using System;
using System.Collections.Generic;
using UnityEngine;

public class AgentEntity : MonoBehaviour
{
    [SerializeField]
    private BaseMonoBehaviour[] behaviours;

    public Action<float> OnTakeDamage;
    public Action<float> OnHealing;

    public Action OnDead;

    private void OnValidate()
    {
        behaviours = GetComponentsInChildren<BaseMonoBehaviour>();
    }

    protected void OnAwake() {}

    private void Awake()
    {
        // Setup event
        for(int i = 0; i < behaviours.Length; i++)
        {
            if (behaviours[i] is IDamageable healthBehaviour)
            {
                OnTakeDamage += healthBehaviour.TakeDamage;
            }
        }

        // Call awake
        OnAwake();
    }

    private void Update()
    {
        for (int i = 0; i < behaviours.Length; i++)
        {
            behaviours[i].DoUpdate();
        }
    }
}
