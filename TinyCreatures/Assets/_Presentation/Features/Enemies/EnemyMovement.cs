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

        public void RotateTo(Vector3 position)
        {
            Vector3 targ;
            targ.x = position.x - Agent.transform.position.x;
            targ.y = position.y - Agent.transform.position.y;
            targ.z = 0f;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg + 90.0f;
            Agent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
