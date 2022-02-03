using System;
using Architecture.Variables;
using UnityEngine;

namespace Interactables.PowerUps
{
    public class SpeedPowerUp : Interactable
    {
        [Header("Values")] 
        [SerializeField] private float speedBoost;
        [SerializeField] private float duration;
        
        [Header("Variables")]
        [SerializeField] private FloatVariable speedVariable;

        private float baseSpeed;

        public override void ExecuteActionLeft()
        {
            base.ExecuteActionLeft();
            ModifySpeed(duration);
        }

        public override void ExecuteActionRight()
        {
            base.ExecuteActionRight();
            ModifySpeed(duration);
        }

        public override void LeftActionFinished()
        {
            base.LeftActionFinished();
            ResetSpeed();
            Destroy(gameObject);
        }

        public override void RightActionFinished()
        {
            base.RightActionFinished();
            ResetSpeed();
            Destroy(gameObject);
        }

        private void ModifySpeed(float value)
        {
            //cache base speed
            baseSpeed = speedVariable.Value;
            //modify speed
            speedVariable.Value = speedBoost;
        }

        private void ResetSpeed()
        {
            //reset speed to default
            //speedVariable.Value = baseSpeed;
        }
    }
}
