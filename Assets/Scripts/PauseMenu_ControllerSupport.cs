using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu_ControllerSupport : MonoBehaviour
{
    public InputActionAsset navigateAction;
    private InputAction navigateInput;
    private InputAction submitMenuInput;
    public Button TopLeftButton;
    public Button TopRightButton;
    public Button BottomLeftButton;
    public Button BottomRightButton;
    private Button current;
    private bool isAxisInUse = false;

    void Start()
    {
        navigateInput = navigateAction.FindAction("Navigate");
        navigateInput.performed += ctx => OnNavigate(ctx.ReadValue<Vector2>());
        
        submitMenuInput = navigateAction.FindAction("Submit");
        submitMenuInput.performed += ctx => OnSubmit();
        
        current = BottomLeftButton;
        current.Select();
    }
    public void OnNavigate(Vector2 navigateInput)
    {
        if (isAxisInUse)
        {
            return;
        }
        
        if (navigateInput.x > 0.1f)
        {
            SelectRight();
        }
        else if (navigateInput.x < -0.1f)
        {
            SelectLeft();
        }
        else if (navigateInput.y > 0.1f)
        {
            SelectUp();
        }
        else if (navigateInput.y < -0.1f)
        {
            SelectDown();
        }
    }
    IEnumerator Delay()
    {
        isAxisInUse = true;
        yield return new WaitForSeconds(0.1f);
        isAxisInUse = false;
    }

    private void SelectUp()
    {
        if (current == BottomLeftButton)
        {
            if (TopLeftButton != null)
            {
                current = TopLeftButton;
                current.Select();
            }
            else if (TopRightButton != null)
            {
                current = TopRightButton;
                current.Select();
            }
        }
        else if (current == BottomRightButton)
        {
            if (TopRightButton != null)
            {
                current = TopRightButton;
                current.Select();
            }
            else if (TopLeftButton != null)
            {
                current = TopLeftButton;
                current.Select();
            }
        }

        if (!isAxisInUse)
        {
            StartCoroutine(Delay());
        }
    }

    private void SelectDown()
    {
        if (current == TopLeftButton)
        {
            if (BottomLeftButton != null)
            {
                current = BottomLeftButton;
                current.Select();
            }
            else if (BottomRightButton != null)
            {
                current = BottomRightButton;
                current.Select();
            }
        }
        else if (current == TopRightButton)
        {
            if (BottomRightButton != null)
            {
                current = BottomRightButton;
                current.Select();
            }
            else if (BottomLeftButton != null)
            {
                current = BottomLeftButton;
                current.Select();
            }
        }

        if (!isAxisInUse)
        {
            StartCoroutine(Delay());
        }
    }

    private void SelectLeft()
    {
        if (current == BottomRightButton)
        {
            if (BottomLeftButton != null)
            {
                current = BottomLeftButton;
                current.Select();
            }
            else if (TopLeftButton != null)
            {
                current = TopLeftButton;
                current.Select();
            }
        }
        else if (current == TopRightButton)
        {
            if (TopLeftButton != null)
            {
                current = TopLeftButton;
                current.Select();
            }
            else if (BottomLeftButton != null)
            {
                current = BottomLeftButton;
                current.Select();
            }
        }

        if (!isAxisInUse)
        {
            StartCoroutine(Delay());
        }
    }

    private void SelectRight()
    {
        if (current == BottomLeftButton)
        {
            if (BottomRightButton != null)
            {
                current = BottomRightButton;
                current.Select();
            }
            else if (TopRightButton != null)
            {
                current = TopRightButton;
                current.Select();
            }
        }
        else if (current == TopLeftButton)
        {
            if (TopRightButton != null)
            {
                current = TopRightButton;
                current.Select();
            }
            else if (BottomRightButton != null)
            {
                current = BottomRightButton;
                current.Select();
            }
        }

        if (!isAxisInUse)
        {
            StartCoroutine(Delay());
        }
    }

    private void OnSubmit()
    {
        current.onClick?.Invoke();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("SCN_MainMenu");
    }
}
