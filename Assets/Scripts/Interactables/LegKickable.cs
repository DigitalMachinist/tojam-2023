using System;
using UnityEngine;

namespace Interactables
{
    public class LegKickable : MonoBehaviour
    {
        public AudioSource Bounce;
        
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
        }
        
        void Start()
        {
            Renderer = GetComponentInChildren<Renderer>();
            Rigidbody = GetComponentInChildren<Rigidbody>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.collider.CompareTag("Attachable") && !other.collider.CompareTag("Unattachable"))
            {
                return;
            }
            
            Bounce.Play();
        }
    }
}