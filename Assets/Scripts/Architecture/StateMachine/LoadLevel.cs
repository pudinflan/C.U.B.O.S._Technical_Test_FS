using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture.StateMachine
{
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
}