using System;
using System.Collections.Generic;
using UnityEngine;

namespace Architecture.StateMachine
{
    public class GameStateMachine : MonoBehaviour
    {
        private static bool _initialized;
        
        private StateMachine stateMachine;

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

            var menu = new Menu();
            var loading = new LoadLevel("DemoLevel");
            var play = new Play();
            var pause = new Pause();

            //loads our level
            stateMachine.SetState(loading);

            //transitions
            //transitions from loading to play if loading operation is finished
            stateMachine.AddTransition(loading, play, loading.Finished);

            //transitions between play and pause back and forth
            stateMachine.AddTransition(play, pause, () => Input.GetKeyDown(KeyCode.Escape));
            stateMachine.AddTransition(pause, play, () => Input.GetKeyDown(KeyCode.Escape));
        }

        private void Update() => stateMachine.OnStateUpdate();
    }
}