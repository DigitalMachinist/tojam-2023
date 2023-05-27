using System;
using UnityEngine;

public class AttachmentPlacerTester : MonoBehaviour
{
    public AttachmentPlacer AttachmentPlacer;
    public Transform LookTransform;
    
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }

        try
        {
            // Create the attachment.
            var attachment = AttachmentPlacer.TryPlace(new Ray(LookTransform.position, LookTransform.forward));
            
            // Draw a debug ray in the scene view so we can confirm the placement.
            var lookToAttachment = attachment.transform.position - LookTransform.position;
            Debug.DrawRay(LookTransform.position, lookToAttachment, Color.red, 10f);
        }
        catch (Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }
}