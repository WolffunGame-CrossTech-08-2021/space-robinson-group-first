using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroShooting : MonoBehaviour
{
    public Transform player;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    private AudioSource _shootingAudio;

    private void Awake()
    {

        _shootingAudio = GetComponent<AudioSource>();
    }

    private void Update()
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

        Vector2 direct = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        

        if (mousePos.x > player.position.x + 0.1f)
        {
            transform.right = direct;
            return;
        }

        if (mousePos.x < player.position.x - 0.1f)
        {
            transform.right = -direct;
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
