using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
    public event Action Submitted;

    public void PlayGame(string sceneName)
    {
        Submitted?.Invoke();
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Submitted?.Invoke();
        Application.Quit();
    }

    public void LoadScene(string sceneName)
    {
        Submitted?.Invoke();
        SceneManager.LoadScene(sceneName);
    }

}
