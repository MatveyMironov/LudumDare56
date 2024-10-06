using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class AttackingState : IState
    {
        private EnemyPerception _perception;
        private EnemyMovement _movement;

        public AttackingState(EnemyPerception perception, EnemyMovement movement)
        {
            _perception = perception;
            _movement = movement;
        }

        public void OnEnter()
        {
            Debug.Log("Attacking");

        }

        public void OnExit()
        {

        }

        public void Tick()
        {
            
        }

        private void PersueTarget(NavMeshAgent agent, Transform target, float desiredDistance)
        {
            
        }
    }
}
