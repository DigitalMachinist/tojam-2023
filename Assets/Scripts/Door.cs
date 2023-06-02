using System;
using System.Collections.Generic;
using System.Linq;
using Activatables;
using Cinemachine;
using Interactables;
using UnityEngine;
using UnityEngine.Serialization;

public class Door : MonoBehaviour, IActivatable
{
    public event Action LightActivated;
    public event Action Activated;
    public event Action Deactivated;

    public Collider Barrier;
    public CinemachineVirtualCamera VCam;

    [Header("Indicator Lights")]
    public Color DisabledLightColour = Color.red;
    public Color EnabledLightColour = Color.green;
    public float DelayBeforeSeconds = 1f;
    public float DelayAfterSeconds = 2f;
    public Transform Layout1Parent;
    public List<Renderer> Layout1Lights;
    public Transform Layout2Parent;
    public List<Renderer> Layout2Lights;
    public Transform Layout3Parent;
    public List<Renderer> Layout3Lights;
    public Transform Layout4Parent;
    public List<Renderer> Layout4Lights;
    
    [field: SerializeField] public Switch[] Switches { get; private set; }
    
    public Animator Animator { get; private set; }
    public bool IsActivated { get; private set; }
    public bool HasActivated { get; private set; }

    void Awake()
    {
        IsActivated = false;
        Animator = GetComponentInChildren<Animator>();
        EnableLightLayout();
    }
    
    void Start()
    {
        foreach (var s in Switches)
        {
            s.Activated += OnActivated;
            s.Deactivated += OnDeactivated;
        }

        UpdateLights();
        OnActivated();
    }
    

    public void OnActivated()
    {
        var wasOpen = IsActivated;
        IsActivated = Switches.All(x => x.IsOn);
        if (!wasOpen && IsActivated)
        {
            Activate();
        }
        else
        {
            UpdateLights();
            LightActivated?.Invoke();
        }
    }

    public void OnDeactivated()
    {
        var wasOpen = IsActivated;
        IsActivated = false;
        if (wasOpen && !IsActivated)
        {
            Deactivate();
        }
        else
        {
            UpdateLights();
        }
    }

    async void Activate()
    {
        Activated?.Invoke();
        Barrier.gameObject.SetActive(false);
        if (!HasActivated)
        {
            VCam.enabled = true;
            await new WaitForSeconds(DelayBeforeSeconds);
        }
        UpdateLights();
        LightActivated?.Invoke();
        Animator.SetBool("IsOpen", true);
        if (!HasActivated)
        {
            await new WaitForSeconds(DelayAfterSeconds);
            VCam.enabled = false;
        }
        HasActivated = true;
    }

    async void Deactivate()
    {
        Deactivated?.Invoke();
        Animator.SetBool("IsOpen", false);
        Barrier.gameObject.SetActive(true);
        UpdateLights();
    }

    void UpdateLights()
    {
        var lights = GetLightLayout();
        for (var i = 0; i < Switches.Length; i++)
        {
            lights[i].material.SetColor("_EmissionColor", Switches[i].IsOn ? EnabledLightColour : DisabledLightColour);
        }
    }

    List<Renderer> GetLightLayout()
    {
        switch (Switches.Length)
        {
            case 0: throw new Exception("Did you forget some switches up to this door?");
            case 1: return Layout1Lights;
            case 2: return Layout2Lights;
            case 3: return Layout3Lights;
            case 4: return Layout4Lights;
            default: throw new Exception("That's TOO MANY SWITCHES!!!");
        }
    }

    void EnableLightLayout()
    {
        Layout1Parent.gameObject.SetActive(false);
        Layout2Parent.gameObject.SetActive(false);
        Layout3Parent.gameObject.SetActive(false);
        Layout4Parent.gameObject.SetActive(false);
        switch (Switches.Length)
        {
            case 0: 
                throw new Exception("Did you forget some switches up to this door?");
            case 1: 
                Layout1Parent.gameObject.SetActive(true);
                break;
            case 2:
                Layout2Parent.gameObject.SetActive(true);
                break;
            case 3: 
                Layout3Parent.gameObject.SetActive(true);
                break;
            case 4:
                Layout4Parent.gameObject.SetActive(true);
                break;
            default:
                throw new Exception("That's TOO MANY SWITCHES!!!");
        }
    }
}
