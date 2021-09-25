using System.Collections;
using UnityEngine;
public class EnemyEntity : MonoBehaviour
{
    public EnemyMovement movement;
    public EnemyHealth health;

    private void OnValidate()
    {
        if (movement == null)
            movement = GetComponent<EnemyMovement>();
        if (health == null)
            health = GetComponent<EnemyHealth>();
    }
}