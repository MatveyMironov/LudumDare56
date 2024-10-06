using UnityEngine;

namespace Enemy
{
    public class ActiveState : IState
    {
        private EnemyController _controller;

        private StateMachine _stateMachine;

        public ActiveState(EnemyController controller)
        {
            _controller = controller;

            _stateMachine = new StateMachine();

            SleepingState sleeping = new();
            PatrolingState patroling = new(controller.Movement, controller.Objectives);
            FightingState fighting = new(controller.Perception, controller.Movement, controller.Weapon, controller.transform);

            _stateMachine.AddTransition(sleeping, patroling, () => controller.IsPatroling);
            _stateMachine.AddTransition(patroling, fighting, () => controller.Perception.PercievedPlayer != null);
            _stateMachine.AddTransition(fighting, patroling, () => controller.Perception.PercievedPlayer == null);

            _stateMachine.SetState(sleeping);
        }

        public void OnEnter()
        {
            Debug.Log("Active");
            _stateMachine.EnterCurrentState();
        }

        public void OnExit()
        {

        }

        public void Tick()
        {
            _controller.Perception.Use(_controller.transform);
            _stateMachine.Tick();
        }
    }
}
