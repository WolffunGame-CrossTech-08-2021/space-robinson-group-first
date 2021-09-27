using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Shotgun")]
public class ShotgunWeaponData : BaseWeaponData
{
    private const int ANGLE_CONE = 7;

    public override void Fire(Transform firePoint)
    {
        float mostRightAngle = ANGLE_CONE * (numBulletsToFire / 2);

        for (int i = 0; i < numBulletsToFire; i++)
        {
            float angle = Random.Range(-mostRightAngle, mostRightAngle);
            PooledObject bullet = GetBulletToFire(firePoint);
            RotationBullet(ref bullet, firePoint, angle);
            BackBulletToPool(ref bullet);
        }
    }

    public void Fire2(Transform firePoint)
    {
        float mostRightAngle = ANGLE_CONE * (numBulletsToFire / 2);
        for (float angle = -mostRightAngle; angle <= mostRightAngle; angle += ANGLE_CONE)
        {
            PooledObject bullet = GetBulletToFire(firePoint);
            RotationBullet(ref bullet, firePoint, angle);
            BackBulletToPool(ref bullet);
        }
    }
}
