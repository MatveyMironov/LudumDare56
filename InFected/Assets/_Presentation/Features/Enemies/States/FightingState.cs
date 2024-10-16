using UnityEngine;

namespace Enemy
{
    public class FightingState : IState
    {
        private EnemyPerception _perception;
        private EnemyMovement _movement;
        private EnemyCommunication _communication;
        private EnemyWeapon _weapon;
        private EnemyController.EnemyObjectives _objectives;

        public FightingState(EnemyPerception perception, EnemyMovement movement, EnemyCommunication communication, EnemyWeapon weapon, EnemyController.EnemyObjectives objectives)
        {
            _perception = perception;
            _movement = movement;
            _communication = communication;
            _weapon = weapon;
            _objectives = objectives;
        }

        public void OnEnter()
        {
            Debug.Log("Fighting");
            _movement.SetRunningSpeed();
        }

        public void OnExit()
        {
            
        }

        public void Tick()
        {
            _objectives.PositionOfInterest = _perception.PercievedPlayer.transform.position;
            _communication.CommunicatePosition(_objectives.PositionOfInterest);
            _movement.MoveTo(_perception.PercievedPlayer.transform.position);

            float requiredDistance = _perception.PercievedPlayer.Collider.radius + _weapon.AttackDistance - 0.1f;
            if (_movement.RemainingDistance <= requiredDistance)
            {
                _movement.StopMoving();

                if (_weapon.ReadyToUse)
                {
                    _weapon.Use();
                }
            }
            else
            {
                _movement.StartMoving();
            }

            _weapon.FunctioningTick();
        }
    }
}
