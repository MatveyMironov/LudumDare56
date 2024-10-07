using UnityEngine;

namespace Enemy
{
    public class InvestigatingState : IState
    {
        private EnemyObjectives _objectives;
        private EnemyMovement _movement;

        public InvestigatingState(EnemyObjectives objectives, EnemyMovement movement)
        {
            _objectives = objectives;
            _movement = movement;
        }

        public void OnEnter()
        {
            _movement.MoveTo(_objectives.PositionOfInterest);
            _movement.SetRunningSpeed();

            if (_movement.RemainingDistance <= 1)
            {
                _movement.StopMoving();
            }
            else
            {
                _movement.StartMoving();
            }
        }

        public void OnExit()
        {
            _objectives.PositionOfInterest = Vector3.zero;
        }

        public void Tick()
        {
            
        }

        public bool HasReachedPosition()
        {
            return _movement.RemainingDistance <= 1;
        }
    }
}
