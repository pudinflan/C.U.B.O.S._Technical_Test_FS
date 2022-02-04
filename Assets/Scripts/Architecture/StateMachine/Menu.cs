using UI.Menu;

namespace Architecture.StateMachine
{
    public class Menu : IState
    {
        public void OnStateUpdate() { }

        public void OnStateEnter() => PlayButton.LevelToLoad = null;

        public void OnStateExit() { }
    }
}