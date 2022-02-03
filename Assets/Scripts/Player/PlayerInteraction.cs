using System;
using Interactables;
using UnityEngine;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        private const float InteractionRange = 200f;

        [SerializeField] private LayerMask interactableLayer;

        private Transform cameraTransform;
        private IInteractable lastInteractable;

        public static event Action<IInteractable> OnInteractableFound;
        public static event Action<IInteractable> OnInteractLeft;
        public static event Action<IInteractable> OnInteractRight;

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

                if (CurrentInteractable == lastInteractable)
                    return;

                if (CurrentInteractable != null)
                {
                    lastInteractable = CurrentInteractable;
                    OnInteractableFound?.Invoke((Interactable)CurrentInteractable);
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
            if (CurrentInteractable != null)
            {
                //If we just left an Interaction range then we Notify for Interaction Lost which is the Same as Found Event with a null Interactable
                OnInteractableFound?.Invoke(null);
            }
          

            //TODO: Do Interactable Clear Stuff Communicate with gloves to Stop the Interaction animation
            lastInteractable = null;
            CurrentInteractable = null;
        }

        private void CheckForInteraction()
        {
            //TODO: Move this to an input System
            if (Input.GetMouseButtonDown(0))
            {
                CurrentInteractable?.InteractLeft();
                OnInteractLeft?.Invoke(CurrentInteractable);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                CurrentInteractable?.InteractRight();
                OnInteractRight?.Invoke(CurrentInteractable);
            }
        }
    }
}