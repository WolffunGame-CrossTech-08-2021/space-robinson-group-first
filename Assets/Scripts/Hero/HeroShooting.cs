using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroShooting : BaseComponentUpdate
{
    public GameObject weaponAndHands;
    public Transform firePoint;
    public BaseWeaponData weaponData;

    public float cameraShakeDuration = 0.05f;
    public float cameraShakeStrength = 0.15f;

    [SerializeField]
    private AudioSource shootingAudio;
    private bool isFire = false;
    private float lastFiredTime = 0f;

    private void OnValidate()
    {
        if (shootingAudio == null)
            shootingAudio = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        // Add weapon to character
        Instantiate(weaponData.weaponPrefab, weaponAndHands.transform);

        // Detect firepoint in weapon prefab
        GameObject firePointObject = GameObject.FindGameObjectWithTag("FirePoint");
        if (!firePointObject)
        {
            Debug.LogError("Can't find fire point in character !");
            return;
        }
        firePoint = GameObject.FindGameObjectWithTag("FirePoint")?.transform;
    }

    public override void DoUpdate()
    {
        Turning();
        if (Input.GetButtonDown("Fire1"))
        {
            isFire = true;
        }

        else
            isFire = false;

        //if (Input.GetButtonUp("Fire1"))
        //{
        //    _isFire = false;
        //}

        if (isFire && lastFiredTime + weaponData.fireRate < Time.time)
        {
            lastFiredTime = Time.time;
            Shoot();
        }
    }

    private void Turning()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direct = new Vector2(mousePos.x - weaponAndHands.transform.position.x, mousePos.y - weaponAndHands.transform.position.y);
        

        if (mousePos.x > transform.position.x + 0.1f)
        {
            weaponAndHands.transform.right = direct;
            return;
        }

        if (mousePos.x < transform.position.x - 0.1f)
        {
            weaponAndHands.transform.right = -direct;
            return;
        }
    }

    private void Shoot()
    {
        weaponData.Fire(firePoint);
        PlayShootAudio();
        CameraShakeOnFire();
    }

    private void PlayShootAudio()
    {
        // _shootingAudio.Stop();
        shootingAudio.Play();
    }

    private void CameraShakeOnFire()
    {
        Camera.main.DOShakePosition(cameraShakeDuration, cameraShakeStrength, 10, 90, false);
    }
}
