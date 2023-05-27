using UnityEngine;

namespace Interactables
{
    public interface IInteractable
    {
        Transform Transform { get; }
        Renderer Renderer { get; }
        void Interact();
    }
}