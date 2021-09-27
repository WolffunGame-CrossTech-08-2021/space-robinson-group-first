using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Rifle")]
public class RifleWeaponData : BaseWeaponData
{
    private const int MISSING_ANGLE = 7;

    public override void Fire(Transform firePoint)
    {
        PooledObject bullet = GetBulletToFire(firePoint);
        float angle = Random.Range(-MISSING_ANGLE, MISSING_ANGLE);
        RotationBullet(ref bullet, firePoint, angle);
        BackBulletToPool(ref bullet);
    }
}
