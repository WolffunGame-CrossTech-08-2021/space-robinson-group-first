using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public BaseWeaponData weaponData;
    public Transform firePoint;
    public UnityEvent OnFireEvent;

    private void Start()
    {
        if (OnFireEvent == null)
            OnFireEvent = new UnityEvent();
    }
}
