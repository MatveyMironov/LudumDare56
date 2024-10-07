using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour, IHitable
    {
        [Header("Health")]
        [SerializeField] private HealthController healthController;

        [Header("Perception")]
        [SerializeField] private EnemyPerception.PerceptionParameters perceptionParameters;

        [field: Header("Movement")]
        [field: SerializeField] public EnemyMovement Movement { get; private set; }

        [field: Header("Objectives")]
        [field: SerializeField] public EnemyObjectives Objectives { get; private set; }

        [Header("Combat")]
        [SerializeField] private EnemyWeapon.WeaponParameters weaponParameters;

        public EnemyWeapon Weapon { get; private set; }
        public EnemyPerception Perception { get; private set; }

        public bool IsActive;
        public bool IsPatroling;

        private StateMachine _stateMachine;

        private void Awake()
        {
            Perception = new(perceptionParameters);
            Weapon = new(weaponParameters);

            _stateMachine = new StateMachine();

            InactiveState inactiveState = new();
            ActiveState activeState = new(this);

            _stateMachine.AddTransition(inactiveState, activeState, () => IsActive);
            _stateMachine.AddTransition(activeState, inactiveState, () => !IsActive);

            _stateMachine.SetState(inactiveState);
        }

        private void Start()
        {
            Movement.Agent.updateRotation = false;
            Movement.Agent.updateUpAxis = false;

            _stateMachine.EnterCurrentState();
        }

        private void FixedUpdate()
        {
            _stateMachine.Tick();
        }

        private void OnEnable()
        {
            healthController.OnHealthExpired += Death;
        }

        private void OnDisable()
        {
            healthController.OnHealthExpired -= Death;
        }

        private void Death()
        {
            Destroy(gameObject);
        }

        public void Hit(int damage, Vector3 from)
        {
            healthController.SubtractHealth(damage);
        }
    }

    [Serializable]
    public class EnemyObjectives
    {
        [field: SerializeField] public Transform[] Waypoins { get; private set; }
    }
}
