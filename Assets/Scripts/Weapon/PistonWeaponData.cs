using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Piston")]
public class PistonWeaponData : BaseWeaponData
{
    private const int MISSING_ANGLE = 5;

    public override void Fire(Transform firePoint)
    {
        PooledObject bullet = GetBulletToFire(firePoint);
        float angle = Random.Range(-MISSING_ANGLE, MISSING_ANGLE);
        RotationBullet(ref bullet, firePoint, angle);
        BackBulletToPool(ref bullet);
    }
}