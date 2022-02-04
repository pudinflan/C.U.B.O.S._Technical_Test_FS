using System.Threading.Tasks;
using Architecture.Variables;
using UnityEngine;

namespace Interactables.PowerUps
{
    public class TimedPowerUp : PowerUp
    {
        [Header("Values")] 
        [SerializeField] private float boostedValue;
    

        [Header("Variables")] 
        [SerializeField] private FloatVariable variableToModify;

        private float variableDefaultValue;

        public override void InteractLeft()
        {
            base.InteractLeft();
            
            CanInteract = false;
            ModifyDuringDuration(boostDuration);
        }

        public override void InteractRight()
        {
            base.InteractRight();
            
            CanInteract = false;
            ModifyDuringDuration(boostDuration);
        }

        protected virtual async void ModifyDuringDuration(float duration)
        {
            Used();

            //cache Variable To modify Base Value
            variableDefaultValue = variableToModify.Value;
            //modify Variable
            variableToModify.Value = boostedValue;

            var end = Time.time + duration;
            while (Time.time < end)
                await Task.Yield();

            Finished();
        }
        
        protected virtual void Finished()
        {
        
            //reset speed to default
            variableToModify.Value = variableDefaultValue;
        }
    }
}