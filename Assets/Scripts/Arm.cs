﻿using System;
using System.Linq;
using Interactables;
using UnityEngine;

public class Arm : Part
{
    [Header("Grabbing Settings")]
    [SerializeField] float minGrabRange = 0.1f;
    [SerializeField] float maxGrabRange = 3f;
    [SerializeField] LayerMask grabLayerMask;
    [SerializeField] LayerMask grabVisibilityLayerMask;
    [SerializeField] Transform grabTransform;
    
    [Header("Interaction Settings")]
    [SerializeField] float minInteractRange = 0.1f;
    [SerializeField] float maxInteractRange = 3f;
    [SerializeField] LayerMask interactLayerMask;
    [SerializeField] LayerMask interactVisibilityLayerMask;

    ArmGrabInteractable grabbedInteractable;
    public bool IsGrabbing => grabbedInteractable != null;
    public bool IsGrabbingBox { get; private set; }
    
    void Start()
    {
        IsGrabbingBox = false;
        Player = FindObjectOfType<Player>();
        Attachment = Player.ArmAttachment;
        Player.ArmPlaced += OnArmPlaced;
        Player.ArmRecalled += OnArmRecalled;
        Player.GrabStarted += OnGrabStarted;
        Player.GrabEnded += OnGrabEnded;
        Player.InteractStarted += OnInteractStarted;
        Player.InteractEnded += OnInteractEnded;
    }

    void OnDestroy()
    {
        Player.ArmPlaced -= OnArmPlaced;
        Player.ArmRecalled -= OnArmRecalled;
        Player.GrabStarted -= OnGrabStarted;
        Player.GrabEnded -= OnGrabEnded;
        Player.InteractStarted -= OnInteractStarted;
        Player.InteractEnded -= OnInteractEnded;
    }

    void OnArmPlaced()
    {
    }

    void OnArmRecalled()
    {
    }

    void OnGrabStarted()
    {
        if (IsGrabbing)
        {
            Debug.LogWarning($"You are already grabbing {grabbedInteractable.gameObject.name}!");
            return;
        }
        
        var interactablesInRange = transform.GetInteractablesInRange<ArmGrabInteractable>(minGrabRange, 
            maxGrabRange, grabLayerMask, grabVisibilityLayerMask);
        
        // Grab The Closest One
        if (interactablesInRange is {Count: <= 0})
        {
            Debug.LogWarning("[ARM] No interactables in range to grab!");
            return;
        }
        
        var closestInteractable = interactablesInRange
            .OrderBy(interactable => Vector3.Distance(interactable.transform.position, grabTransform.position))
            .First();
        
        grabbedInteractable = closestInteractable.Grab(grabTransform);

        if (grabbedInteractable != null && grabbedInteractable.CompareTag("Box"))
        {
            IsGrabbingBox = true;
        }
    }

    void OnGrabEnded()
    {
        if (!IsGrabbing)
        {
            Debug.LogWarning("No interactable to release!");
            return;
        }
        
        grabbedInteractable.Release();
        grabbedInteractable = null;
        IsGrabbingBox = false;
    }

    void OnInteractStarted()
    {
        var interactablesInRange = transform.GetInteractablesInRange<ArmInteractable>(minInteractRange, 
            maxInteractRange, interactLayerMask, interactVisibilityLayerMask);
        
        if (interactablesInRange is {Count: <= 0})
        {
            Debug.LogWarning("[ARM] No interactables in range to interact with!");
            return;
        }
        
        foreach (var interactable in interactablesInRange)
        {
            interactable.Interact();
        }
    }

    void OnInteractEnded()
    {
        throw new System.NotImplementedException();
    }

    public void Release()
    {
        grabbedInteractable.Release();
    }
}