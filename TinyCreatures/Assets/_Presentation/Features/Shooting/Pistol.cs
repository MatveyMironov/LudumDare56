using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private Projectile bulletPrefab;
    [SerializeField] private Projectile.ProjectileParameters bulletParameters;
    [SerializeField] private Transform muzzle;

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

        Projectile bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        bullet.Setup(bulletParameters);
        LoadedAmmo -= 1;
    }

    public override void ReleaseTheTrigger()
    {
        IsReadyToFire = true;
    }

    private void Recharge()
    {

    }
}
