using UnityEngine;

namespace Enemy
{
    public class FightingState : IState
    {
        private EnemyPerception _perception;
        private EnemyMovement _movement;
        private EnemyWeapon _weapon;
        private Transform _enemyTransform;

        public FightingState(EnemyPerception perception, EnemyMovement movement, EnemyWeapon weapon, Transform enemyTransform)
        {
            _perception = perception;
            _movement = movement;
            _weapon = weapon;
            _enemyTransform = enemyTransform;
        }

        public void OnEnter()
        {
            _movement.SetRunningSpeed();
        }

        public void OnExit()
        {

        }

        public void Tick()
        {
            _movement.MoveTo(_perception.PercievedPlayer.transform.position);

            if (_movement.RemainingDistance < 1)
            {
                _movement.StopMoving();
            }
            else
            {
                _movement.StartMoving();
            }

            _weapon.FunctioningTick();
            _weapon.Use(_enemyTransform, _perception.PercievedPlayer);
        }
    }
}
