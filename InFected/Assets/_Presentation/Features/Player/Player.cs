using System;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour, IHitable
    {
        [Header("Health")]
        [SerializeField] private HealthController healthController;

        [Header("Hit Effects")]
        [SerializeField] private AudioSource gettingHitSource;

        public CircleCollider2D Collider { get; private set; }

        public event Action OnPlayerDeath;

        private void Awake()
        {
            Collider = GetComponent<CircleCollider2D>();
        }

        private void OnEnable()
        {
            healthController.OnHealthExpired += Death;
        }

        private void OnDisable()
        {
            healthController.OnHealthExpired -= Death;
        }

        public void Hit(int damage, Vector3 from)
        {
            gettingHitSource.Play();
            healthController.SubtractHealth(damage);
        }

        private void Death()
        {
            OnPlayerDeath?.Invoke();
        }

    }
}
