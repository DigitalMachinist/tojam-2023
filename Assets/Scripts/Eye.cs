﻿using System.Collections.Generic;
using Cinemachine;
using Interactables;
using UnityEngine;
using UnityEngine.Serialization;

public class Eye : Part
{
    [Header("Eye Settings")] 
    [SerializeField] private float minRange = 1f;
    [SerializeField] private float maxRange = 10f;
    [SerializeField] private LayerMask interactableLayer;

    [FormerlySerializedAs("virtualCamera")]
    [Header("Attached Camera Settings")] 
    [SerializeField] CinemachineVirtualCamera attachedCamera;
    [SerializeField] float xSensitivity = 300f;
    [SerializeField] float ySensitivity = 300f;
    
    [Header("Detached Camera Settings")]
    [SerializeField] CinemachineVirtualCamera detachedCamera;
    [SerializeField] float detachedXSensitivity = 300f;
    [SerializeField] float detachedYSensitivity = 300f;

    void Awake()
    {
        CinemachinePOV povComponent = attachedCamera.GetCinemachineComponent<CinemachinePOV>();
        povComponent.m_HorizontalAxis.m_MaxSpeed = xSensitivity;
        povComponent.m_VerticalAxis.m_MaxSpeed = ySensitivity;
        
        povComponent = detachedCamera.GetCinemachineComponent<CinemachinePOV>();
        povComponent.m_HorizontalAxis.m_MaxSpeed = detachedXSensitivity;
        povComponent.m_VerticalAxis.m_MaxSpeed = detachedYSensitivity;
    }

    void Start()
    {
        Player = FindObjectOfType<Player>();
        Attachment = Player.EyeAttachment;
        
        Player.EyePlaced += OnEyePlaced;
        Player.EyeRecalled += OnEyeRecalled;
        Player.LaserStarted += OnLaserStarted;
        Player.LaserEnded += OnLaserEnded;

        OnEyeRecalled();
    }

    void OnEyePlaced()
    {
        attachedCamera.enabled = false;
        detachedCamera.enabled = true;
    }

    void OnEyeRecalled()
    {
        attachedCamera.enabled = true;
        detachedCamera.enabled = false;
    }

    void OnLaserStarted()
    {
        Debug.Log("Firing lasers!");
        
        var eyeInteractables = FindObjectsOfType<EyeInteractable>();
        var inRangeInteractables = new List<IInteractable>();
        
        // For each interactable, raycast to it and see if it's in range
        // Remove the ones that aren't in rangesform;
        foreach (var interactable in eyeInteractables)
        {
            var interactableTransform = interactable.transform;
            var direction = interactableTransform.position - transform.position;
            var distance = direction.magnitude;
            var ray = new Ray(transform.position, direction);
            
            // Draw the ray
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, 1f);
            
            var hit = Physics.Raycast(ray, out var hitInfo, distance, interactableLayer);
            if (!hit)
            {
                continue;
            }
            
            Debug.Log($"Eye laser hit {hitInfo.transform.name}!");

            if (hitInfo.transform != interactableTransform)
            {
                continue;
            }

            if (distance < minRange || distance > maxRange)
            {
                continue;
            }
            
            inRangeInteractables.Add(interactable);
        }
        
        // Sort the interactables by distance
        inRangeInteractables.Sort((a, b) =>
        {
            var aDistance = (a.Transform.position - transform.position).magnitude;
            var bDistance = (b.Transform.position - transform.position).magnitude;
            return aDistance.CompareTo(bDistance);
        });
        
        // Interact with all interactables in range
        foreach (var interactable in inRangeInteractables)
        {
            interactable.Interact();
        }
    }

    void OnLaserEnded()
    {
        throw new System.NotImplementedException();
    }

    public override void Attach(Attachment attachment)
    {
        throw new System.NotImplementedException();
    }
}