﻿using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Handlers
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] float mouseMultiplier = 0.4f;
        [SerializeField] float gamepadMultiplier = 1f;
        
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
        public event Action PausePressed;

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
            playerActions.PlayerActionMap.Pause.performed += OnPausePressed;
        }

        private void OnDestroy()
        {
            playerActions.PlayerActionMap.Jump.performed -= OnJump;
            playerActions.PlayerActionMap.AttachDetachEye.performed -= OnAttachDetachEye;
            playerActions.PlayerActionMap.UseEye.performed -= OnUseEye;
            playerActions.PlayerActionMap.AttachDetachLeftArm.performed -= OnAttachDetachLeftArm;
            playerActions.PlayerActionMap.UseLeftArm.performed -= OnUseLeftArm;
            playerActions.PlayerActionMap.AttachDetachRightArm.performed -= OnAttachDetachRightArm;
            playerActions.PlayerActionMap.UseRightArm.performed -= OnUseRightArm;
            playerActions.PlayerActionMap.AttachDetachLeftLeg.performed -= OnAttachDetachLeftLeg;
            playerActions.PlayerActionMap.UseLeftLeg.performed -= OnUseLeftLeg;
            playerActions.PlayerActionMap.AttachDetachRightLeg.performed -= OnAttachDetachRightLeg;
            playerActions.PlayerActionMap.UseRightLeg.performed -= OnUseRightLeg;
            playerActions.PlayerActionMap.Pause.performed -= OnPausePressed;
        }

        void Start() => SetInputEnabled(true);
        
        void Update()
        {
            WalkInput = Walk.ReadValue<Vector2>();
            
            var activeDevice = LookAround.activeControl?.device;
            if (activeDevice != null)
            {
                if (activeDevice == Mouse.current)
                {
                    LookAroundInput = Mouse.current.delta.ReadValue() * mouseMultiplier;
                }
                else if (activeDevice == Gamepad.current)
                {
                    LookAroundInput = LookAround.ReadValue<Vector2>() * gamepadMultiplier;
                }
            }
            else
            {
                LookAroundInput = Vector2.zero;
            }
        }

        void OnEnable() => SetInputEnabled(true);
        void OnDisable() => SetInputEnabled(false);

        void OnJump(InputAction.CallbackContext context)
        {
            // Debug.Log("[PlayerInputHandler] Jump");
            JumpPressed?.Invoke();
        }

        void OnAttachDetachEye(InputAction.CallbackContext context)
        {
            // Debug.Log("[PlayerInputHandler] AttachDetachEye");
            AttachDetachEyePressed?.Invoke();
        }
        
        void OnUseEye(InputAction.CallbackContext context)
        {
            // Debug.Log("[PlayerInputHandler] UseEye");
            UseEyePressed?.Invoke();
        }
        
        void OnAttachDetachLeftArm(InputAction.CallbackContext context)
        {
            // Debug.Log("[PlayerInputHandler] AttachDetachLeftArm");
            AttachDetachLeftArmPressed?.Invoke();
        }
        
        void OnUseLeftArm(InputAction.CallbackContext context)
        {
            // Debug.Log("[PlayerInputHandler] UseLeftArm");
            UseLeftArmPressed?.Invoke();
        }
        
        void OnAttachDetachRightArm(InputAction.CallbackContext context)
        {
            // Debug.Log("[PlayerInputHandler] AttachDetachRightArm");
            AttachDetachRightArmPressed?.Invoke();
        }
        
        void OnUseRightArm(InputAction.CallbackContext context)
        {
            // Debug.Log("[PlayerInputHandler] UseRightArm");
            UseRightArmPressed?.Invoke();
        }
        
        void OnAttachDetachLeftLeg(InputAction.CallbackContext context)
        {
            // Debug.Log("[PlayerInputHandler] AttachDetachLeftLeg");
            AttachDetachLeftLegPressed?.Invoke();
        }
        
        void OnUseLeftLeg(InputAction.CallbackContext context)
        {
            // Debug.Log("[PlayerInputHandler] UseLeftLeg");
            UseLeftLegPressed?.Invoke();
        }
        
        void OnAttachDetachRightLeg(InputAction.CallbackContext context)
        {
            // Debug.Log("[PlayerInputHandler] AttachDetachRightLeg");
            AttachDetachRightLegPressed?.Invoke();
        }
        
        void OnUseRightLeg(InputAction.CallbackContext context)
        {
            // Debug.Log("[PlayerInputHandler] UseRightLeg");
            UseRightLegPressed?.Invoke();
        }
        
        void OnPausePressed(InputAction.CallbackContext context)
        {
            // Debug.Log("[PlayerInputHandler] Pause pressed");
            PausePressed?.Invoke();
        }
        
        void SetInputEnabled(bool isEnabled)
        {
            if (isEnabled)
            {
                playerActions?.Enable();
            }
            else
            {
                playerActions?.Disable();
            }
        }
    }
}