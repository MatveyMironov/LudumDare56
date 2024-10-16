using UnityEngine;

namespace Enemy
{
    public class ActiveState : IState
    {
        private EnemyPerception _perception;

        private StateMachine _stateMachine;

        public ActiveState(EnemyMovement movement, EnemyPerception perception, EnemyCommunication communication, EnemyWeapon weapon, EnemyController.EnemyObjectives objectives)
        {
            _perception = perception;

            _stateMachine = new StateMachine();

            StandingState standing = new(movement);
            PatrolingState patroling = new(objectives, movement);
            InvestigatingState investigating = new(objectives, movement, communication);
            FightingState fighting = new(perception, movement, communication, weapon, objectives);

            _stateMachine.AddTransition(standing, patroling, () => objectives.IsPatroling);
            _stateMachine.AddTransition(patroling, standing, () => !objectives.IsPatroling);
            _stateMachine.AddTransition(patroling, standing, () => objectives.Waypoins.Length == 0);
            _stateMachine.AddTransition(standing, investigating, () => objectives.PositionOfInterest != Vector3.zero);
            _stateMachine.AddTransition(patroling, investigating, () => objectives.PositionOfInterest != Vector3.zero);
            _stateMachine.AddTransition(investigating, patroling, investigating.HasReachedPosition);
            _stateMachine.AddTransition(fighting, investigating, () => perception.PercievedPlayer == null);

            _stateMachine.AddAnyTransition(fighting, () => perception.PercievedPlayer != null);

            _stateMachine.SetState(standing);
        }

        public void OnEnter()
        {
            Debug.Log("Active");

        }

        public void OnExit()
        {

        }

        public void Tick()
        {
            _perception.Use();
            _stateMachine.Tick();
        }
    }
}
