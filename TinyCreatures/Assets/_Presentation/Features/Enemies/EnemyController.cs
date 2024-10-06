using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
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
    }

    [Serializable]
    public class EnemyObjectives
    {
        [field: SerializeField] public Transform[] Waypoins { get; private set; }
    }
}
