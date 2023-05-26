using UnityEngine;

namespace Handlers
{
    [RequireComponent(typeof(Transform))]
    public class PlayerHandler : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private bool useXMovement = true;
        [SerializeField] private bool useYMovement = false;
        [SerializeField] private bool useZMovement = true;
        
        [Header("Camera Vertical Settings")]
        [SerializeField] private float minXAngle = -20f;
        [SerializeField] private float maxXAngle = 10f;
        
        private Transform playerTransform;

        private void Start()
        {
            playerTransform = transform;
            
            // Lock the mouse in the center and hide it
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        private void Update()
        {
            Move();
            LookAround();
        }

        private void Move()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Jump");
            var z = Input.GetAxis("Vertical");
            
            var movement = new Vector3 
            ( 
                useXMovement ? x : 0f, 
                useYMovement ? y : 0f,
                useZMovement ? z : 0f
            );
      
            playerTransform.position += transform.forward * (movement.z * moveSpeed * Time.deltaTime);
            playerTransform.position += transform.right * (movement.x * moveSpeed * Time.deltaTime);
            playerTransform.position += transform.up * (movement.y * moveSpeed * Time.deltaTime);
            
            // Player Position should be clamped to the ground
            playerTransform.position = new Vector3(playerTransform.position.x, 0f, playerTransform.position.z);
        }
        
        private void LookAround()
        {
            // Use the mouse to look around
            var mouseX = Input.GetAxis("Mouse X");
            var mouseY = Input.GetAxis("Mouse Y");
            
            // Rotate the player around the Y axis
            playerTransform.Rotate(Vector3.up * (mouseX * 100f * Time.deltaTime));
            
            // Rotate the player around the X axis
            playerTransform.Rotate(Vector3.left * (mouseY * 100f * Time.deltaTime));
            
            // Clamp the X rotation using minXAngle and maxXAngle
            var xRotation = playerTransform.eulerAngles.x;
            if (xRotation > 180f)
            {
                xRotation -= 360f;
            }
            xRotation = Mathf.Clamp(xRotation, minXAngle, maxXAngle);
            playerTransform.eulerAngles = new Vector3(xRotation, playerTransform.eulerAngles.y, 0f);
        }
    }
}