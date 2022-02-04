using Architecture.Variables;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Variables")]
        [SerializeField] private FloatVariable moveSpeed;
        
        [Header("Rotation")]
        [SerializeField] private float turnSpeedX = 50f;
        [SerializeField] private float turnSpeedY = 50f;
        [SerializeField] private Animator animator;
    
        private Rigidbody rb;
        private Transform cameraTransform;

        private float mouseX;
        private float mouseY;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            cameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            mouseX += Input.GetAxis("Mouse X");
            mouseY += Input.GetAxis("Mouse Y") ;
        }

        private void FixedUpdate()
        {
            Rotation();
            Movement();
        }

        private void Movement()
        {
            float hor = Input.GetAxis("Horizontal");
            float vert = Input.GetAxis("Vertical");
            
            var velocity = new Vector3(hor, 0, vert);
            velocity *= moveSpeed.Value * Time.fixedDeltaTime;
            Vector3 movementOffset = transform.rotation * velocity;
            rb.MovePosition(transform.position + movementOffset);
            
            animator.SetFloat("Horizontal", hor, 0.15f,Time.fixedDeltaTime);
            animator.SetFloat("Vertical", vert, 0.15f,Time.fixedDeltaTime);
        }

        private void Rotation()
        {
            //rotate camera X and Clamp its value so it doesnt turn at impossible angles for human heads
            var clampedRotationAngle = Mathf.Clamp(mouseY  * turnSpeedY * Time.fixedDeltaTime, -70f, 70f);
            cameraTransform.localRotation = Quaternion.Euler(-clampedRotationAngle, 0f, 0f);

            //rotate player on the Y Axis
            transform.Rotate(0, mouseX * turnSpeedX * Time.fixedDeltaTime, 0);
            mouseX = 0;
        }
    }
}
