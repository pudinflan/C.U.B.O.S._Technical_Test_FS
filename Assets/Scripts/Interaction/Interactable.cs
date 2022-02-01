using System;
using UnityEngine;

namespace Interaction
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        //TODO: REMOVE THIS FROM HERE, USE SCRIPTABLE OBJECTS
        [ColorUsage(true, true)]
        public Color glowColor = Color.cyan;
        
        public virtual bool CanInteract()
        {
            return true;
        }

        public virtual void InteractLeft()
        {
            if (!CanInteract())
                return;

            Debug.Log($"Interacting LEFT with: {gameObject.name}");
            ExecuteActionLeft();
        }

        public virtual void InteractRight()
        {
            if (!CanInteract())
                return;
            
            
            Debug.Log($"Interacting RIGHT with: {gameObject.name}");
            ExecuteActionRight();
        }
        
        public virtual void ExecuteActionLeft()
        {
            //TODO: Probably an asying or IEnumerator to do sequential and timing stuff
            Debug.Log($"LEFT Action Executing on: {gameObject.name}");
            LeftActionFinished();
        }
        
        public virtual void ExecuteActionRight()
        {
            //TODO: Probably an asying or IEnumerator to do sequential and timing stuff
            Debug.Log($"RIGHT Action Executing on: {gameObject.name}");
            RightActionFinished();
        }

        public virtual void LeftActionFinished()
        {
            //TODO: Do action finish stuff probably reset Can Interact
            Debug.Log($"LEFT Action Finished on: {gameObject.name}");
        }
        
        public virtual void RightActionFinished()
        {
            //TODO: Do action finish stuff probably reset Can Interact
            Debug.Log($"RIGHT Action Finished on: {gameObject.name}");
        }

    }
}