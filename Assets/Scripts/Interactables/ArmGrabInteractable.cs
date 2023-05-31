using UnityEngine;

namespace Interactables
{
    public class ArmGrabInteractable : MonoBehaviour
    {
        public Transform Transform { get; private set; }
        public Renderer Renderer { get; private set;  }
        public Rigidbody Rigidbody { get; private set;  }
        
        Transform originalParent;
        
        public void Interact() { }
        
        public ArmGrabInteractable Grab(Transform grabTransform)
        {
            if (!Renderer.isVisible)
            {
                return null;
            }
            
            Debug.LogWarning($"{gameObject.name} grabbed by arm!");
            
            Transform.SetParent(grabTransform);
            Transform.localPosition = Vector3.zero;
            Transform.localRotation = Quaternion.identity;
            
            Rigidbody.isKinematic = true;
            GetComponent<Collider>().isTrigger = true;
            Rigidbody.useGravity = false;

            return this;
        }
        
        public void Release()
        {
            Debug.LogWarning($"{gameObject.name} released by arm!");
            Transform.SetParent(originalParent);
            Rigidbody.isKinematic = false;
            GetComponent<Collider>().isTrigger = false;
            Rigidbody.useGravity = true;
        }
        
        void Start()
        {
            Transform = transform;
            Renderer = GetComponentInChildren<Renderer>();
            Rigidbody = GetComponentInChildren<Rigidbody>();
            originalParent = Transform.parent;
        }
    }
}