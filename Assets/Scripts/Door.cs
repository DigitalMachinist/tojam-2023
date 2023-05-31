using System;
using System.Collections.Generic;
using System.Linq;
using Interactables;
using UnityEngine;
using UnityEngine.Serialization;

public class Door : MonoBehaviour
{
    public event Action Opened;
    public event Action Closed;

    public Collider Barrier;
    
    [Header("Indicator Lights")]
    public Color DisabledLightColour = Color.green;
    public Color EnabledLightColour = Color.red;
    public float EnableDelaySeconds = 1f;
    public Transform Layout1Parent;
    public List<Renderer> Layout1Lights;
    public Transform Layout2Parent;
    public List<Renderer> Layout2Lights;
    public Transform Layout3Parent;
    public List<Renderer> Layout3Lights;
    public Transform Layout4Parent;
    public List<Renderer> Layout4Lights;
    
    [Header("Interactive Elements")]
    public List<Switch> Switches;
    
    public Animator Animator { get; private set; }
    public bool IsOpen { get; private set; }

    void Start()
    {
        Animator = GetComponentInChildren<Animator>();
        
        foreach (var s in Switches)
        {
            s.Activated += OnActivated;
            s.Deactivated += OnDeactivated;
        }

        IsOpen = false;
        OnActivated();
    }
    

    async void OnActivated()
    {
        var wasOpen = IsOpen;
        IsOpen = Switches.All(x => x.IsOn);
        Animator.SetBool("IsOpen", IsOpen);
        Barrier.gameObject.SetActive(!IsOpen);
        if (!wasOpen && IsOpen)
        {
            Opened?.Invoke();
        }
        await new WaitForSeconds()
    }

    void OnDeactivated()
    {
        var wasOpen = IsOpen;
        IsOpen = false;
        Animator.SetBool("IsOpen", IsOpen);
        Barrier.gameObject.SetActive(!IsOpen);
        if (wasOpen)
        {
            Closed?.Invoke();
        }
    }
}
