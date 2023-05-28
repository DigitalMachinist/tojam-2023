using System.Linq;
using Interactables;
using UnityEngine;
using UnityEngine.Serialization;

public class Leg : Part
{
    [FormerlySerializedAs("kickForce")]
    [Header("Kicking Settings")]
    [SerializeField] float kickForceForward = 10f;
    [SerializeField] float kickForceUpward = 2f;
    [SerializeField] float minKickRange = 0.1f;
    [SerializeField] float maxKickRange = 3f;
    [SerializeField] LayerMask kickLayerMask;
    [SerializeField] LayerMask kickVisibilityLayerMask;
    
    void Start()
    {
        Player = FindObjectOfType<Player>();
        Attachment = Player.LegAttachment;
        Player.Jumped += OnJumped;
        Player.Kicked += OnKicked;
        Player.LegPlaced += OnLegPlaced;
        Player.LegRecalled += OnLegRecalled;
    }

    void OnJumped()
    {
    }

    void OnKicked()
    {
        var interactablesInRange = transform.GetInteractablesInRange<LegKickable>(minKickRange, 
            maxKickRange, kickLayerMask, kickVisibilityLayerMask);
        
        // Kick The closest one
        if (interactablesInRange is {Count: <= 0})
        {
            Debug.LogWarning("[LEG] No kickables in range!");
            return;
        }

        var kickFromPosition = GetComponentInParent<Player>() == null
            ? Player.transform.position
            : Attachment.transform.position;
        
        var closestInteractable = interactablesInRange
            .OrderBy(interactable => Vector3.Distance(interactable.transform.position, kickFromPosition))
            .First();

        var fromLegToInteractable = closestInteractable.transform.position - transform.position;
        closestInteractable.Kick(fromLegToInteractable.normalized * kickForceForward + Vector3.up * kickForceUpward);
    }

    void OnLegPlaced()
    {
    }

    void OnLegRecalled()
    {
    }
}