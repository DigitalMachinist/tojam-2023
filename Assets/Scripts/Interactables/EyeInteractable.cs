﻿using UnityEngine;

namespace Interactables
{
    public class EyeInteractable : MonoBehaviour, IInteractable
    {
        public Transform Transform => transform;
        public Renderer Renderer { get; private set;  }

        public void Interact()
        {
            if (!Renderer.isVisible)
            {
                return;
            }
            
            Debug.LogWarning("Interacted with eye!");
            
            // TODO: Activate all the IActivatables here
        }

        void Start()
        {
            Renderer = GetComponentInChildren<Renderer>();
        }
    }
}