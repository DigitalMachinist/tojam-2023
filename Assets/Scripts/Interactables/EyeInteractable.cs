using UnityEngine;

namespace Interactables
{
    public class EyeInteractable : MonoBehaviour
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
            
            if (!TryGetComponent(out Switch switchComponent))
            {
                return;
            }
            
            if (switchComponent.IsOn)
            {
                switchComponent.Deactivate();
            }
            else
            {
                switchComponent.Activate();
            }
        }

        void Start()
        {
            Renderer = GetComponentInChildren<Renderer>();
        }
    }
}