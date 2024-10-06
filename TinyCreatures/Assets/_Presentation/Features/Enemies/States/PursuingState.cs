using UnityEngine;

namespace Enemy
{
    public class PursuingState : IState
    {
        private EnemyMovement _droneMovement;
        private Transform _target;
        private Vector3 _desiredDistance;

        public PursuingState(EnemyMovement droneMovement, Transform target, Vector3 desiredDistance)
        {
            _droneMovement = droneMovement;
            _target = target;
            _desiredDistance = desiredDistance;
        }

        public void OnEnter()
        {
            Debug.Log("Persuing");
            _droneMovement.Agent.speed = _droneMovement.RunningSpeed;
            _droneMovement.Agent.angularSpeed = _droneMovement.TurningSpeed;
        }

        public void OnExit()
        {

        }

        public void Tick()
        {
            _droneMovement.Agent.SetDestination(_target.position);
        }
    }
}
