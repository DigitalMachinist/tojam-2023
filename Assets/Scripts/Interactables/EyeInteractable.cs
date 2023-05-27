using UnityEngine;

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