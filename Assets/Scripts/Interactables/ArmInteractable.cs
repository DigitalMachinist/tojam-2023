using UnityEngine;

namespace Interactables
{
    public class ArmInteractable : MonoBehaviour, IInteractable
    {
        public Transform Transform { get; private set; }
        public Renderer Renderer { get; private set; }
        
        Transform originalParent;
        Vector3 originalPosition;
        Quaternion originalRotation;
        
        public void Interact()
        {
            if (!Renderer.isVisible)
            {
                return;
            }
            
            Debug.LogWarning($"{gameObject.name} interacted with arm!");
            
            // TODO: Activate all the IActivatables here
        }
        
        public ArmInteractable Grab(Transform grabTransform)
        {
            if (!Renderer.isVisible)
            {
                return null;
            }
            
            Debug.LogWarning($"{gameObject.name} grabbed by arm!");
            
            Transform.SetParent(grabTransform);
            Transform.localPosition = Vector3.zero;
            Transform.localRotation = Quaternion.identity;
            
            return this;
        }
        
        public void Release()
        {
            Debug.LogWarning($"{gameObject.name} released by arm!");
            Transform.SetParent(originalParent);
            Transform.localPosition = originalPosition;
            Transform.localRotation = originalRotation;
        }

        void Start()
        {
            Transform = transform;
            Renderer = GetComponentInChildren<Renderer>();
            originalParent = Transform.parent;
            originalPosition = Transform.localPosition;
            originalRotation = Transform.localRotation;
        }
    }
}