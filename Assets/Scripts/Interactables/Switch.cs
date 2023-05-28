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
            if(_switchMaterial != null)
            _switchMaterial.SetColor("_EmissionColor", Color.green);
            if(_doorLightMaterial != null)
            _doorLightMaterial.SetColor("_EmissionColor", Color.green);
        }

        public void Deactivate()
        {
            IsOn = false;
            Deactivated?.Invoke();
            if(_switchMaterial != null)
            _switchMaterial.SetColor("_EmissionColor", Color.red);
            if(_doorLightMaterial != null)
            _doorLightMaterial.SetColor("_EmissionColor", Color.red);
        }
    }
}
