using System;
using DG.Tweening;
using Interactables;
using UnityEngine;
using UnityEngine.Serialization;

namespace Activatables
{
    public class FollowingPlatform : MonoBehaviour, IActivatable
    {
        public event Action Activated;
        public event Action Deactivated;
        
        [Header("Indicator Lights")]
        public Renderer Light;
        public Color DisabledLightColour = Color.red;
        public Color EnabledLightColour = Color.green;
        
        [Header("Movement Settings")] 
        public bool activateOnStart;
        public Vector3 speed = Vector3.one;
        public Vector3 offset = Vector3.zero;

        [field: Header("Activation")]
        public AudioSource MovingSound;
        [field: SerializeField] public Switch[] Switches { get; private set; }

        public bool IsActivated { get; private set; }
        public Vector3 StartPosition { get; private set; }
        public Transform TargetTransform { get; private set; }
        
        public void OnActivated()
        {
            TargetTransform = FindObjectOfType<Player>().transform;
            IsActivated = true;
            if (Light != null)
            {
                Light.material.SetColor("_EmissionColor", EnabledLightColour);
            }
            if (MovingSound != null)
            {
                MovingSound.Play();
            }
            Activated?.Invoke();
        }

        public void OnDeactivated()
        {
            TargetTransform = null;
            IsActivated = false;
            if (Light != null)
            {
                Light.material.SetColor("_EmissionColor", DisabledLightColour);
            }
            if (MovingSound != null)
            {
                MovingSound.Stop();
            }
            Deactivated?.Invoke();
        }
        
        void Start()
        {
            StartPosition = transform.position;
            
            foreach (var s in Switches)
            {
                s.Activated += OnActivated;
                s.Deactivated += OnDeactivated;
            }

            if (activateOnStart)
            {
                OnActivated();
            }
            else
            {
                OnDeactivated();
            }
        }

        void FixedUpdate()
        {
            var targetPosition = transform.position + offset;
            
            Vector3 error;
            if (TargetTransform == null || !IsActivated)
            {
                error = StartPosition - transform.position;
            }
            else
            {
                error = TargetTransform.position + offset - transform.position;
            }

            if (speed.x > 0f)
            {
                var distance = Math.Min(speed.x * Time.fixedDeltaTime, error.x);
                transform.Translate(distance, 0f, 0f);
            }
            if (speed.y > 0f)
            {
                var distance = Math.Min(speed.y * Time.fixedDeltaTime, error.y);
                transform.Translate(0f, distance, 0f);
            }
            if (speed.z > 0f)
            {
                var distance = Math.Min(speed.z * Time.fixedDeltaTime, error.z);
                transform.Translate(0f, 0f, distance);
            }
        }
    }
}