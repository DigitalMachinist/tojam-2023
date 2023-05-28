using System;
using DG.Tweening;
using Interactables;
using UnityEngine;

namespace Activatables
{
    public class NonLoopMovingPlatform : MonoBehaviour, IActivatable
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
        
        private Vector3 startPosition;
        private Transform currentTargetTransform;

        public void OnActivated()
        {
            transform.DOKill();
            transform.DOMove(targetTransform.position, movementDuration);
            IsActivated = true;
            Activated?.Invoke();
        }

        public void OnDeactivated()
        {
            transform.DOKill();
            transform.DOMove(startPosition, movementDuration);
            IsActivated = false;
            Deactivated?.Invoke();
        }
        
        private void Start()
        {
            startPosition = transform.position;

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