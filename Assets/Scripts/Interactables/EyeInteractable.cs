using UnityEngine;

namespace Interactables
{
    public class EyeInteractable : MonoBehaviour
    {
        public Transform Transform => transform;
        public Renderer Renderer { get; private set;  }
        public Switch Switch { get; private set;  }

        public void Interact()
        {
            // Return if not visible
            if (!Renderer.isVisible)
            {
                return;
            }
            
            Debug.LogWarning("Interacted with eye!");
            
            if (Switch == null)
            {
                return;
            }
            
            if (Switch.IsOn)
            {
                Switch.Deactivate();
            }
            else
            {
                Switch.Activate();
            }
        }

        void Awake()
        {
            Renderer = GetComponentInChildren<Renderer>();
            Switch = GetComponentInChildren<Switch>();
        }
    }
}