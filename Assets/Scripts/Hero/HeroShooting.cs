using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroShooting : BaseComponentUpdate
{
    public Transform Transform_WeaponAndHands;

    public Transform player;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    [SerializeField]
    private AudioSource _shootingAudio;

    private void OnValidate()
    {
        if (_shootingAudio == null)
            _shootingAudio = GetComponent<AudioSource>();
    }

    public override void DoUpdate()
    {

        Turning();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Turning()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direct = new Vector2(mousePos.x - Transform_WeaponAndHands.position.x, mousePos.y - Transform_WeaponAndHands.position.y);
        

        if (mousePos.x > player.position.x + 0.1f)
        {
            Transform_WeaponAndHands.right = direct;
            return;
        }

        if (mousePos.x < player.position.x - 0.1f)
        {
            Transform_WeaponAndHands.right = -direct;
            return;
        }

    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 90));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 2f);

        _shootingAudio.Stop();
        _shootingAudio.Play();
    }
}
