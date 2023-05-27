using UnityEngine;

namespace Interactables
{
    public class EyeInteractable : MonoBehaviour, IInteractable
    {
        public Transform Transform => transform;
        public Renderer Renderer { get; private set;  }

        public void Interact()
        {
            // Return if not visible
            if (!Renderer.isVisible)
            {
                return;
            }
            
            Debug.LogWarning("Interacted with eye!");
        }

        void Start()
        {
            Renderer = GetComponentInChildren<Renderer>();
        }
    }
}