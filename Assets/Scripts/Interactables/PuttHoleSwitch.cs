using UnityEngine;

namespace Interactables
{
    [RequireComponent(typeof(Collider))]
    public class PuttHoleSwitch : Switch
    {
        void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Ball"))
            {
                return;
            }
            
            Debug.Log("aaa");
            Activate();
        }
        
        void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Ball"))
            {
                return;
            }
            
            Debug.Log("bbb");
            Deactivate();
        }
    }
}
