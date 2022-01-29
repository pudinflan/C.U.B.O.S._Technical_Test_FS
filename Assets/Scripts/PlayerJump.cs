using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{

    
    [Header("Values")] 
    [SerializeField] private float jumpForce = 275f;

    [Header("Setup")] 
    [SerializeField] private LayerMask groundLayer;
    
    [Tooltip("The origin of the ground check ray")] 
    [SerializeField] private Vector3 groundCheckRayOrigin = new Vector3(0,0.05f,0);
    [Tooltip("The max distance the ground check ray will detect (tolerance)")] 
    [SerializeField] private float groundCheckDistance = .5f;

    private Rigidbody rb;

    private bool isGrounded;

    private void Awake() => rb = GetComponent<Rigidbody>();

    private void Update()
    {
        //Checks if the player is touching the ground (an object with a collider and marked with the "Ground" layer)
        isGrounded = Physics.Raycast(transform.position + groundCheckRayOrigin, Vector3.down, groundCheckDistance, groundLayer);

        //If its grounded and we pressed jump, apply the force on rigidbody to jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
            rb.AddForce(Vector3.up * jumpForce);
    }

    private void OnDrawGizmos()
    {
        //Draws the ground check ray for visualization, if the player is grounded the ray is green otherwise is red
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawLine( transform.position + groundCheckRayOrigin, transform.position + groundCheckRayOrigin + new Vector3(0, -groundCheckDistance, 0));
    }
}