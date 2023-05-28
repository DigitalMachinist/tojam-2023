using UnityEngine;

namespace Interactables
{
    [RequireComponent(typeof(Collider))]
    public class SupercollidingSuperbutton : Switch
    {
        void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Box"))
            {
                return;
            }
            
            Activate();
        }
        
        void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Box"))
            {
                return;
            }
            
            Deactivate();
        }
    }
}
