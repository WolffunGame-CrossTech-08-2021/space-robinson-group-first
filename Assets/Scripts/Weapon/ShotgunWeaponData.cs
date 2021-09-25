using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Shotgun")]
public class ShotgunWeaponData : BaseWeaponData
{
    private const int ANGLE_CONE = 5;

    public override void Fire(Transform firePoint)
    {
        float mostLeftAngle = - ANGLE_CONE * (numBulletsToFire / 2);

        for (int i = 0; i < numBulletsToFire; i++)
        {
            PooledObject bullet = GetBulletToFire(firePoint);
            float angle = mostLeftAngle + ANGLE_CONE * i;
            RotationBullet(ref bullet, firePoint, angle);
            BackBulletToPool(ref bullet);
        }
    }
}
