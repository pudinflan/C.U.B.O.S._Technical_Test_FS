using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerJump : MonoBehaviour
    {
        [Header("Values")] 
        [SerializeField] private float jumpForce = 5f;

        [Header("Setup")] 
        [SerializeField] private LayerMask groundLayer;
    
        [Tooltip("The origin of the ground check capsule")] 
        [SerializeField] private Vector3 groundCheckRayOrigin = new Vector3(0,0.05f,0);
        [Tooltip("The max distance the ground check Capsule will detect (tolerance)")] 
        [SerializeField] private float groundCheckDistance = 0.01f;

        [SerializeField] private Animator animator;

        private Rigidbody rb;
        private float capsuleRadius;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            capsuleRadius = GetComponent<CapsuleCollider>().radius;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) 
                Jump();
            
            animator.SetBool("Grounded", IsGrounded());
        }

        private void Jump()
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        private bool IsGrounded()
        {
            return Physics.CheckCapsule(groundCheckRayOrigin + transform.position, transform.position + Vector3.down *
                groundCheckDistance, capsuleRadius, groundLayer);
        }

        private void OnDrawGizmos()
        {
            //Draws the ground check rays for visualization, if the player is grounded the ray is green otherwise is red
            Gizmos.color = IsGrounded() ? Color.green : Color.red;
            Gizmos.DrawLine( transform.position + groundCheckRayOrigin, transform.position + Vector3.down * groundCheckDistance);
            Gizmos.DrawLine( transform.position - new Vector3(capsuleRadius,0,0),  transform.position + new Vector3(capsuleRadius,0,0));
            Gizmos.DrawLine( transform.position - new Vector3(0,0,capsuleRadius),  transform.position + new Vector3(0,0,capsuleRadius));
        }
    }
}