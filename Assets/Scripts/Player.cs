using System;
using Handlers;
using UnityEngine;

public class Player : MonoBehaviour
{
    // This class represents the higher-level logical representation of the player in the game that exposes methods for
    // other gameobjects to call, playing sounds, driving the animation controller, etc. This probably overlaps a lot
    // with Dan's PlayerHandler, so maybe they are actually one thing.

    // Emit events based on controls. Other scripts that execute on these commands can listen for these events.
    public event Action ArmEnabled;
    public event Action ArmPlaced;
    public event Action ArmRecalled;
    public event Action Died;
    public event Action EyeEnabled;
    public event Action EyePlaced;
    public event Action EyeRecalled;
    public event Action GrabEnded; // Arm
    public event Action GrabStarted; // Arm
    public event Action InteractEnded; // Arm
    public event Action InteractStarted; // Arm
    public event Action Jumped; // Leg
    public event Action Kicked; // Leg
    public event Action Landed; // Leg
    public event Action LaserEnded; // Eye
    public event Action LaserStarted; // Eye
    public event Action LegEnabled;
    public event Action LegPlaced;
    public event Action LegRecalled;
    public event Action<Vector3> Moved;
    public event Action<Vector3> Rotated; // Euler angles
    public event Action Spawned;
    public event Action<bool> PauseToggled;

    public AttachmentPlacer AttachmentPlacer;

    // References to the parts. These should remain set even when the part is not attached to the body.
    public Arm Arm;
    public Eye Eye;
    public Leg Leg;

    // Part attachment points that are part of the player's body.
    public Attachment ArmAttachment;
    public Attachment EyeAttachment;
    public Attachment LegAttachment;

    // Are parts currently attached to the body or not?
    public bool IsArmEnabled = true;
    public bool IsEyeEnabled = true;
    public bool IsLegEnabled = true;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask platformLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private float additionalGroundingForce = 100f;

    [Header("Eye Camera")]
    [SerializeField] float minEyeAngle = -90f;
    [SerializeField] private float maxEyeAngle = 90f;
    [SerializeField] float minXEyeAngle = -60f;
    [SerializeField] float maxXEyeAngle = 60f;
    [SerializeField] float eyeXSensitivity = 100f;
    [SerializeField] float eyeYSensitivity = 100f;

    [Header("Detachable parts")]
    public GameObject armMesh;
    public GameObject legMesh;

    private Transform playerTransform;
    private Rigidbody playerRigidbody;
    PlayerInputHandler playerInputHandler;
    private bool isGrounded;
    float rotX;
    float rotY;
    bool isPaused;
    Vector3 latestMovement;
    Killable killable;

    public bool HasArm { get; set; }
    public bool HasEye { get; set; }
    public bool HasLeg { get; set; }

