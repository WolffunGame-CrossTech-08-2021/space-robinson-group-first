using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroEntity : MonoBehaviour
{
    [SerializeField] private List<BaseComponentUpdate> ComponentUpdates;

    private int _numComponents = 0;

    private void OnValidate()
    {
        ComponentUpdates = new List<BaseComponentUpdate>();
        // ComponentUpdates.AddRange(GetComponents<BaseComponentUpdate>());
        ComponentUpdates.AddRange(GetComponentsInChildren<BaseComponentUpdate>());
    }

    private void Start()
    {
        _numComponents = ComponentUpdates.Count;
    }


    private void Update()
    {
        for (int i = 0; i < _numComponents; i++)
            ComponentUpdates[i].DoUpdate();
    }
}
