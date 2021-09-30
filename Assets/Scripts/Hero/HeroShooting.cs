using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HeroShooting : BaseMonoBehaviour
{
    public GameObject weaponAndHands;
    public BaseWeaponData weaponData;

    public float cameraShakeDuration = 0.05f;
    public float cameraShakeStrength = 0.15f;

    public Text txtCurrentBulletsCount;

    [SerializeField]
    private AudioSource shootingAudio;

    public int totalBulletsCount;
    public int currentBulletsCount;

    private void OnValidate()
    {
        if (shootingAudio == null)
            shootingAudio = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        InitWeapon();
    }

    public void InitWeapon()
    {
        // Remove all child gameObject in weaponAndHands
        foreach (Transform child in weaponAndHands.transform)
        {
            DestroyImmediate(child.gameObject);
        }

        // Add weapon to character
        Instantiate(weaponData.weaponPrefab, weaponAndHands.transform);
        
        // Change fire audio clip
        shootingAudio.clip = weaponData.fireAudio;
        
        // UI
        totalBulletsCount = weaponData.maxBullets;
        RechargeBullet();
    }

    public IEnumerator RechargeBulletAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        shootingAudio.clip = weaponData.fireReloadAudio;
        shootingAudio.Play();

        yield return new WaitForSeconds(weaponData.reloadTime);
        shootingAudio.clip = weaponData.fireAudio;
        RechargeBullet();
    } 

    public void RechargeBullet()
    {
        currentBulletsCount = weaponData.cartridgeCapacity % weaponData.maxBullets;
        totalBulletsCount -= currentBulletsCount;
        SetBulletCount();
    }

    public void SetBulletCount()
    {
        txtCurrentBulletsCount.text = $"Bullets: {currentBulletsCount} ({totalBulletsCount})";
    }

    public override void DoUpdate()
    {
        Turning();
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

    public void PlayShootAudio()
    {
        // _shootingAudio.Stop();
        shootingAudio.Play();
    }

    public void CameraShakeOnFire()
    {
        Camera.main.DOShakePosition(cameraShakeDuration, cameraShakeStrength, 10, 90, false);
    }
}
