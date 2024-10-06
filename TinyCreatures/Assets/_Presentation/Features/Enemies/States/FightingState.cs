using TMPro;
using UnityEngine;
using UnityEngine.AI;

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
            Debug.Log("Fighting");
            _movement.SetRunningSpeed();
            _movement.Agent.isStopped = false;
        }

        public void OnExit()
        {

        }

        public void Tick()
        {
            _movement.Agent.SetDestination(_perception.PercievedPlayer.transform.position);
            if (_movement.Agent.remainingDistance < 1)
            {
                _movement.Agent.isStopped = true;
            }
            else
            {
                _movement.Agent.isStopped = false;
            }

            _weapon.FunctioningTick();
            _weapon.Use(_enemyTransform, _perception.PercievedPlayer);
        }
    }
}
