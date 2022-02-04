using UnityEngine;

namespace Architecture.StateMachine
{
    public class Play : IState
    {
        public void OnStateUpdate() { }

        public void OnStateEnter()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnStateExit()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
       
    }
}