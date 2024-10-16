using UnityEngine;

public abstract class Projectile2D : MonoBehaviour
{
    private float _speed;
    private LayerMask _hitableLayers;
    private float _deathTime;

    private bool _isProjectileSetup;

    private Vector3 _previousPosition;
    private float _lifeTime;

    protected void SetupProjectile(float speed, LayerMask hitableLayers, float deathTime)
    {
        if (_isProjectileSetup) { return; }

        _speed = speed;
        _hitableLayers = hitableLayers;
        _deathTime = deathTime;

        _isProjectileSetup = true;
    }

    private void FixedUpdate()
    {
        if (!_isProjectileSetup)
            return;

        _previousPosition = transform.position;
        Vector3 nextPosition = CalculateNextPosition();
        RaycastHit2D hit = CheckForHit(nextPosition);
        if (hit.collider != null)
        {
            transform.position = hit.point;
            OnHit(hit);
            return;
        }

        transform.position = nextPosition;

        CountLifeTime();
    }

    protected abstract void OnHit(RaycastHit2D hit);

    protected virtual void OnLifeTimeExpired()
    {
        Destroy(gameObject);
    }

    private Vector3 CalculateNextPosition()
    {
        return transform.position + transform.up * _speed * Time.fixedDeltaTime;
    }

    private RaycastHit2D CheckForHit(Vector3 nextPosition)
    {
        Vector3 collisionVector = nextPosition - _previousPosition;
        Vector3 collisionDirection = collisionVector.normalized;
        float collisionDistance = collisionVector.magnitude;

        return Physics2D.Raycast(nextPosition, collisionDirection, collisionDistance, _hitableLayers);
    }

    private void CountLifeTime()
    {
        _lifeTime += Time.fixedDeltaTime;

        if (_lifeTime >= _deathTime)
        {
            OnLifeTimeExpired();
        }
    }
}
