using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Handlers
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 WalkInput { get; private set; }
        public Vector2 LookAroundInput { get; private set; }
        
        public event Action JumpPressed;
        public event Action AttachDetachEyePressed;
        public event Action UseEyePressed;
        public event Action AttachDetachLeftArmPressed;
        public event Action UseLeftArmPressed;
        public event Action AttachDetachRightArmPressed;
        public event Action UseRightArmPressed;
        public event Action AttachDetachLeftLegPressed;
        public event Action UseLeftLegPressed;
        public event Action AttachDetachRightLegPressed;
        public event Action UseRightLegPressed;

        InputAction Walk { get; set; }
        InputAction LookAround { get; set; }
        
        PlayerActions playerActions;

        void Awake()
        {
            playerActions = new PlayerActions();
            Walk = playerActions.PlayerActionMap.Walk;
            LookAround = playerActions.PlayerActionMap.LookAround;
            
            playerActions.PlayerActionMap.Jump.performed += OnJump;
            playerActions.PlayerActionMap.AttachDetachEye.performed += OnAttachDetachEye;
            playerActions.PlayerActionMap.UseEye.performed += OnUseEye;
            playerActions.PlayerActionMap.AttachDetachLeftArm.performed += OnAttachDetachLeftArm;
            playerActions.PlayerActionMap.UseLeftArm.performed += OnUseLeftArm;
            playerActions.PlayerActionMap.AttachDetachRightArm.performed += OnAttachDetachRightArm;
            playerActions.PlayerActionMap.UseRightArm.performed += OnUseRightArm;
            playerActions.PlayerActionMap.AttachDetachLeftLeg.performed += OnAttachDetachLeftLeg;
            playerActions.PlayerActionMap.UseLeftLeg.performed += OnUseLeftLeg;
            playerActions.PlayerActionMap.AttachDetachRightLeg.performed += OnAttachDetachRightLeg;
            playerActions.PlayerActionMap.UseRightLeg.performed += OnUseRightLeg;
        }

        void Update()
        {
            WalkInput = Walk.ReadValue<Vector2>();
            LookAroundInput = LookAround.ReadValue<Vector2>();
        }

        void OnEnable() => playerActions?.PlayerActionMap.Enable();
        void OnDisable() => playerActions?.PlayerActionMap.Disable();

        void OnJump(InputAction.CallbackContext context)
        {
            Debug.Log("[PlayerInputHandler] Jump");
            JumpPressed?.Invoke();
        }

        void OnAttachDetachEye(InputAction.CallbackContext context)
        {
            Debug.Log("[PlayerInputHandler] AttachDetachEye");
            AttachDetachEyePressed?.Invoke();
        }
        
        void OnUseEye(InputAction.CallbackContext context)
        {
            Debug.Log("[PlayerInputHandler] UseEye");
            UseEyePressed?.Invoke();
        }
        
        void OnAttachDetachLeftArm(InputAction.CallbackContext context)
        {
            Debug.Log("[PlayerInputHandler] AttachDetachLeftArm");
            AttachDetachLeftArmPressed?.Invoke();
        }
        
        void OnUseLeftArm(InputAction.CallbackContext context)
        {
            Debug.Log("[PlayerInputHandler] UseLeftArm");
            UseLeftArmPressed?.Invoke();
        }
        
        void OnAttachDetachRightArm(InputAction.CallbackContext context)
        {
            Debug.Log("[PlayerInputHandler] AttachDetachRightArm");
            AttachDetachRightArmPressed?.Invoke();
        }
        
        void OnUseRightArm(InputAction.CallbackContext context)
        {
            Debug.Log("[PlayerInputHandler] UseRightArm");
            UseRightArmPressed?.Invoke();
        }
        
        void OnAttachDetachLeftLeg(InputAction.CallbackContext context)
        {
            Debug.Log("[PlayerInputHandler] AttachDetachLeftLeg");
            AttachDetachLeftLegPressed?.Invoke();
        }
        
        void OnUseLeftLeg(InputAction.CallbackContext context)
        {
            Debug.Log("[PlayerInputHandler] UseLeftLeg");
            UseLeftLegPressed?.Invoke();
        }
        
        void OnAttachDetachRightLeg(InputAction.CallbackContext context)
        {
            Debug.Log("[PlayerInputHandler] AttachDetachRightLeg");
            AttachDetachRightLegPressed?.Invoke();
        }
        
        void OnUseRightLeg(InputAction.CallbackContext context)
        {
            Debug.Log("[PlayerInputHandler] UseRightLeg");
            UseRightLegPressed?.Invoke();
        }
    }
}