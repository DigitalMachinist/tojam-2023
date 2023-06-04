using UnityEngine;

namespace Interactables
{
    public class ArmInteractable : MonoBehaviour
    {
        public Transform Transform { get; private set; }
        public Renderer Renderer { get; private set; }
        public Switch Switch { get; private set;  }

        public void Interact()
        {
            if (!Renderer.isVisible)
            {
                return;
            }
            
            Debug.LogWarning($"{gameObject.name} interacted with arm!");
            
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
        
        void Start()
        {
            Transform = transform;
            Renderer = GetComponentInChildren<Renderer>();
            Switch = GetComponentInChildren<Switch>();
        }
    }
}