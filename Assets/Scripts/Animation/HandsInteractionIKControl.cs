using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))] 

public class HandsInteractionIKControl : MonoBehaviour {
    
    [SerializeField] private bool ikActive = false;
    
    [SerializeField] private Transform leftHandTransform;
    [SerializeField] private Transform rightHandTransform;
    
    private Animator animator;
    private Transform cameraTransform;
    
    void Awake () 
    {
        animator = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
    }
    
    //a callback for calculating IK
    void OnAnimatorIK()
    {
        if(animator) {
            
            //if the IK is active, set the position and rotation directly to the goal. 
            if(ikActive) {

                // Set the look target position, if one has been assigned
                if(cameraTransform != null) {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(cameraTransform.position + Vector3.forward * 5);
                }    

                // Set the right hand target position and rotation, if one has been assigned
               
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand,.7f);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand,.7f);  
                    animator.SetIKPosition(AvatarIKGoal.RightHand,rightHandTransform.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand,rightHandTransform.rotation);
                  
                    
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,.7f);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,.7f);  
                    animator.SetIKPosition(AvatarIKGoal.LeftHand,leftHandTransform.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand,leftHandTransform.rotation);
            }
            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else {          
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand,0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand,0); 
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,0); 
                animator.SetLookAtWeight(0);
            }
        }
    }    
}