using UnityEngine;

namespace Interactables
{
    public class ArmInteractable : MonoBehaviour
    {
        public Transform Transform { get; private set; }
        public Renderer Renderer { get; private set; }

        public void Interact()
        {
            if (!Renderer.isVisible)
            {
                return;
            }
            
            Debug.LogWarning($"{gameObject.name} interacted with arm!");
            
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
            Transform = transform;
            Renderer = GetComponentInChildren<Renderer>();
        }
    }
}