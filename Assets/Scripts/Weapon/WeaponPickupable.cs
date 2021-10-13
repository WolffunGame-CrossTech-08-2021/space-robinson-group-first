using System;
using UnityEngine;

namespace Weapon
{
    public class WeaponPickupable : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(gameObject);
        }
    }
}
