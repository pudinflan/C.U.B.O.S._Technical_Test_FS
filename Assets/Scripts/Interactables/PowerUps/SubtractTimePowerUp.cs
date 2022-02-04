using System;
using Architecture.Variables;
using UnityEngine;

namespace Interactables.PowerUps
{
    public class SubtractTimePowerUp : PowerUp
    {
        public static event Action<float> OnLevelTimeReduced; 

        [SerializeField] FloatVariable levelTime;
        [SerializeField] private float timeToSubtract = 5f;

        public override void InteractLeft()
        {
            base.InteractLeft();
            ReduceLevelTime();
        }

        public override void InteractRight()
        {
            base.InteractRight();
            ReduceLevelTime();
        }

        private void ReduceLevelTime()
        {
            if (levelTime.Value >= timeToSubtract)
                levelTime.Value -= timeToSubtract;
            else
                levelTime.Value = 0;
            
            OnLevelTimeReduced?.Invoke(timeToSubtract);
            
            Used();
        }
    }
}
