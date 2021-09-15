using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroShooting : BaseComponentUpdate
{
    public Transform Transform_WeaponAndHands;

    public Transform Player;
    public Transform FirePoint;
    public PooledObject BulletPrefab;
    public float BulletForce = 20f;
    public float FireRate = 0.1f;
    public float MissingAngle = 5f;

    [SerializeField] private AudioSource _shootingAudio;
    private bool _isFire = false;
    private float _lastFiredTime = 0f;

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
            _isFire = true;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            _isFire = false;
        }

        if (_isFire && _lastFiredTime + FireRate < Time.time)
        {
            _lastFiredTime = Time.time;
            Shoot();
        }
    }

    private void Turning()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direct = new Vector2(mousePos.x - Transform_WeaponAndHands.position.x, mousePos.y - Transform_WeaponAndHands.position.y);
        

        if (mousePos.x > Player.position.x + 0.1f)
        {
            Transform_WeaponAndHands.right = direct;
            return;
        }

        if (mousePos.x < Player.position.x - 0.1f)
        {
            Transform_WeaponAndHands.right = -direct;
            return;
        }

    }

    private void Shoot()
    {
        PooledObject bullet = Pool.Instance.Spawn(BulletPrefab, FirePoint.position, FirePoint.rotation * Quaternion.Euler(0, 0, 90));
        Rigidbody2D rb = bullet.As<Bullet>().Rb2D;
        Vector3 dir = Quaternion.AngleAxis(Random.Range(-MissingAngle, MissingAngle), Vector3.forward) * FirePoint.up;
        rb.AddForce(dir * BulletForce, ForceMode2D.Impulse);

        _shootingAudio.Stop();
        _shootingAudio.Play();
    }
}
