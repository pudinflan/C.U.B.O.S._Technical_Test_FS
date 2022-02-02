using System.Collections.Generic;
using UnityEngine;

namespace GameEvents
{
    [CreateAssetMenu(menuName = "Game Event")]
    public class GameEvent: ScriptableObject
    {
        //Hash set to ensure the GameEvent only use one Instance of a particular GameEventListener
        //Prevents unintended repeated invocations
        private  HashSet<GameEventListener> gameEventListeners = new HashSet<GameEventListener>();
        
        /// <summary>
        /// Invokes the GameEvent on all Listeners
        /// </summary>
        public void Invoke()
        {
            foreach (var gameEventListener in gameEventListeners) 
                gameEventListener.OnGameEventRaised();
        }
        
        /// <summary>
        /// Registers this event on the supplied GameEventListener
        /// </summary>
        /// <param name="gameEventListener"></param>
        public void Register(GameEventListener gameEventListener) => gameEventListeners.Add(gameEventListener);
        
        /// <summary>
        /// Unregisters this event on the supplied GameEventListener
        /// </summary>
        /// <param name="gameEventListener"></param>
        public void DeRegister(GameEventListener gameEventListener) => gameEventListeners.Remove(gameEventListener);
    }
}