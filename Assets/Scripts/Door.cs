using System;
using System.Collections.Generic;
using System.Linq;
using Interactables;
using UnityEngine;

public class Door : MonoBehaviour
{
    public event Action Opened;
    public event Action Closed;

    public Collider Barrier;
    public List<Switch> Switches;
    
    public bool IsOpen { get; set; }

    void Start()
    {
        foreach (var s in Switches)
        {
            s.Activated += OnActivated;
            s.Deactivated += OnDeactivated;
        }

        IsOpen = false;
        Barrier.gameObject.SetActive(true);
        OnActivated();
    }

    void OnActivated()
    {
        var wasOpen = IsOpen;
        IsOpen = Switches.All(x => x.IsOn);
        if (!wasOpen && IsOpen)
        {
            Barrier.gameObject.SetActive(false);
            Opened?.Invoke();
        }
    }

    void OnDeactivated()
    {
        var wasOpen = IsOpen;
        IsOpen = false;
        if (wasOpen)
        {
            Barrier.gameObject.SetActive(true);
            Closed?.Invoke();
        }
    }
}
