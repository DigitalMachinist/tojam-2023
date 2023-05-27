using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class AttachmentPlacer : MonoBehaviour
{
    public Attachment AttachmentPrefab;
    public float Range = 10f;
    
    public Attachment TryPlace(Ray ray)
    {
        if (!Physics.Raycast(ray, out var hitInfo, Range))
        {
            throw new Exception("Can't attach to nothing.");
        }
        if (!hitInfo.collider.CompareTag("Attachable"))
        {
            throw new Exception("Can't attach to a non-attachable collider.");
        }

        var attachment = Object.Instantiate(
            AttachmentPrefab,
            hitInfo.point,
            Quaternion.LookRotation(hitInfo.normal, Vector3.up)
        );
        
        attachment.transform.SetParent(hitInfo.transform, true);

        return attachment;
    }
}