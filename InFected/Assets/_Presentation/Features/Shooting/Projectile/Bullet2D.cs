using System;
using UnityEngine;

public class Bullet2D : Projectile2D
{
    private int _damage;
    private Vector3 _shooterPosition;

    private bool _isSetup;

    public void SetupBullet(float speed, LayerMask hitableLayers, float deathTime, int damage, Vector3 shooterPosition)
    {
        if (_isSetup) { return; }

        SetupProjectile(speed, hitableLayers, deathTime);
        _damage = damage;
        _shooterPosition = shooterPosition;

        _isSetup = true;
    }

    protected override void OnHit(RaycastHit2D hit)
    {
        if (hit.transform.TryGetComponent(out IHitable hitable))
        {
            hitable.Hit(_damage, _shooterPosition);
        }

        Destroy(gameObject);
    }
}
