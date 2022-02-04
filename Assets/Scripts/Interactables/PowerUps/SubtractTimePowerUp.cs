using Architecture.Variables;
using UnityEngine;

namespace Interactables.PowerUps
{
    public class SubtractTimePowerUp : Interactable
    {
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
            
            //TODO: Remove This When PowerUp gets more abstraction
            Destroy(gameObject);
        }
    }
}
