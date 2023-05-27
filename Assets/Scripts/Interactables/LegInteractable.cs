using UnityEngine;

namespace Interactables
{
    public class LegInteractable : MonoBehaviour, IInteractable
    {
        public Transform Transform { get; }
        public Renderer Renderer { get; private set; }
        
        public void Interact()
        {
            if (!Renderer.isVisible)
            {
                return;
            }
            
            Debug.LogWarning("Interacted with leg!");
            
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