using Architecture.GameEvents;
using UnityEngine;

namespace Interactables.PowerUps
{
    public class GameEventTriggerPowerUp : Interactable
    {
        [SerializeField] private GameEvent gameEvent;

        public override void InteractLeft()
        {
            base.InteractLeft();
            
            CanInteract = false;
            Used();
        }

        public override void InteractRight()
        {
            base.InteractRight();
            
            CanInteract = false;
            Used();
        }

        private void Used()
        {
            gameEvent?.Invoke();
            Destroy(gameObject);
        }
    }
}