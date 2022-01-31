using System;
using Interaction;
using UnityEngine;

[RequireComponent(typeof(HandsInteractionIKControl))]
public class HandsAnimationControl : MonoBehaviour
{
    private Animator animator;
    private HandsInteractionIKControl handsIKControl;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        handsIKControl = GetComponent<HandsInteractionIKControl>();
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
     
    }

    private void PlayerInteractionOnInteractRight(IInteractable interactable)
    {
        animator.SetTrigger("InteractRight");
      
    }

    private void PlayerInteractionOnInteractableFound(IInteractable interactable)
    {
        Debug.Log($"Interactable Found: {interactable}");
        handsIKControl.RaiseHands = (Interactable) interactable ;
    }
}