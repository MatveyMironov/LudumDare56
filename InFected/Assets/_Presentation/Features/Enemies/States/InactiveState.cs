using UnityEngine;

namespace Enemy
{
    public class InactiveState : IState
    {
        public InactiveState()
        {

        }

        public void OnEnter()
        {
            Debug.Log("Inactive");

        }

        public void OnExit()
        {

        }

        public void Tick()
        {

        }
    }
}
