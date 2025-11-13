using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitToMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
