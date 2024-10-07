using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyController : MonoBehaviour, IHitable
    {
        [Header("Health")]
        [SerializeField] private HealthController healthController;

        [Header("Perception")]
        [SerializeField] private EnemyPerception.PerceptionParameters perceptionParameters;

        [Header("Movement")]
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private EnemyMovement.MovementParameters movementParameters;

        [field: Header("Objectives")]
        [field: SerializeField] public EnemyObjectives Objectives { get; private set; }

        [Header("Combat")]
        [SerializeField] private EnemyWeapon.WeaponParameters weaponParameters;

        public EnemyMovement Movement {  get; private set; }
        public EnemyWeapon Weapon { get; private set; }
        public EnemyPerception Perception { get; private set; }

        public bool IsActive;
        public bool IsPatroling;

        private StateMachine _stateMachine;

        private void Awake()
        {
            Movement = new(agent, movementParameters);
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
            agent.updateRotation = false;
            agent.updateUpAxis = false;
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
            Objectives.PositionOfInterest = from;
        }
    }

    [Serializable]
    public class EnemyObjectives
    {
        [field: SerializeField] public Transform[] Waypoins { get; private set; }
        public Vector3 PositionOfInterest { get; set; }
    }
}
