using UnityEngine;

namespace Enemy
{
    public class StandingState : IState
    {
        private EnemyMovement _movement;

        public StandingState(EnemyMovement movement)
        {
            _movement = movement;
        }

        public void OnEnter()
        {
            Debug.Log("Standing");
            _movement.StopMoving();
        }

        public void OnExit()
        {

        }

        public void Tick()
        {

        }
    }
}
