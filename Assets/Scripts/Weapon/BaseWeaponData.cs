using System.Collections;
using UnityEngine;

public abstract class BaseWeaponData : ScriptableObject
{
    public enum WeaponFireMode {
        AUTO,
        SEMIAUTO,
        BURST,
        STAGGERED
    };

    public GameObject weaponPrefab;
    public WeaponFireMode weaponFireMode;
    public PooledObject bulletPrefab;
    public float bulletVelocity = 10f;
    public int numBulletsToFire = 1;
    public float fireRate = 0.1f;

    public abstract void Fire(Transform firePoint);

    public PooledObject GetBulletToFire(Transform firePoint)
    {
        Quaternion rotation = firePoint.rotation * Quaternion.Euler(0, 0, 90);
        PooledObject bullet = Pool.Instance.Spawn(bulletPrefab, firePoint.position, rotation);
        return bullet;
    }

    public void RotationBullet(ref PooledObject bullet, Transform firePoint, float angle)
    {
        Rigidbody2D rb = bullet.As<Bullet>().Rb2D;

        // Rotation velocity of bullet
        Vector3 direction = Quaternion.AngleAxis(angle, Vector3.forward) * firePoint.up;
        rb.AddForce(direction * bulletVelocity, ForceMode2D.Impulse);

        // Rotation bullet
        Vector3 eulerAngles = rb.transform.eulerAngles;
        eulerAngles.z += angle;
        rb.transform.eulerAngles = eulerAngles;
    }

    public void BackBulletToPool(ref PooledObject bullet, float time = 2f)
    {
        bullet.FinishDelayed(time);
    }
}
