using Interaction;
using UnityEngine;

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
            Debug.Log("CHanging color to white");
            handsColorControl.SetGlowColor(Color.white);
            return;
        }
        
        
        if (interactable is RedCube redCube)
        {
            Debug.Log("CHanging color to red");
            handsColorControl.SetGlowColor(redCube.glowColor);
        }
    }

}