using UnityEngine;

namespace Enemy
{
    public class InvestigatingState : IState
    {
        private EnemyController.EnemyObjectives _objectives;
        private EnemyMovement _movement;

        public InvestigatingState(EnemyController.EnemyObjectives objectives, EnemyMovement movement)
        {
            _objectives = objectives;
            _movement = movement;
        }

        public void OnEnter()
        {
            Debug.Log("Investigating");
            _movement.SetRunningSpeed();
            _movement.MoveTo(_objectives.PositionOfInterest);
            _movement.StartMoving();
        }

        public void OnExit()
        {
            _objectives.PositionOfInterest = Vector3.zero;
        }

        public void Tick()
        {
            if (_movement.RemainingDistance <= 1)
            {
                _movement.StopMoving();
            }
            else
            {
                _movement.StartMoving();
            }
        }

        public bool HasReachedPosition()
        {
            return _movement.RemainingDistance <= 1;
        }
    }
}
