using UnityEngine;

namespace Interactables
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        //TODO: REMOVE THIS FROM HERE, USE SCRIPTABLE OBJECTS
        [ColorUsage(true, true)]
        public Color glowColor = Color.cyan;

        protected bool CanInteract { get; set; } = true;

        public virtual bool CanBeInteracted()
        {
            return CanInteract;
        }

        public virtual void InteractLeft()
        {
            if (!CanBeInteracted())
                return;
            
        }

        public virtual void InteractRight()
        {
            if (!CanBeInteracted())
                return;
            
            
        }
    }
}