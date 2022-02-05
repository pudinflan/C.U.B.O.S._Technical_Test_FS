using Audio;
using UI.Menu;
using UnityEngine.SceneManagement;

namespace Architecture.StateMachine
{
    public class Menu : IState
    {
        public void OnStateUpdate() { }

        public void OnStateEnter()
        {
            PlayButton.LevelToLoad = null;
            SceneManager.LoadSceneAsync("Menu");
            AudioManager.Instance.StopMusic();
        }

        public void OnStateExit() { }
    }
}