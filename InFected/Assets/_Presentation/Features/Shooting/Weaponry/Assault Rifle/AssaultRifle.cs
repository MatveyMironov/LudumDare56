using UnityEngine;

public class AssaultRifle : Weapon
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

    private bool _isFiring;
    private bool _isRecharging;
    private float _rechargingTimer;

    private void Start()
    {
        IsReadyToFire = true;
    }

    protected override void Update()
    {
        if (_isRecharging)
        {
            Recharge();
        }
        else if (_isFiring)
        {
            Debug.Log("Firing");
            if (LoadedAmmo > 0)
            {
                FireBullet();
            }
            else
            {
                _isFiring = false;
            }
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
            _isFiring = true;
        }
    }

    public override void ReleaseTheTrigger()
    {
        _isFiring = false;
    }

    private void FireBullet()
    {
        LoadedAmmo -= 1;

        audioSource.PlayOneShot(shotSound);
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
