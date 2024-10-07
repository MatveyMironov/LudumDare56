using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    [Serializable]
    public class EnemyMovement
    {
        private NavMeshAgent _agent;
        private MovementParameters _parameters;

        public EnemyMovement(NavMeshAgent agent, MovementParameters parameters)
        {
            _agent = agent;
            _parameters = parameters;
        }

        public float RemainingDistance { get { return _agent.remainingDistance; } }

        [ContextMenu("Reset Walking Speed")]
        public void SetWalkingSpeed()
        {
            _agent.speed = _parameters.WalkingSpeed;
            _agent.angularSpeed = _parameters.TurningSpeed;
        }

        [ContextMenu("Reset Running Speed")]
        public void SetRunningSpeed()
        {
            _agent.speed = _parameters.RunningSpeed;
            _agent.angularSpeed = _parameters.TurningSpeed;
        }

        public void MoveTo(Vector3 position)
        {
            Vector3 targ;
            targ.x = position.x - _agent.transform.position.x;
            targ.y = position.y - _agent.transform.position.y;
            targ.z = 0f;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg + 90.0f;
            _agent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            _agent.SetDestination(position);
            _agent.isStopped = false;
        }

        public void StopMoving()
        {
            _agent.isStopped = true;
        }

        public void StartMoving()
        {
            _agent.isStopped = false;
        }

        [Serializable]
        public class MovementParameters
        {
            [field: SerializeField] public float WalkingSpeed { get; private set; }
            [field: SerializeField] public float RunningSpeed { get; private set; }
            [field: SerializeField] public float TurningSpeed { get; private set; }
        }
    }
}
