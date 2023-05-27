using System.Collections.Generic;
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
    [FormerlySerializedAs("visibilityLayer")] [SerializeField] private LayerMask visibleLayer;

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
        
        var inRangeInteractables =
            transform.GetInteractablesInRange<EyeInteractable>(minRange, maxRange, interactableLayer, visibleLayer);
        
        // Sort the interactables by distance
        inRangeInteractables.Sort((a, b) =>
        {
            var aSqrDistance = (a.Transform.position - transform.position).sqrMagnitude;
            var bSqrDistance = (b.Transform.position - transform.position).sqrMagnitude;
            return aSqrDistance.CompareTo(bSqrDistance);
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

    public Vector3 GetLookVector()
    {
        var vcam = attachedCamera.enabled
            ? attachedCamera
            : detachedCamera;

        return vcam.State.CorrectedOrientation * Vector3.forward;
    }
}