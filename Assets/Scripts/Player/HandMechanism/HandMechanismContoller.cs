using Interactables;
using Interactables.Cubes;
using UnityEngine;

namespace Player.HandMechanism
{
    public class HandMechanismContoller : MonoBehaviour
    {
        private HandsColorControl handsColorControl;

        private void Awake()
        {
            handsColorControl = GetComponent<HandsColorControl>();
        }

        private void OnEnable() => PlayerInteraction.OnInteractableFound += PlayerInteractionOnInteractableFound;

        private void OnDisable() => PlayerInteraction.OnInteractableFound -= PlayerInteractionOnInteractableFound;

        private void PlayerInteractionOnInteractableFound(IInteractable interactable)
        {
            if (interactable == null)
            {
                handsColorControl.SetGlowColor(Color.black);
                return;
            }
            
            if (interactable is Interactable interactableObject)
                handsColorControl.SetGlowColor(interactableObject.glowColor);
        }

    }
}