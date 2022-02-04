using System;
using System.Threading.Tasks;
using Architecture.Variables;
using UnityEngine;

namespace Interactables.PowerUps
{
    public class TimedPowerUp : Interactable
    {
        public static event Action<float> OnPowerUpUsed;
        
        [Header("Values")] 
        [SerializeField] private float boostedValue;
        [SerializeField] private float boostDuration;

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

        /// <summary>
        /// Override for More Complex Behaviours on PowerUp used like FX, Sound, etc.
        /// </summary>
        protected virtual void Used()
        {
            OnPowerUpUsed?.Invoke(boostDuration);
            
            //TODO: Debug do FX here Like sound and Particles
            Destroy(gameObject);
        }

        protected virtual void Finished()
        {
            //reset speed to default
            variableToModify.Value = variableDefaultValue;
        }
    }
}