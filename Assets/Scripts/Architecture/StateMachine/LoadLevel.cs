using UI.Menu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture.StateMachine
{
    public class LoadLevel : IState
    {
        private AsyncOperation operation = new AsyncOperation();

        public bool Finished() => operation.isDone;

        public void OnStateUpdate() { }

        public void OnStateEnter() => operation = SceneManager.LoadSceneAsync(PlayButton.LevelToLoad);

        public void OnStateExit() => operation = null;
    }
}