using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private ProjectileParameters _parameters;
    private bool _isSetup;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_isSetup) { return; }

        if (collision.transform.TryGetComponent(out HealthController healthController))
        {
            healthController.SubtractHealth(_parameters.Damage);
        }

        Destroy(rb.gameObject);
    }

    public void Setup(ProjectileParameters parameters)
    {
        _parameters = parameters;
        rb.velocity = rb.transform.up * _parameters.Speed;
        _isSetup = true;
    }

    [Serializable]
    public struct ProjectileParameters
    {
        public ProjectileParameters(float speed, int damage)
        {
            Speed = speed;
            Damage = damage;
        }

        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
    }
}
