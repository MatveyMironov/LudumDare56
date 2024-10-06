using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyWeapon
    {
        private WeaponParameters _parameters;

        public EnemyWeapon(WeaponParameters parameters)
        {
            _parameters = parameters;
        }

        private bool _isOnCooldown;
        private float _cooldownTimer;

        public void FunctioningTick()
        {
            if (_isOnCooldown)
            {
                CountCooldown();
            }
        }

        public void Use(Transform user, Player player)
        {
            if (_isOnCooldown) { return; }

            if (Vector2.Distance(user.position, player.transform.position) <= _parameters.AttackDistance)
            {
                if (player.TryGetComponent(out HealthController health))
                {
                    health.SubtractHealth(_parameters.AttackDamage);
                    _isOnCooldown = true;
                }
            }
        }

        public void CountCooldown()
        {
            _cooldownTimer += Time.fixedDeltaTime;
            if (_cooldownTimer >= _parameters.AttackCooldown)
            {
                _isOnCooldown = false;
                _cooldownTimer = 0;
            }
        }

        [Serializable]
        public class WeaponParameters
        {
            [field: SerializeField] public float AttackDistance { get; private set; }
            [field: SerializeField] public float AttackCooldown { get; private set; }
            [field: SerializeField] public int AttackDamage { get; private set; }
        }
    }
}
