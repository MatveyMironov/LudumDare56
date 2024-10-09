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
