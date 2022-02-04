using System;
using Managers;
using UI.Menu;
using UI.Pausing;
using UnityEngine;

namespace Architecture.StateMachine
{
    public class GameStateMachine : MonoBehaviour
    {
        private static bool _initialized;
        
        private StateMachine stateMachine;

        public static event Action<IState> OnGameStateChanged; 

        void Awake()
        {
            if (_initialized)
            {
                Destroy(gameObject);
                return;
            }
            _initialized = true;
            DontDestroyOnLoad(gameObject);

            stateMachine = new StateMachine();
            
            //when the stateMachine changed state notify that GameStateMachine also changed state
            stateMachine.OnStateChanged += state => OnGameStateChanged?.Invoke(state);

            var menu = new Menu();
            var loading = new LoadLevel();
            var play = new Play();
            var pause = new Pause();
            var gameOver = new GameOver();

            //loads our level
            stateMachine.SetState(menu);

            //transitions
            stateMachine.AddTransition(menu,loading, () => PlayButton.LevelToLoad != null);
            
            //transitions from loading to play if loading operation is finished
            stateMachine.AddTransition(loading, play, loading.Finished);

            //transitions between play and pause back and forth
            stateMachine.AddTransition(play, pause, () => Input.GetKeyDown(KeyCode.Escape));
            stateMachine.AddTransition(pause, play, () => Input.GetKeyDown(KeyCode.Escape));
            
            //Transitions to loading to restart the level when RestartButton is Pressed
            stateMachine.AddTransition(pause, loading, () => RestartButton.Pressed);
            
            //Transitions to Menu state when menu button is pressed
            stateMachine.AddTransition(pause, menu, () => MenuButton.Pressed);
            
            //transitions to GameOver when GameOver is called from 
            stateMachine.AddTransition(play,gameOver, () => ScoreManager.GoalReached);
        }

        private void Update() => stateMachine.OnStateUpdate();
    }
}