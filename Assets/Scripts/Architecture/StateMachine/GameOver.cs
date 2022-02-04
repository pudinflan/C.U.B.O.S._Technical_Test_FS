using UnityEngine;

namespace Architecture.StateMachine
{
    public class GameOver: IState
    {
       
        public void OnStateUpdate()
        {
         
        }
        public void OnStateEnter()
        {
            Time.timeScale = 0f;
        }

        public void OnStateExit()
        {
            Time.timeScale = 1f;
        }
    }
}