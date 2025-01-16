using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonControl : MonoBehaviour
{
    
    public void OnStartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }
}
