using System;
using Interactables;

namespace Activatables
{
    public interface IActivatable
    {
        event Action Activated;
        event Action Deactivated;
        
        bool IsActivated { get; }
        Switch[] Switches { get; }

        void OnActivated();
        void OnDeactivated();
    }
}