namespace Architecture.StateMachine
{
    public interface IState
    {
        void OnStateUpdate();
        void OnStateEnter();
        void OnStateExit();
    }
}