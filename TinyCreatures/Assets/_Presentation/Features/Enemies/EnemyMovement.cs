using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    [Serializable]
    public class EnemyMovement
    {
        [field: SerializeField] public NavMeshAgent Agent { get; private set; }

        [field: Space]
        [field: SerializeField] public float WalkingSpeed { get; private set; }
        [field: SerializeField] public float RunningSpeed { get; private set; }
        [field: SerializeField] public float TurningSpeed { get; private set; }

        [ContextMenu("Reset Walking Speed")]
        public void ResetWalkingSpeed()
        {
            Agent.speed = WalkingSpeed;
            Agent.angularSpeed = TurningSpeed;
        }

        [ContextMenu("Reset Running Speed")]
        public void SetRunningSpeed()
        {
            Agent.speed = RunningSpeed;
            Agent.angularSpeed = TurningSpeed;
        }
    }
}
