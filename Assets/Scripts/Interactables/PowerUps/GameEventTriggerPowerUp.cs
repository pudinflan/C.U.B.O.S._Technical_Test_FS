using Architecture.GameEvents;
using UnityEngine;

namespace Interactables.PowerUps
{
    public class GameEventTriggerPowerUp : PowerUp
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

        protected override void Used()
        {
            gameEvent?.Invoke();
            base.Used();
        }
    }
}