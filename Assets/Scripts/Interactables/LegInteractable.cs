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
            
            // TODO: Activate all the IActivatables here
        }
        
        void Start()
        {
            Renderer = GetComponentInChildren<Renderer>();
        }
    }
}