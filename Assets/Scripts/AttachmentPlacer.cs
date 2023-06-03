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

        // We need to do some geometry to handle how to place parts of horizontal vs vertical surfaces.
        // If placing on any non-horizontal surface, we want the attachment's "up" to point in the direction
        // the camera to player is using to aim the place. However, if the surface is vertical (or at least
        // non-horizontal, we'll use global up for the facing direction.
        var aimVector = Camera.main.transform.forward;
        var horizontalAimVector = (new Vector3(aimVector.x, 0f, aimVector.z)).normalized;
        var dot = Vector3.Dot(hitInfo.normal, Vector3.up);
        var up = Mathf.Abs(dot) < 0.9f
            ? Vector3.up
            : horizontalAimVector;
        
        var attachment = Instantiate(AttachmentPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal, up));
        attachment.transform.SetParent(hitInfo.transform, true);

        return attachment;
    }
}