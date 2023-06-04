using System;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class UIMenu_ControllerSupport : MonoBehaviour
{
    public event Action Navigated;
    public event Action Cancelled;
    public event Action Submitted;
    
    private EventSystem eventSystem;
    public InputActionAsset navigateAction;
    private InputAction navigateInput;
    private InputAction closeMenuInput;
    private InputAction submitMenuInput;
    private List<Button> selectables = new List<Button>();
    public List<Button> menuSelectables = new List<Button>();
    public List<Button> playSelectables = new List<Button>();
    public List<GameObject> menuPanels = new List<GameObject>();
    private Button current;
    private bool isAxisInUse = false;

    void Start()
    {
        //navigateAction = new InputAction("Navigate", binding: "<Gamepad>/leftStick");
        eventSystem = EventSystem.current;
        navigateInput = navigateAction.FindAction("Navigate");
        closeMenuInput = navigateAction.FindAction("Cancel");
        submitMenuInput = navigateAction.FindAction("Submit");

        navigateInput.performed += ctx => OnNavigate(ctx.ReadValue<Vector2>());
        closeMenuInput.performed += ctx => OnCloseMenu();
        submitMenuInput.performed += ctx => OnSubmit();

        selectables = new List<Button>(menuSelectables);

        current = eventSystem.firstSelectedGameObject.GetComponent<Button>();
    }
    public void OnNavigate(Vector2 navigateInput)
    {
        if (isAxisInUse)
        {
            return;
        }
        
        if (navigateInput.y > 0.1f)
        {
            Debug.Log("Up");
            SelectUp();
        }
        else if (navigateInput.y < -0.1f)
        {
            Debug.Log("Down");
            SelectDown();
        }
    }
    IEnumerator Delay()
    {
        isAxisInUse = true;
        yield return new WaitForSeconds(0.1f);
        isAxisInUse = false;
    }

    public void OpenPlayMenu()
    {
        selectables.Clear();
        selectables = new List<Button>(playSelectables);
        current = selectables[0];
        current.Select();
    }
    public void OnCloseMenu()
    {
        foreach (GameObject panel in menuPanels)
        {
            panel.SetActive(false);
        }
        selectables.Clear();
        selectables = new List<Button>(menuSelectables);
        current = selectables[0];
        current.Select();
        Cancelled?.Invoke();
    }

    private void SelectUp()
    {
        if (current != selectables[0])
        {
            current = selectables[selectables.IndexOf(current) - 1];
            current.Select();
        }
        else
        {
            current = selectables[selectables.Count - 1];
            current.Select();
        }
        Navigated?.Invoke();
        StartCoroutine(Delay());
    }

    private void SelectDown()
    {
        if (current != selectables[selectables.Count - 1])
        {
            current = selectables[selectables.IndexOf(current) + 1];
            current.Select();
        }
        else
        {
            current = selectables[0];
            current.Select();
        }
        Navigated?.Invoke();
        StartCoroutine(Delay());
    }
    
    public void OnSubmit()
    {
        Submitted?.Invoke();
    }
}
