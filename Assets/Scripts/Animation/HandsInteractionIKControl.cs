using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Serialization;

[RequireComponent(typeof(Animator))]
public class HandsInteractionIKControl : MonoBehaviour
{
    private const float IKPositionWeight = .6f;
    private const float IKRotationWeight = .15f;
    
    [Header("Setup")] 
    [SerializeField] private Transform leftHandTransform;
    [SerializeField] private Transform rightHandTransform;

    [Header("Values")] 
    [SerializeField] private float raiseHandsAnimationSpeed = 1f;
    [SerializeField] private float lowerHandsAnimationSpeed = .6f;
    [SerializeField] private float handAnimationStayTimer = 4f;

    private Animator animator;
    private Transform cameraTransform;

    private float currentIKPositionWeight = 0;
    private float currentIKRotationWeight = 0;
    private float currentHandAnimationStayTimer = 0;

    public bool RaiseHands { get; set; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        if (RaiseHands)
        {
            //increases the Ik weights if we are raising hands
            currentIKPositionWeight = Mathf.Clamp(currentIKPositionWeight += Time.deltaTime * raiseHandsAnimationSpeed, 0, IKPositionWeight);
            currentIKRotationWeight = Mathf.Clamp(currentIKRotationWeight += Time.deltaTime * raiseHandsAnimationSpeed, 0, IKRotationWeight);
            
            //If we are raising hands reset the stayTimer to original value
            currentHandAnimationStayTimer = handAnimationStayTimer;
        }
        else
        {
            //Only lower hands when the stay timer is bellow 0
            if (currentHandAnimationStayTimer > 0)
            {
                currentHandAnimationStayTimer -= Time.deltaTime;
                return;
            }

            //decreases the Ik weights if we are lowering hands
            currentIKPositionWeight = Mathf.Clamp(currentIKPositionWeight -= Time.deltaTime * lowerHandsAnimationSpeed, 0, IKPositionWeight);
            currentIKRotationWeight = Mathf.Clamp(currentIKRotationWeight -= Time.deltaTime * lowerHandsAnimationSpeed, 0, IKRotationWeight);
        }
    }

    //a callback for calculating IK
    private void OnAnimatorIK(int layerIndex)
    {
        if (animator)
        {
            // Set the look target position
            if (cameraTransform != null)
            {
                animator.SetLookAtWeight(1);
                animator.SetLookAtPosition(cameraTransform.position + Vector3.forward * 500);
            }

            // Set the right hand target position and rotation
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, currentIKPositionWeight);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, currentIKRotationWeight);
            animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandTransform.position);
            animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandTransform.rotation);

            // Set the left hand target position and rotation
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, currentIKPositionWeight);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, currentIKRotationWeight);
            animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTransform.position);
            animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTransform.rotation);
        }
    }
}