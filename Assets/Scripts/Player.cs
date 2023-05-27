using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    // This class represents the higher-level logical representation of the player in the game that exposes methods for
    // other gameobjects to call, playing sounds, driving the animation controller, etc. This probably overlaps a lot
    // with Dan's PlayerHandler, so maybe they are actually one thing.
    
    // Emit events based on controls. Other scripts that execute on these commands can listen for these events.
    public event Action ArmPlaced;
    public event Action ArmRecalled;
    public event Action Died;
    public event Action EyePlaced;
    public event Action EyeRecalled;
    public event Action GrabEnded; // Arm
    public event Action GrabStarted; // Arm
    public event Action InteractEnded; // Arm
    public event Action InteractStarted; // Arm
    public event Action Jumped; // Leg
    public event Action Kicked; // Leg
    public event Action LaserEnded; // Eye
    public event Action LaserStarted; // Eye
    public event Action LegPlaced;
    public event Action LegRecalled;
    public event Action<Vector3> Moved;
    public event Action<Vector3> Rotated; // Euler angles
    public event Action Spawned;

    public AttachmentPlacer AttachmentPlacer;
    
    // References to the parts. These should remain set even when the part is not attached to the body.
    public Arm Arm;
    public Eye Eye;
    public Leg Leg;
    
    // 
    public Attachment ArmAttachment;
    public Attachment EyeAttachment;
    public Attachment LegAttachment;
    
    // Are parts currently attached to the body or not?
    public bool IsArmEnabled = true;
    public bool IsEyeEnabled = true;
    public bool IsLegEnabled = true;
    
    public bool HasArm { get; set; }
    public bool HasEye { get; set; }
    public bool HasLeg { get; set; }

    void Start()
    {
        if (IsArmEnabled)
        {
            Arm = FindObjectOfType<Arm>();
            HasArm = true;
        }

        if (IsEyeEnabled)
        {
            Eye = FindObjectOfType<Eye>();
            HasEye = true;
        }

        if (IsLegEnabled)
        {
            Leg = FindObjectOfType<Leg>();
            HasLeg = true;
        }
    }
    
    void Update()
    {
        // TODO: Replace this with the actual input manager stuff.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (HasArm)
            {
                Place(Arm);
            }
            else
            {
                Recall(Arm);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (HasLeg)
            {
                Place(Leg);
            }
            else
            {
                Recall(Leg);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (HasEye)
            {
                Place(Eye);
            }
            else
            {
                Recall(Eye);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0)) // Should this be mouse button?
        {
            LaserStarted?.Invoke();
        }
        
        LookAround();
    }
    
    void Place(Part part)
    {
        var eyeTransform = Eye.transform;
        
        Attachment attachment;
        try
        {
            attachment = AttachmentPlacer.TryPlace(new Ray(eyeTransform.position, eyeTransform.forward));
        }
        catch (Exception e)
        {
            Debug.LogWarning(e.Message);
            return;
        }
        part.Attachment = attachment;
        
        var partTransform = part.transform;
        partTransform.position = attachment.PartContainer.position;
        partTransform.rotation = attachment.PartContainer.rotation;
        partTransform.SetParent(attachment.PartContainer, true);
        
        SetHasPart(part, false);
        
        EmitPartPlaced(part);
    }

    void Recall(Part part)
    {
        var attachment = GetPartAttachment(part);
        var partTransform = part.transform;
        partTransform.position = attachment.PartContainer.position;
        partTransform.rotation = attachment.PartContainer.rotation;
        partTransform.SetParent(attachment.transform, true);
        
        SetHasPart(part, true);
        
        Destroy(part.Attachment.gameObject);
        part.Attachment = attachment;
        
        EmitPartRecalled(part);
    }

    Attachment GetPartAttachment(Part part)
    {
        if (part == Arm)
        {
            return ArmAttachment;
        }
        if (part == Eye)
        {
            return EyeAttachment;
        }
        if (part == Leg)
        {
            return LegAttachment;
        }
        
        throw new Exception("What is this part?");
    }

    void SetHasPart(Part part, bool value)
    {
        if (part == Arm)
        {
            HasArm = value;
        }
        else if (part == Eye)
        {
            HasEye = value;
        }
        else if (part == Leg)
        {
            HasLeg = value;
        }
        else
        {
            throw new Exception("What is this part?");
        }
    }

    void EmitPartPlaced(Part part)
    {
        if (part == Arm)
        {
            ArmPlaced?.Invoke();
        }
        else if (part == Eye)
        {
            EyePlaced?.Invoke();
        }
        else if (part == Leg)
        {
            LegPlaced?.Invoke();
        }
        else
        {
            throw new Exception("What is this part?");
        }
    }

    void EmitPartRecalled(Part part)
    {
        if (part == Arm)
        {
            ArmRecalled?.Invoke();
        }
        else if (part == Eye)
        {
            EyeRecalled?.Invoke();
        }
        else if (part == Leg)
        {
            LegRecalled?.Invoke();
        }
        else
        {
            throw new Exception("What is this part?");
        }
    }
    
    void LookAround()
    {
        if (!HasEye)
        {
             return;   
        }
            
        // Use the mouse to look around
        var mouseX = Input.GetAxis("Mouse X");

        // Rotate the player around the Y axis
        transform.Rotate(Vector3.up * (mouseX * 100f * Time.deltaTime));
    }
}
