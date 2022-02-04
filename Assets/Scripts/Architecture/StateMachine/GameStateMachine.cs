using UnityEngine;

namespace Architecture.StateMachine
{
    public class GameStateMachine : MonoBehaviour
    {
        private StateMachine stateMachine;

        void Awake()
        {
            stateMachine = new StateMachine();

            var menu = new Menu();
            var loading = new LoadLevel();
            var play = new Play();
            var pause = new Pause();
            
            //loads our level
            stateMachine.SetState(loading);
        }
    }

    public class Menu : IState
    {
        public void OnStateUpdate()
        {
        }

        public void OnStateEnter()
        {
        }

        public void OnStateExit()
        {
        }
    }

    public class Play : IState
    {
        public void OnStateUpdate()
        {
        }

        public void OnStateEnter()
        {
        }

        public void OnStateExit()
        {
        }
    }

    public class LoadLevel : IState
    {
        public void OnStateUpdate()
        {
        }

        public void OnStateEnter()
        {
        }

        public void OnStateExit()
        {
        }
    }
    
    public class Pause : IState
    {
        public void OnStateUpdate()
        {
        }

        public void OnStateEnter()
        {
        }

        public void OnStateExit()
        {
        }
    }
}