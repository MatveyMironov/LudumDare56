using UnityEngine;

public class Pistol : Weapon
{
    [Header("Bullet")]
    [SerializeField] private Bullet2D bulletPrefab;

    [Header("Weapon")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private LayerMask hitableLayers;
    [SerializeField] private int bulletDamage;
    [SerializeField] private float effectiveDistance;
    [SerializeField] private float cooldown;

    [Header("References")]
    [SerializeField] private Transform muzzle;

    [Header("Effects")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shotSound;
    [SerializeField] private AudioClip emptyClickSound;
    [SerializeField] private Animator animator;

    private bool _isRecharging;
    private float _rechargingTimer;

    protected override void Update()
    {
        if (_isRecharging)
        {
            Recharge();
        }
    }

    public override void PullTheTrigger()
    {
        if (!IsReadyToFire || _isRecharging)
        { return; }

        if (LoadedAmmo <= 0)
        {
            audioSource.PlayOneShot(emptyClickSound);
        }
        else
        {
            FireBullet();
            IsReadyToFire = false;
        }
    }

    public override void ReleaseTheTrigger()
    {
        IsReadyToFire = true;
    }

    private void FireBullet()
    {
        LoadedAmmo -= 1;

        audioSource.PlayOneShot(shotSound);
        animator.SetTrigger("Shoot");
        SpawnBullet();
        
        _isRecharging = true;
        RaiseAmmoAmountEvent();
    }

    private void SpawnBullet()
    {
        Bullet2D bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        float bulletDeathTime = effectiveDistance / bulletSpeed;
        bullet.SetupBullet(bulletSpeed, hitableLayers, bulletDeathTime, bulletDamage, muzzle.position);
    }

    private void Recharge()
    {
        _rechargingTimer += Time.deltaTime;
        if (_rechargingTimer >= cooldown)
        {
            _isRecharging = false;
            _rechargingTimer = 0;
        }
    }
}
