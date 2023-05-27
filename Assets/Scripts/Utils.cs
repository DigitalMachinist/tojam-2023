using System.Collections.Generic;
using Interactables;
using UnityEngine;

public static class Utils
{
        public static List<T> GetInteractablesInRange<T>(this Transform transform, float minRange, float maxRange,
            LayerMask interactableLayerMask, LayerMask raycastLayerMask) where T : MonoBehaviour
        {
            var interactables = new List<T>();
            var colliders = Physics.OverlapSphere(transform.position, maxRange, interactableLayerMask);
            
            foreach (var collider in colliders)
            {
                if (!collider)
                {
                    Debug.LogWarning("Collider is null!");
                    continue;
                }
                
                if (!collider.TryGetComponent<T>(out var interactable))
                {
                    Debug.LogWarning($"Object {collider.name} is missing a {typeof(T).Name} component!");
                    continue;
                }
                
                var origin = transform.position;
                var interactableTransform = interactable!.transform;
                var direction = interactableTransform.position - origin;
                var distance = direction.magnitude;
                var ray = new Ray(origin, direction);
            
                // Draw the ray
                Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, 1f);
            
                var hit = Physics.Raycast(ray, out var hitInfo, distance, raycastLayerMask);
                if (!hit || !hitInfo.transform)
                {
                    continue;
                }
            
                Debug.Log($"{transform.gameObject.name} hit {hitInfo.transform.name}!");

                if (hitInfo.transform != interactableTransform)
                {
                    continue;
                }

                if (distance < minRange || distance > maxRange)
                {
                    continue;
                }

                interactables.Add(interactable);
            }
            return interactables;
        }
}