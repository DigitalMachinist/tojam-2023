using System;
using UnityEngine;

namespace Interactables
{
    public class LegKickable : MonoBehaviour
    {
        public AudioSource Kicked;
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
            if (Kicked != null)
            {
                Kicked.Play();
            }
            
            Debug.LogWarning("Kicked by leg!");
        }
        
        void Start()
        {
            Renderer = GetComponentInChildren<Renderer>();
            Rigidbody = GetComponentInChildren<Rigidbody>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (Bounce == null)
            {
                return;
            }
            
            Bounce.Play();
        }
    }
}