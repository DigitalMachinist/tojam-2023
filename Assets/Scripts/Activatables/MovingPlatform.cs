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
        [field: SerializeField] public bool IsActivated { get; private set; }
        [field: SerializeField] public Switch[] Switches { get; private set; }

        [Header("Movement Settings")] 
        [SerializeField] bool activateOnStart;
        [SerializeField] private float movementDuration = 3f;
        [SerializeField] private Transform targetTransform;

        [Header("Delays")]
        [SerializeField] private float startDelay = 0f;
        [SerializeField] private float beforeFirstMovementDelay = 0f;
        [SerializeField] private float beforeSecondMovementDelay = 0f;
        
        private Vector3 startPosition;
        private Transform currentTargetTransform;
        
        Sequence movementSequence;
        
        public void SetTargetTransform(Transform target) => currentTargetTransform = target;

        public void OnActivated()
        {
            movementSequence.Play();
            IsActivated = true;
            Activated?.Invoke();
        }

        public void OnDeactivated()
        {
            movementSequence.Pause();
            IsActivated = false;
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