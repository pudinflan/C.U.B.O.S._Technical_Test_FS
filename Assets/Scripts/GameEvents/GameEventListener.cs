using UnityEngine;
using UnityEngine.Events;

namespace GameEvents
{
   public class GameEventListener : MonoBehaviour
   {
      [Tooltip("Game event that will be listened")]
      [SerializeField] private GameEvent gameEvent;
      
      [Tooltip("What will be executed after event is listened")]
      [SerializeField] private UnityEvent onGameEventInvoked;
   
      private void Awake() => gameEvent.Register(this);
      private void OnDisable() => gameEvent.DeRegister(this);
   
      /// <summary>
      /// Raises the UnityEvent event attached the listener
      /// </summary>
      public void OnGameEventRaised() => onGameEventInvoked.Invoke();
   }
}
