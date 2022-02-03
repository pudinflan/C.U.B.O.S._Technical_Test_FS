using System.Threading.Tasks;
using Architecture.Variables;
using UnityEngine;

namespace Interactables.PowerUps
{
    public class TimedPowerUp : Interactable
    {
        [Header("Values")] [SerializeField] private FloatVariable boostVariable;

        [SerializeField] private FloatVariable durationVariable;

        [Header("Variables")] [SerializeField] private FloatVariable variableToModify;

        private float variableDefaultValue;

        public override void ExecuteActionLeft()
        {
            base.ExecuteActionLeft();
            CanInteract = false;
            ModifyDuringDuration(boostVariable.Value, durationVariable.Value);
        }

        public override void ExecuteActionRight()
        {
            base.ExecuteActionRight();
            CanInteract = false;
            ModifyDuringDuration(boostVariable.Value, durationVariable.Value);
        }

        protected virtual async void ModifyDuringDuration(float value, float duration)
        {
            Used();

            //cache Variable To modify Base Value
            variableDefaultValue = variableToModify.Value;
            //modify Variable
            variableToModify.Value = boostVariable.Value;

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
            //Debug
            Destroy(gameObject);
        }

        protected virtual void Finished()
        {
            //reset speed to default
            variableToModify.Value = variableDefaultValue;
        }
    }
}