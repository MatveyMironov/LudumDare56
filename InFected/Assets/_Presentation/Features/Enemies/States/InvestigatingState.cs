using UnityEngine;

namespace Enemy
{
    public class InvestigatingState : IState
    {
        private EnemyController.EnemyObjectives _objectives;
        private EnemyMovement _movement;
        private EnemyCommunication _communication;

        public InvestigatingState(EnemyController.EnemyObjectives objectives, EnemyMovement movement, EnemyCommunication communication)
        {
            _objectives = objectives;
            _movement = movement;
            _communication = communication;
        }

        public void OnEnter()
        {
            Debug.Log("Investigating");
            _movement.SetRunningSpeed();
            _communication.CommunicatePosition(_objectives.PositionOfInterest);
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
