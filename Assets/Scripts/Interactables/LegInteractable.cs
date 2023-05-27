using UnityEngine;

namespace Interactables
{
    public class LegInteractable : MonoBehaviour
    {
        public Transform Transform { get; }
        public Renderer Renderer { get; private set; }
        
        public void Kick(Vector3 force)
        {
            if (!Renderer.isVisible)
            {
                return;
            }
            
            Debug.LogWarning("Interacted with by leg!");
            
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