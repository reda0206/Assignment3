using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsSceneButton : MonoBehaviour
{
   public void BackButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
