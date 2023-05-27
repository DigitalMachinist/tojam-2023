using System.Linq;
using Interactables;
using UnityEngine;

public class Leg : Part
{
    [Header("Kicking Settings")]
    [SerializeField] float kickForce = 5f;
    [SerializeField] float minKickRange = 0.1f;
    [SerializeField] float maxKickRange = 3f;
    [SerializeField] LayerMask kickLayerMask;
    [SerializeField] LayerMask kickVisibilityLayerMask;
    [SerializeField] Transform kickTransform;
    
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
            Debug.LogWarning("[LEG] No LegKickables in range!");
            return;
        }
        
        var closestInteractable = interactablesInRange
            .OrderBy(interactable => Vector3.Distance(interactable.transform.position, kickTransform.position))
            .First();

        var fromLegToInteractable = closestInteractable.transform.position - transform.position;
        closestInteractable.Kick(fromLegToInteractable.normalized * kickForce);
    }

    void OnLegPlaced()
    {
    }

    void OnLegRecalled()
    {
    }
}