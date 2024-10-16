using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyController : MonoBehaviour, IHitable
    {
        [Header("Health")]
        [SerializeField] private HealthController healthController;

        [Header("Hit Effects")]
        [SerializeField] private AudioSource gettingHitSource;

        [Header("Perception")]
        [SerializeField] private EnemyPerception.PerceptionReferences perceptionReferences;
        [SerializeField] private EnemyPerception.PerceptionParameters perceptionParameters;

        [Header("Movement")]
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Animator animator;
        [SerializeField] private EnemyMovement.MovementParameters movementParameters;

        [Header("Objectives")]
        [SerializeField] private EnemyObjectives objectives;

        [Header("Combat")]
        [SerializeField] private EnemyWeapon.WeaponReferences weaponReferences;
        [SerializeField] private EnemyWeapon.WeaponParameters weaponParameters;

        private EnemyMovement _movement;
        private EnemyWeapon _weapon;
        private EnemyPerception _perception;

        public bool IsActive;

        private StateMachine _stateMachine;

        private void Awake()
        {
            _movement = new(agent, animator, movementParameters);
            _perception = new(perceptionReferences, perceptionParameters);
            _weapon = new(weaponReferences, weaponParameters);

            _stateMachine = new StateMachine();

            InactiveState inactiveState = new();
            ActiveState activeState = new(_movement, _perception, _weapon, objectives);

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
            gettingHitSource.Play();
            healthController.SubtractHealth(damage);
            objectives.PositionOfInterest = from;
        }

        public void SetPositionOfInterest(Vector3 position)
        {
            objectives.PositionOfInterest = position;
        }

        [Serializable]
        public class EnemyObjectives
        {
            [field: SerializeField] public Transform[] Waypoins { get; private set; }
            [field: SerializeField] public bool IsPatroling { get; private set; }
            public Vector3 PositionOfInterest { get; set; }
        }
    }
}
