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
            
            Activate();
        }
        
        void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Ball"))
            {
                return;
            }
            
            Deactivate();
        }
    }
}
