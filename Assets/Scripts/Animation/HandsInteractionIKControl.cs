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
    [SerializeField] private Transform leftHandIkTarget;
    [SerializeField] private Transform rightHandIkTarget;

    [Header("Values")]
    [Tooltip("The speed of the hands raising animation")]
    [SerializeField] private float raiseHandsAnimationSpeed = 1f;
    [Tooltip("The speed of the hands lowering animation")]
    [SerializeField] private float lowerHandsAnimationSpeed = .6f;
    [Tooltip("How long the hands will linger on Interaction pose before lowering")]
    [SerializeField] private float handAnimationStayTimer = 4f;

    private Animator animator;
    private Transform cameraTransform;

    private bool raiseHands;

    private float currentIKPositionWeight = 0;
    private float currentIKRotationWeight = 0;
    private float currentHandAnimationStayTimer = 0;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        if (raiseHands)
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
            animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandIkTarget.position);
            animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandIkTarget.rotation);

            // Set the left hand target position and rotation
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, currentIKPositionWeight);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, currentIKRotationWeight);
            animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandIkTarget.position);
            animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandIkTarget.rotation);
        }
    }
    
    /// <summary>
    /// Tells the IKController Raise / Lower Hands for interaction (True: raise; False: lower)
    /// Then processes the raising/lowering on this class Update
    /// </summary>
    /// <param name="raise"></param>
    public void RaiseHands(bool raise) => raiseHands = raise;
}