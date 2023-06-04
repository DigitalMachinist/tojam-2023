using System;
using UnityEngine;

namespace Interactables
{
    public class Switch : MonoBehaviour
    {
        public event Action Activated;
        public event Action Deactivated;
        public Renderer switchRenderer;
        private Material _switchMaterial;

        Color _onColor = Color.green * 2;
        Color _offColor = Color.red * 2;

        public bool IsOn { get; private set; }

        void Start()
        {
            if (switchRenderer != null)
            {
                Instantiate(switchRenderer.material);
                _switchMaterial = switchRenderer.material;
            }
            Deactivate();
        }
        public void Activate()
        {
            IsOn = true;
            Activated?.Invoke();
            if (_switchMaterial != null)
            {
                _switchMaterial.SetColor("_EmissionColor", _onColor);
            }
        }

        public void Deactivate()
        {
            IsOn = false;
            Deactivated?.Invoke();
            if (_switchMaterial != null)
            {
                _switchMaterial.SetColor("_EmissionColor", _offColor);
            }
        }
    }
}
