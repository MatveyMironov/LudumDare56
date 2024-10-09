using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private LayerMask hitableLayers;
    [SerializeField] private int Damage;
    [SerializeField] private float Cooldown;
    [SerializeField] private Transform muzzle;

    [Header("Effects")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shotSound;
    [SerializeField] private AudioClip emptyClickSound;
    [SerializeField] private TrailRenderer tracerEffect;
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

        Fire();
        IsReadyToFire = false;
    }

    public override void ReleaseTheTrigger()
    {
        IsReadyToFire = true;
    }

    private void Fire()
    {
        if (LoadedAmmo <= 0)
        {
            audioSource.PlayOneShot(emptyClickSound);
            return;
        }

        audioSource.PlayOneShot(shotSound);
        animator.SetTrigger("Shoot");
        CreateRaycast();
        
        LoadedAmmo -= 1;
        _isRecharging = true;
        RaiseAmmoAmountEvent();
    }

    private void CreateRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(muzzle.position, muzzle.up, 100, hitableLayers);
        if (hit.collider.TryGetComponent(out IHitable hitable))
        {
            hitable.Hit(Damage, muzzle.position);
        }
        DrawTracer(hit.point);
    }

    private void DrawTracer(Vector3 impactPoint)
    {
        var tracer = Object.Instantiate(tracerEffect, muzzle.position, muzzle.rotation);
        tracer.AddPosition(muzzle.position);

        tracer.transform.position = impactPoint;
    }

    private void Recharge()
    {
        _rechargingTimer += Time.deltaTime;
        if (_rechargingTimer >= Cooldown)
        {
            _isRecharging = false;
            _rechargingTimer = 0;
        }
    }
}
