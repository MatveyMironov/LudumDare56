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
            InvestigatingState investigating = new(controller.Objectives, controller.Movement);
            FightingState fighting = new(controller.Perception, controller.Movement, controller.Weapon, controller.transform);

            _stateMachine.AddTransition(sleeping, patroling, () => controller.IsPatroling);
            _stateMachine.AddTransition(patroling, investigating, () => controller.Objectives.PositionOfInterest != Vector3.zero);
            _stateMachine.AddTransition(investigating, patroling, investigating.HasReachedPosition);
            _stateMachine.AddTransition(fighting, patroling, () => controller.Perception.PercievedPlayer == null);

            _stateMachine.AddAnyTransition(fighting, () => controller.Perception.PercievedPlayer != null);

            _stateMachine.SetState(sleeping);
        }

        public void OnEnter()
        {

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
