using UnityEngine;

namespace Handlers
{
    [RequireComponent(typeof(Transform))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private bool useXMovement = true;
        [SerializeField] private bool useZMovement = true;
        
        [Header("Jumping")]
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private bool useJump = true;
        
        [Header("Ground Check")]
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private LayerMask platformLayer;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundCheckRadius = 0.1f;

        private Transform playerTransform;
        private Rigidbody playerRigidbody;
        private bool isGrounded;

        private void Start()
        {
            playerTransform = transform;
            playerRigidbody = GetComponent<Rigidbody>();

            // Lock the mouse in the center and hide it
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        private void Update()
        {
            CheckForGround();
            CheckForPlatform();
            Jump();
            Move();
            LookAround();
        }

        private void CheckForGround()
        {
            var groundCheckPosition = groundCheck.position;
            isGrounded = Physics.CheckSphere(groundCheckPosition, groundCheckRadius, groundLayer);
        }
        
        private void CheckForPlatform()
        {
            if (!isGrounded)
            {
                return;
            }
            
            var platformDetected = Physics.CheckSphere(groundCheck.position, groundCheckRadius, platformLayer);

            if (platformDetected)
            {
                var platform = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, platformLayer)[0].transform;
                playerTransform.parent = platform;
            }
            else
            {
                playerTransform.parent = null;
            }
        }

        private void Jump()
        {
            if (!Input.GetKeyDown(KeyCode.Space) || !useJump || !isGrounded)
            {
                return;
            }
            
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        private void Move()
        {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");
            
            var movement = new Vector3 
            ( 
                useXMovement ? x : 0f, 
                0f,
                useZMovement ? z : 0f
            );
      
            playerTransform.position += transform.forward * (movement.z * moveSpeed * Time.deltaTime);
            playerTransform.position += transform.right * (movement.x * moveSpeed * Time.deltaTime);
        }
        
        private void LookAround()
        {
            // Use the mouse to look around
            var mouseX = Input.GetAxis("Mouse X");

            // Rotate the player around the Y axis
            playerTransform.Rotate(Vector3.up * (mouseX * 100f * Time.deltaTime));
        }
    }
}