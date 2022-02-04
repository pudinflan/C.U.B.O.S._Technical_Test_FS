using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture.StateMachine
{
    public class GameStateMachine : MonoBehaviour
    {
        private StateMachine stateMachine;

        void Awake()
        {
            stateMachine = new StateMachine();

            var menu = new Menu();
            var loading = new LoadLevel("DemoLevel");
            var play = new Play();
            var pause = new Pause();
            
            //loads our level
            stateMachine.SetState(loading);
            
            //transitions
            //transitions from loading to play if loading operation is finished
            stateMachine.AddTransition(loading,play, loading.Finished); 
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
        private AsyncOperation operation = new AsyncOperation();

        private readonly string sceneToLoad;

        public bool Finished() => operation.isDone;
        
        public LoadLevel(string sceneName) => sceneToLoad = sceneName;

        public void OnStateUpdate()
        {
        }

        public void OnStateEnter() => operation = SceneManager.LoadSceneAsync(sceneToLoad);

        public void OnStateExit() => operation = null;
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