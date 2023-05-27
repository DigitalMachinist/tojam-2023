using System;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class Player : MonoBehaviour
{
    // This class represents the higher-level logical representation of the player in the game that exposes methods for
    // other gameobjects to call, playing sounds, driving the animation controller, etc. It *should not* be responsible
    // for movement controls and such -- PlayerController should be responsible for handling controls and converting 
    // them into events that this class handles.
    
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
    
    // References to the parts. These should remain set even when the part is not attached to the body.
    public Arm Arm;
    public Eye Eye;
    public Leg Leg;
    
    // Are parts currently attached to the body or not?
    public bool HasArm;
    public bool HasEye;
    public bool HasLeg;
}
