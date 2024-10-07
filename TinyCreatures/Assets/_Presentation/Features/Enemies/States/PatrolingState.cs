using UnityEngine;

namespace Enemy
{
    public class PatrolingState : IState
    {
        private EnemyMovement _movement;
        private EnemyObjectives _objectives;

        private Transform _currentDestination;
        private int _currentDestinationIndex;

        public PatrolingState(EnemyMovement movement, EnemyObjectives objectives)
        {
            _movement = movement;
            _objectives = objectives;
        }

        public void OnEnter()
        {
            Debug.Log("Patroling");
            _movement.Agent.speed = _movement.WalkingSpeed;
            _movement.Agent.angularSpeed = _movement.TurningSpeed;
            _movement.Agent.isStopped = false;
        }

        public void OnExit()
        {

        }

        public void Tick()
        {
            if (_movement.Agent.remainingDistance <= 0)
            {
                MoveToNextWaypoint();
            }
        }

        private void MoveToNextWaypoint()
        {
            if (_objectives.Waypoins.Length > 0)
            {
                if (_currentDestinationIndex + 1 < _objectives.Waypoins.Length)
                {
                    _currentDestinationIndex++;
                }
                else
                {
                    _currentDestinationIndex = 0;
                }

                _currentDestination = _objectives.Waypoins[_currentDestinationIndex];
                _movement.RotateTo(_currentDestination.position);
                _movement.Agent.SetDestination(_currentDestination.position);
            }
        }
    }
}
