using UnityEngine;
using UnityEngine.UI;

namespace Handlers
{
    public class MenuAudioHandler : MonoBehaviour
    {
        [SerializeField] AudioSource movedSelection;
        [SerializeField] AudioSource cancelledSelection;
        [SerializeField] AudioSource selected;

        private Button[] _buttons;
        private UIMenu_ControllerSupport uiInput;

        void Start()
        {
            uiInput = FindObjectOfType<UIMenu_ControllerSupport>();
            uiInput.Navigated += OnMoved;
            uiInput.Cancelled += OnCancelled;
            uiInput.Submitted += OnSubmitted;
        }

        void OnDestroy()
        {
            uiInput.Navigated -= OnMoved;
            uiInput.Cancelled -= OnCancelled;
            uiInput.Submitted -= OnSubmitted;
        }
        
        private void OnMoved()
        {
            Debug.Log("OnMoved");
            if (movedSelection == null)
            {
                return;
            }
            
            movedSelection.Play();
        }
        
        private void OnCancelled()
        {
            Debug.Log("OnCancelled");
            if (cancelledSelection == null)
            {
                return;
            }
            
            cancelledSelection.Play();
        }
        
        private void OnSubmitted()
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