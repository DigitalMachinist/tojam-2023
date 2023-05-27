using System;
using UnityEngine;

namespace Interactables
{
    public class Switch : MonoBehaviour
    {
        public event Action Activated;
        public event Action Deactivated;
    
        public bool IsOn { get; private set; }

        public void Activate()
        {
            IsOn = true;
            Activated?.Invoke();
        }

        public void Deactivate()
        {
            IsOn = false;
            Deactivated?.Invoke();
        }
    }
}