    void Awake()
    {
        // Lock the mouse in the center and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerTransform = transform;
        playerRigidbody = GetComponent<Rigidbody>();

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

    void Start()
    {
        playerInputHandler = GetComponent<PlayerInputHandler>();
        playerInputHandler.JumpPressed += OnJumpPressed;
        playerInputHandler.AttachDetachEyePressed += OnAttachDetachEyePressed;
        playerInputHandler.UseEyePressed += OnUseEyePressed;
        playerInputHandler.AttachDetachLeftArmPressed += OnAttachDetachLeftArmPressed;
        playerInputHandler.UseLeftArmPressed += OnUseLeftArmPressed;
        playerInputHandler.AttachDetachLeftLegPressed += OnAttachDetachLeftLegPressed;
        playerInputHandler.UseLeftLegPressed += OnUseLeftLegPressed;
        playerInputHandler.PausePressed += OnPausePressed;

        killable = GetComponentInChildren<Killable>();
        killable.Killed += OnKilled;
    }

    void OnDestroy()
    {
        if (!isPaused)
        {
            playerInputHandler.JumpPressed -= OnJumpPressed;
            playerInputHandler.AttachDetachEyePressed -= OnAttachDetachEyePressed;
            playerInputHandler.UseEyePressed -= OnUseEyePressed;
            playerInputHandler.AttachDetachLeftArmPressed -= OnAttachDetachLeftArmPressed;
            playerInputHandler.UseLeftArmPressed -= OnUseLeftArmPressed;
            playerInputHandler.AttachDetachLeftLegPressed -= OnAttachDetachLeftLegPressed;
            playerInputHandler.UseLeftLegPressed -= OnUseLeftLegPressed;
        }

        playerInputHandler.PausePressed -= OnPausePressed;
        
        killable.Killed -= OnKilled;
    }

    void Update()
    {
        CheckForGround();
        CheckForPlatform();
        
        LookAround();
    }
    
    void FixedUpdate()
    {
        Move();
        AdditiveDownForce();
    }

    void OnKilled()
    {
        if (!Arm.IsGrabbing)
        {
            return;
        }
        
        Arm.Release();
    }
    
    void AdditiveDownForce()
    {
        if (isGrounded || playerRigidbody.velocity.y > 0f)
        {
            return;
        }

        playerRigidbody.AddForce(Vector3.down * (additionalGroundingForce * Time.fixedDeltaTime), ForceMode.Acceleration);
    }

    void CheckForGround()
    {
        var groundCheckPosition = groundCheck.position;
        var wasGrounded = isGrounded;
        isGrounded = Physics.CheckSphere(groundCheckPosition, groundCheckRadius, groundLayer);
        if (!wasGrounded && isGrounded)
        {
            Landed?.Invoke();
        }
    }

    void CheckForPlatform()
    {
        if (!isGrounded)
        {
            return;
        }

        var platformDetected = Physics.CheckSphere(groundCheck.position, groundCheckRadius, platformLayer);

        if (platformDetected)
        {
            var platform = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, platformLayer)[0].transform;
            playerTransform.parent = platform;
        }
        else
        {
            playerTransform.parent = null;
        }
    }

    void Move()
    {
        Vector3 controlDirection;
        if (HasEye)
        {
            controlDirection = new Vector3(playerInputHandler.WalkInput.x, 0f, playerInputHandler.WalkInput.y);
            if (controlDirection.sqrMagnitude < 0.0001f)
            {
                return;
            }
            
            // Attached eye movement is relative to the player's body (also the eye's viewpoint).
            latestMovement = playerTransform.TransformDirection(controlDirection);
        }
        else
        {
            controlDirection = new Vector3(playerInputHandler.WalkInput.x, 0f, playerInputHandler.WalkInput.y);
            if (controlDirection.sqrMagnitude < 0.0001f)
            {
                return;
            }
            
            // Detached eye player movement is relative to the eye's viewpoint.
            latestMovement = Eye.GetCurrentVCam().State.CorrectedOrientation * controlDirection;
            latestMovement.y = 0f;
            latestMovement.Normalize();
            
            // For this case, we need to rotate the player's body along with their direction of motion.
            playerTransform.rotation = Quaternion.LookRotation(latestMovement, Vector3.up);
        }

        playerRigidbody.AddForce(latestMovement * moveSpeed, ForceMode.VelocityChange);
    }

    void IsArmAttached(bool state)
    {
        if (state)
        {
            armMesh.SetActive(true);
            Arm.gameObject.GetComponentInChildren<Renderer>().enabled = false;

        }
        else
        {
            armMesh.SetActive(false);
            Arm.gameObject.GetComponentInChildren<Renderer>().enabled = true;
        }
    }
    void IsLegAttached(bool state)
    {
        if (state)
        {
            legMesh.SetActive(true);
            Leg.gameObject.GetComponentInChildren<Renderer>().enabled = false;

        }
        else
        {
            legMesh.SetActive(false);
            Leg.gameObject.GetComponentInChildren<Renderer>().enabled = true;
        }
    }

    void LookAround()
    {
        var x = playerInputHandler.LookAroundInput.x;
        var y = playerInputHandler.LookAroundInput.y;
        rotX += x % 360 * eyeXSensitivity * Time.deltaTime;
        rotY += y % 360 * eyeYSensitivity * Time.deltaTime;

        if (HasEye)
        {
            // Rotate the player around the Y axis
            transform.Rotate(Vector3.up * (x * eyeXSensitivity * Time.deltaTime));
        }
        else
        {
            // Rotate the Eye around the Y axis
            rotX = Mathf.Clamp(rotX, minXEyeAngle, maxXEyeAngle);
            Eye.transform.localRotation = Quaternion.Euler(0f, rotX, 0f);
        }

        // Rotate the Eye's active camera to look up and down, but clamp it so it can't look too far up or down
        rotY = Mathf.Clamp(rotY, minEyeAngle, maxEyeAngle);
        Eye.ActiveCamera.localRotation = Quaternion.Euler(-rotY, 0f, 0f);
    }

