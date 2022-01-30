using UnityEngine;

namespace Interaction
{
    public class PlayerInteraction : MonoBehaviour
    {
        private const float InteractionRange = 200f;

        [SerializeField] private LayerMask interactableLayer;
    
        private Transform cameraTransform;
    
        public IInteractable CurrentInteractable { get; private set; }
    
        private void Awake() => cameraTransform = Camera.main.transform;

        private void Update()
        {
            CheckForInteractable();
            CheckForInteraction();
        }

        private void CheckForInteractable()
        {
            //launch ray forward from camera center. Filters by LayerMask set on the Inspector
            bool interactableInRange = Physics.Raycast(cameraTransform.position, cameraTransform.TransformDirection
                (Vector3.forward), out var raycastHit, InteractionRange, interactableLayer);

            //check if an interactable object is found
            if (interactableInRange)
            {
                //TODO: remove this getComponent later (can be expensive)
                //If Interactable found set it
                CurrentInteractable = raycastHit.collider.GetComponent<IInteractable>();
            
                if (CurrentInteractable != null)
                {
                    //TODO: Maybe delete later
                    //TODO: Do Interactable Found Stuff like communicating with the Gloves to turn The color dependent on the Cube interactalble type
                    Debug.Log($"Interactable in range: {CurrentInteractable}");
                }
                else
                {
                    ClearInteractable();
                }
            }
            else
            {
                ClearInteractable();
            }
        }

        private void ClearInteractable()
        {
            //TODO: Do Interactable Clear Stuff Communicate with gloves to Stop the Interaction animation
            CurrentInteractable = null;
        }

        private void CheckForInteraction()
        {
            //TODO: Move this to an input System
            if (Input.GetMouseButtonDown(0) && CurrentInteractable != null) 
                CurrentInteractable.InteractLeft();
            else if (Input.GetMouseButtonDown(1) && CurrentInteractable != null)
                CurrentInteractable.InteractRight();
        }
    }
}
