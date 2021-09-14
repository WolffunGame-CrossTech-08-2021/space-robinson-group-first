using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroEntity : MonoBehaviour
{
    public List<BaseComponentUpdate> ComponentUpdates = new List<BaseComponentUpdate>();

    private int numComponents = 0;

    private void OnValidate()
    {
        ComponentUpdates.Clear();
        // ComponentUpdates.AddRange(GetComponents<BaseComponentUpdate>());
        ComponentUpdates.AddRange(GetComponentsInChildren<BaseComponentUpdate>());
    }

    private void Start()
    {
       numComponents = ComponentUpdates.Count;
    }


    private void Update()
    {
        for (int i = 0; i < numComponents; i++)
            ComponentUpdates[i].DoUpdate();
    }
}
