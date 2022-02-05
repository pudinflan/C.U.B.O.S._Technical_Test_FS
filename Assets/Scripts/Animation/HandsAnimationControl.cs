using Audio;
using Interactables;
using Player;
using UnityEngine;

namespace Animation
{
    [RequireComponent(typeof(HandsInteractionIKControl))]
    public class HandsAnimationControl : MonoBehaviour
    {
        private Animator animator;
        private HandsInteractionIKControl handsIKControl;

        private AudioSource audioSource;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            handsIKControl = GetComponent<HandsInteractionIKControl>();
            audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            PlayerInteraction.OnInteractableFound += PlayerInteractionOnInteractableFound;
            PlayerInteraction.OnInteractLeft += PlayerInteractionOnInteractLeft;
            PlayerInteraction.OnInteractRight += PlayerInteractionOnInteractRight;
        }

        private void OnDisable()
        {
            PlayerInteraction.OnInteractableFound -= PlayerInteractionOnInteractableFound;
            PlayerInteraction.OnInteractLeft -= PlayerInteractionOnInteractLeft;
            PlayerInteraction.OnInteractRight -= PlayerInteractionOnInteractRight;
        }

        private void PlayerInteractionOnInteractLeft(IInteractable interactable)
        {
            animator.SetTrigger("InteractLeft");

       
                AudioManager.Instance.PlayAudioFX(audioSource.clip);
        }

        private void PlayerInteractionOnInteractRight(IInteractable interactable)
        {
            animator.SetTrigger("InteractRight");
            
           
                AudioManager.Instance.PlayAudioFX(audioSource.clip);
        }

        private void PlayerInteractionOnInteractableFound(IInteractable interactable)
        {
            handsIKControl.RaiseHands((Interactable) interactable);
        }
    }
}