using Interactables;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

namespace Handlers
{
    public class MenuAudioHandler : MonoBehaviour
    {
        [SerializeField] Canvas canvas;
        
        [SerializeField] AudioSource movedSelection;
        [SerializeField] AudioSource cancelledSelection;
        [SerializeField] AudioSource selected;

        private Button[] _buttons;
        private InputSystemUIInputModule uiInput;

        void Start()
        {
            uiInput = FindObjectOfType<InputSystemUIInputModule>();
            uiInput.move.action.performed += OnMoved;
            uiInput.cancel.action.performed += OnCancelled;
            uiInput.submit.action.performed += OnSubmitted;
        }

        void OnDestroy()
        {
            uiInput.move.action.performed -= OnMoved;
            uiInput.cancel.action.performed -= OnCancelled;
            uiInput.submit.action.performed -= OnSubmitted;
        }
        
        private void OnMoved(InputAction.CallbackContext context)
        {
            Debug.Log("OnMoved");
            if (movedSelection == null)
            {
                return;
            }
            
            movedSelection.Play();
        }
        
        private void OnCancelled(InputAction.CallbackContext context)
        {
            Debug.Log("OnCancelled");
            if (cancelledSelection == null)
            {
                return;
            }
            
            cancelledSelection.Play();
        }
        
        private void OnSubmitted(InputAction.CallbackContext context)
        {
            Debug.Log("OnSubmitted");
            if (selected == null)
            {
                return;
            }
            
            selected.Play();
        }
    }
}