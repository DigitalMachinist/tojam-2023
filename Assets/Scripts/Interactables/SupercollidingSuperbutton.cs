using UnityEngine;

namespace Interactables
{
    [RequireComponent(typeof(Collider))]
    public class SupercollidingSuperbutton : Switch
    {
        private int numActivations = 0;
        
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
