using System;
using DG.Tweening;
using Interactables;
using UnityEngine;

namespace Activatables
{
    public class MovingPlatform : MonoBehaviour, IActivatable
    {
        public event Action Activated;
        public event Action Deactivated;
        
        [field: Header("Activation")] 
        public AudioSource MovingSound;
        [field: SerializeField] public Switch[] Switches { get; private set; }

        [Header("Indicator Lights")]
        public Renderer Light;
        public Color DisabledLightColour = Color.red;
        public Color EnabledLightColour = Color.green;
        
        [Header("Movement Settings")] 
        [SerializeField] bool activateOnStart;
        [SerializeField] private float movementDuration = 3f;
        [SerializeField] private Transform targetTransform;

        [Header("Delays")]
        [SerializeField] private float startDelay = 0f;
        [SerializeField] private float beforeFirstMovementDelay = 0f;
        [SerializeField] private float beforeSecondMovementDelay = 0f;
        
        public bool IsActivated { get; private set; }
        
        private Vector3 startPosition;
        private Transform currentTargetTransform;
        
        Sequence movementSequence;
        
        public void SetTargetTransform(Transform target) => currentTargetTransform = target;

        public void OnActivated()
        {
            movementSequence.Play();
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
            movementSequence.Pause();
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
        
        private void Start()
        {
            startPosition = transform.position;
            
            if (targetTransform)
            {
                SetTargetTransform(targetTransform);
            }
            
            movementSequence = DOTween.Sequence();
            movementSequence.AppendInterval(beforeFirstMovementDelay);
            movementSequence.Append(transform.DOMove(currentTargetTransform.position, movementDuration));
            movementSequence.AppendInterval(beforeSecondMovementDelay);
            movementSequence.Append(transform.DOMove(startPosition, movementDuration));
            movementSequence.SetLoops(-1);

            if (Switches.Length > 0)
            {
                foreach (var s in Switches)
                {
                    s.Activated += OnActivated;
                    s.Deactivated += OnDeactivated;
                }
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
    }
}