    void OnJumpPressed()
    {
        if (!IsLegEnabled || !HasLeg || !isGrounded || (HasArm && Arm.IsGrabbing))
        {
            return;
        }

        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        Jumped?.Invoke();
    }

    void OnAttachDetachEyePressed()
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

    void OnUseEyePressed()
    {
        LaserStarted?.Invoke();
    }

    void OnAttachDetachLeftArmPressed()
    {
        if (!IsArmEnabled)
        {
            return;
        }

        if (HasArm)
        {
            Place(Arm);
        }
        else
        {
            Recall(Arm);
        }
    }

    void OnUseLeftArmPressed()
    {
        if (!IsArmEnabled)
        {
            return;
        }

        // TODO: Hold to continue interacting?
        InteractStarted?.Invoke();

        if (Arm.IsGrabbing)
        {
            GrabEnded?.Invoke();
        }
        else
        {
            GrabStarted?.Invoke();
        }
    }

    void OnAttachDetachLeftLegPressed()
    {
        if (!IsLegEnabled)
        {
            return;
        }

        if (HasLeg)
        {
            Place(Leg);
        }
        else
        {
            Recall(Leg);
        }
    }

    void OnUseLeftLegPressed()
    {
        if (!IsLegEnabled || !HasLeg)
        {
            return;
        }

        Kicked?.Invoke();
    }
    
    void OnPausePressed()
    {
        isPaused ^= true;
        enabled = !isPaused;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused;
        // if (isPaused)
        // {
        //     playerInputHandler.JumpPressed -= OnJumpPressed;
        //     playerInputHandler.AttachDetachEyePressed -= OnAttachDetachEyePressed;
        //     playerInputHandler.UseEyePressed -= OnUseEyePressed;
        //     playerInputHandler.AttachDetachLeftArmPressed -= OnAttachDetachLeftArmPressed;
        //     playerInputHandler.UseLeftArmPressed -= OnUseLeftArmPressed;
        //     playerInputHandler.AttachDetachLeftLegPressed -= OnAttachDetachLeftLegPressed;
        //     playerInputHandler.UseLeftLegPressed -= OnUseLeftLegPressed;
        // }
        // else
        // {
        //     playerInputHandler.JumpPressed += OnJumpPressed;
        //     playerInputHandler.AttachDetachEyePressed += OnAttachDetachEyePressed;
        //     playerInputHandler.UseEyePressed += OnUseEyePressed;
        //     playerInputHandler.AttachDetachLeftArmPressed += OnAttachDetachLeftArmPressed;
        //     playerInputHandler.UseLeftArmPressed += OnUseLeftArmPressed;
        //     playerInputHandler.AttachDetachLeftLegPressed += OnAttachDetachLeftLegPressed;
        //     playerInputHandler.UseLeftLegPressed += OnUseLeftLegPressed;
        // }
        PauseToggled?.Invoke(isPaused);
    }

    void Place(Part part)
    {
        var lookPosition = Eye.transform.position;
        var lookDirection = Eye.GetLookVector();

        Attachment attachment;
        try
        {
            attachment = AttachmentPlacer.TryPlace(new Ray(lookPosition, lookDirection));

            // Draw a debug ray in the scene view so we can confirm the placement.
            var lookToAttachment = attachment.transform.position - lookPosition;
            Debug.DrawRay(lookPosition, lookToAttachment, Color.red, 10f);
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

        if (part == Arm)
        {
            IsArmAttached(false);
        }

        if (part == Leg)
        {
            IsLegAttached(false);
        }
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

        if( part == Leg)
        IsLegAttached(true);

        if( part == Arm)
        IsArmAttached(true);
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

    public void EnableArm()
    {
        IsArmEnabled = true;
        ArmEnabled?.Invoke();
    }

    public void EnableEye()
    {
        IsEyeEnabled = true;
        EyeEnabled?.Invoke();
    }

    public void EnableLeg()
    {
        IsLegEnabled = true;
        LegEnabled?.Invoke();
    }
}
