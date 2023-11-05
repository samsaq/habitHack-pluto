using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load next scene (should be the first scenario)
    }

    public void quitGame()
    {
        Debug.Log("Quitting - Unity Editor will not do anything on quit, but it's working");
        Application.Quit();
    }
}
