using UnityEngine;

namespace Interactables
{
    public class LegKickable : MonoBehaviour
    {
        public Transform Transform { get; }
        public Renderer Renderer { get; private set; }
        public Rigidbody Rigidbody { get; private set; }
        
        public void Kick(Vector3 force)
        {
            if (!Renderer.isVisible)
            {
                return;
            }
            
            Rigidbody.AddForce(force, ForceMode.Impulse);
            
            Debug.LogWarning("Kicked by leg!");
            
            // if (!TryGetComponent(out Switch switchComponent))
            // {
            //     return;
            // }
            //
            // if (switchComponent.IsOn)
            // {
            //     switchComponent.Deactivate();
            // }
            // else
            // {
            //     switchComponent.Activate();
            // }
        }
        
        void Start()
        {
            Renderer = GetComponentInChildren<Renderer>();
            Rigidbody = GetComponentInChildren<Rigidbody>();
        }
    }
}