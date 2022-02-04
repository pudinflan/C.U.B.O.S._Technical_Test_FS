using System;
using UnityEngine;

namespace Interactables.PowerUps
{
    public class PowerUp : Interactable
    {
        [SerializeField] protected float boostDuration;
        
        public static event Action<float> OnPowerUpUsed;
        
        /// <summary>
        /// Override for More Complex Behaviours on PowerUp used like FX, Sound, etc.
        /// </summary>
        protected virtual void Used()
        {
            OnPowerUpUsed?.Invoke(boostDuration);
            
            //TODO: Debug do FX here Like sound and Particles
            Destroy(gameObject);
        }
    }
}