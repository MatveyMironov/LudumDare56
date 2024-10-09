using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyWeapon
    {
        private WeaponReferences _references;
        private WeaponParameters _parameters;

        public EnemyWeapon(WeaponReferences references, WeaponParameters parameters)
        {
            _references = references;
            _parameters = parameters;
        }

        private bool _isOnCooldown;
        private float _cooldownTimer;

        public bool ReadyToUse { get { return !_isOnCooldown; } }
        public float AttackDistance { get { return _references.WeaponOrigin.localPosition.magnitude + _parameters.AttackRadius; } }

        public void FunctioningTick()
        {
            if (_isOnCooldown)
            {
                CountCooldown();
            }
        }

        public void Use()
        {
            if (!ReadyToUse) { return; }

            _references.AttackingSource.Play();

            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(_references.WeaponOrigin.position, _parameters.AttackRadius);

            foreach (Collider2D hitObject in hitObjects)
            {
                if (hitObject.TryGetComponent(out Player.Player player))
                {
                    if (player.TryGetComponent(out IHitable hitable))
                    {
                        hitable.Hit(_parameters.AttackDamage, _references.WeaponOrigin.position);
                    }

                    break;
                }
            }

            _isOnCooldown = true;
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
            [field: SerializeField] public float AttackRadius { get; private set; }
            [field: SerializeField] public float AttackCooldown { get; private set; }
            [field: SerializeField] public int AttackDamage { get; private set; }
            [field: SerializeField] public LayerMask HitableLayers { get; private set; }
        }

        [Serializable]
        public class WeaponReferences
        {
            [field: SerializeField] public Transform WeaponOrigin { get; private set; }
            [field: SerializeField] public AudioSource AttackingSource { get; private set; }
        }
    }
}
