using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private LayerMask hitableLayers;
    [SerializeField] private int Damage;
    [SerializeField] private Transform muzzle;

    [Header("Effects")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shotClip;
    [SerializeField] private TrailRenderer tracerEffect;

    protected override void Update()
    {
        
    }

    public override void PullTheTrigger()
    {
        if (!IsReadyToFire)
        { return; }

        Fire();
        IsReadyToFire = false;
    }

    private void Fire()
    {
        if (LoadedAmmo <= 0)
        { return; }

        audioSource.PlayOneShot(shotClip);
        CreateRaycast();
        
        LoadedAmmo -= 1;
        RaiseAmmoAmountEvent();
    }

    public override void ReleaseTheTrigger()
    {
        IsReadyToFire = true;
    }

    private void CreateRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(muzzle.position, muzzle.up, 100, hitableLayers);
        if (hit.collider.TryGetComponent(out HealthController health))
        {
            health.SubtractHealth(Damage);
        }
        DrawTracer(hit.point);
    }

    private void DrawTracer(Vector3 impactPoint)
    {
        var tracer = Object.Instantiate(tracerEffect, muzzle.position, muzzle.rotation);
        tracer.AddPosition(muzzle.position);

        tracer.transform.position = impactPoint;
    }
}
