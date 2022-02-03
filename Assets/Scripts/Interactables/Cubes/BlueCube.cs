using System;
using UnityEngine;

namespace Interactables.Cubes
{
    public class BlueCube : Interactable
    {
        private static readonly int Raised = Animator.StringToHash("Raised");
        
        [SerializeField] private float pushForce = 10f;
        [SerializeField] private bool raised;

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public override void InteractLeft()
        {
            base.InteractLeft();
            RaiseCube();
        }

        public override void InteractRight()
        {
            base.InteractRight();
            LowerCube();
        }

        private void RaiseCube()
        {
            if (raised)
                return;
            raised = true;
            
            animator.SetBool(Raised, raised);
        }

        private void LowerCube()
        {
            if (!raised)
                return;
            raised = false;
            
            animator.SetBool(Raised, raised);
        }
        
        private void Bounce(Collider other)
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * pushForce, ForceMode.Impulse);
            RaiseCube();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (raised)
                    return;
                
                Bounce(other);
            }
        }
    }
}