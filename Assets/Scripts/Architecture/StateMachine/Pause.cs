using UnityEngine;

namespace Architecture.StateMachine
{
    public class Pause : IState
    {
        public static bool Active { get; private set; }
        
        public void OnStateUpdate() { }

        public void OnStateEnter()
        {
            Active = true;
            Time.timeScale = 0f;
        }

        public void OnStateExit()
        {
            Active = false;
            Time.timeScale = 1f;
        }
    }
}