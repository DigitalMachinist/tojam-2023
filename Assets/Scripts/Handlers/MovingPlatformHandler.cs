using System;
using DG.Tweening;
using UnityEngine;

namespace Handlers
{
    public class MovingPlatformHandler : MonoBehaviour
    {
        [SerializeField] private float movementDuration = 3f;
        [SerializeField] private Transform targetTransform;
        [SerializeField] private int loops = -1;
        [SerializeField] private Ease ease = Ease.Linear;
        [SerializeField] private LoopType loopType = LoopType.Yoyo;
        
        [Header("Delays")]
        [SerializeField] private float startDelay = 0f;
        [SerializeField] private float beforeFirstMovementDelay = 0f;
        [SerializeField] private float beforeSecondMovementDelay = 0f;

        private Rigidbody platformRigidbody;
        private Vector3 startPosition;
        private Transform currentTargetTransform;
        
        public void SetTargetTransform(Transform target) => currentTargetTransform = target;

        private void Start()
        {
            platformRigidbody = GetComponent<Rigidbody>();
            startPosition = transform.position;
            
            if (targetTransform)
            {
                SetTargetTransform(targetTransform);
            }
            
            MoveAsync();
        }

        private async void MoveAsync()
        {
            await new WaitForSeconds(startDelay);
            
            while (enabled)
            {
                await new WaitForSeconds(beforeFirstMovementDelay);
                await transform.DOMove(currentTargetTransform.position, movementDuration).AsyncWaitForCompletion();
                await new WaitForSeconds(beforeSecondMovementDelay);
                await transform.DOMove(startPosition, movementDuration).AsyncWaitForCompletion();
            }
        }
    }
}