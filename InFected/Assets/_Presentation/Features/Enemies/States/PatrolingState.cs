using UnityEngine;

namespace Enemy
{
    public class PatrolingState : IState
    {
        private EnemyController.EnemyObjectives _objectives;
        private EnemyMovement _movement;

        private Transform _currentDestination;
        private int _currentDestinationIndex;

        public PatrolingState(EnemyController.EnemyObjectives objectives, EnemyMovement movement)
        {
            _objectives = objectives;
            _movement = movement;
        }

        public void OnEnter()
        {
            Debug.Log("Patroling");
            _movement.SetWalkingSpeed();
            _movement.StartMoving();
        }

        public void OnExit()
        {

        }

        public void Tick()
        {
            if (_movement.RemainingDistance <= 0)
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
                _movement.MoveTo(_currentDestination.position);
            }
        }
    }
}
