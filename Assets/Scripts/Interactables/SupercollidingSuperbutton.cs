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
            
            Debug.Log("aaa");
            Activate();
        }
        
        void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Box"))
            {
                return;
            }
            
            Debug.Log("bbb");
            Deactivate();
        }
    }
}
