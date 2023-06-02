using System;
using UnityEngine;

namespace Interactables
{
    public class Switch : MonoBehaviour
    {
        public event Action Activated;
        public event Action Deactivated;
        public Renderer switchRenderer;
        public Renderer doorLightRenderer;
        private Material _switchMaterial;
        private Material _doorLightMaterial;

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

            if (doorLightRenderer != null)
            {
                Instantiate(doorLightRenderer.material);
                _doorLightMaterial = doorLightRenderer.material;
            }
            Deactivate();
        }
        public void Activate()
        {
            IsOn = true;
            Activated?.Invoke();
            // if(_switchMaterial != null)
            // _switchMaterial.SetColor("_EmissionColor", _onColor);
            // if(_doorLightMaterial != null)
            // _doorLightMaterial.SetColor("_EmissionColor", _onColor);
        }

        public void Deactivate()
        {
            IsOn = false;
            Deactivated?.Invoke();
            // if(_switchMaterial != null)
            // _switchMaterial.SetColor("_EmissionColor", _offColor);
            // if(_doorLightMaterial != null)
            // _doorLightMaterial.SetColor("_EmissionColor", _offColor);
        }
    }
}
