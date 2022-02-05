using System;
using Audio;
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
            AudioManager.Instance.PlayAudioFX(audioSource.clip);
            OnPowerUpUsed?.Invoke(boostDuration);
            Destroy(gameObject);
        }
    }
}