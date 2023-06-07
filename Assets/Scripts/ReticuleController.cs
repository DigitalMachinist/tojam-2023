using UnityEngine;
using UnityEngine.UI;

public class ReticuleController : MonoBehaviour
{
    public Image Neutral;
    public Image Attachable;
    public Image Arm;
    public Image Eye;
    public Image Leg;
    public Image ArmAndLeg;
    public LayerMask LayerMask;
    public float Range = 5f;
    
    void Update()
    {
        var camera = Camera.main;
        if (camera == null)
        {
            return;
        }
        
        DisableReticuleImage();
        
        var cameraTransform = camera.transform;
        var ray = new Ray(cameraTransform.position, cameraTransform.forward);
        if (!Physics.Raycast(ray, out var hitInfo, 100f, LayerMask))
        {
            Neutral.gameObject.SetActive(true);
            return;
        }

        if (hitInfo.distance > Range)
        {
            Neutral.gameObject.SetActive(true);
            return;
        }
        
        // Debug.Log(hitInfo.collider.name);
        // Debug.Log(cameraTransform.forward);
        // Debug.DrawRay(ray.origin, hitInfo.point - ray.origin, Color.magenta, 2f);
        if (hitInfo.collider.CompareTag("Untagged"))
        {
            // Debug.Log("Untagged");
            Neutral.gameObject.SetActive(true);
        }
        else if (hitInfo.collider.CompareTag("Attachable"))
        {
            // Debug.Log("Attachable");
            Attachable.gameObject.SetActive(true);
        }
        else if (hitInfo.collider.CompareTag("Arm"))
        {
            // Debug.Log("Arm");
            Arm.gameObject.SetActive(true);
        }
        else if (hitInfo.collider.CompareTag("Eye"))
        {
            // Debug.Log("Eye");
            Eye.gameObject.SetActive(true);
        }
        else if (hitInfo.collider.CompareTag("Leg"))
        {
            // Debug.Log("Leg");
            Leg.gameObject.SetActive(true);
        }
        else if (hitInfo.collider.CompareTag("Box"))
        {
            // Debug.Log("Box");
            ArmAndLeg.gameObject.SetActive(true);
        }
        else if (hitInfo.collider.CompareTag("Ball"))
        {
            // Debug.Log("Ball");
            ArmAndLeg.gameObject.SetActive(true);
        }
        else
        {
            // Debug.Log("Other Tag");
            Neutral.gameObject.SetActive(true);
        }
    }

    private void DisableReticuleImage()
    {
        Neutral.gameObject.SetActive(false);
        Attachable.gameObject.SetActive(false);
        Arm.gameObject.SetActive(false);
        Eye.gameObject.SetActive(false);
        Leg.gameObject.SetActive(false);
        ArmAndLeg.gameObject.SetActive(false);
    }
}
