using System;
using System.Collections.Generic;
using UnityEngine;

namespace Architecture.StateMachine
{
    public class StateMachine
    {
        private readonly List<StateTransition> stateTransitions = new List<StateTransition>(); 
        private readonly List<StateTransition> anyStateTransitions = new List<StateTransition>();
    
        private IState currentState;

        public event Action<IState> OnStateChanged;
        
        public IState CurrentState => currentState;

        public void AddAnyTransition(IState to, Func<bool> condition)
        {
            var stateTransition = new StateTransition(null, to, condition);
            anyStateTransitions.Add(stateTransition);
        }
    
        public void AddTransition(IState from, IState to, Func<bool> condition)
        {
            var stateTransition = new StateTransition(from, to, condition);
            stateTransitions.Add(stateTransition);
        }

        public void SetState(IState state)
        {
            if (currentState == state)
                return;
        
            currentState?.OnStateExit();
        
            currentState = state;
            Debug.Log($"Changed to state {state}");
            currentState?.OnStateEnter();
        
            OnStateChanged?.Invoke(currentState);
        }

        public void OnStateUpdate()
        {
            StateTransition transition = CheckForTransition();
            if (transition != null)
            {
                SetState(transition.To);
            }
            currentState.OnStateUpdate();
        }

        private StateTransition CheckForTransition()
        {
            foreach (var transition in anyStateTransitions)
            {
                if (transition.Condition())
                    return transition;
            }
        
            foreach (var transition in stateTransitions)
            {
                if (transition.From == currentState && transition.Condition())
                    return transition;
            }

            return null;
        }
    }
}