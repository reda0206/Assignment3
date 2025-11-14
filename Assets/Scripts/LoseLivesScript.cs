using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseLivesScript : MonoBehaviour
{
    public int playerLives = 10;
    public TextMeshProUGUI livesText;

    void Start()
    {
        livesText.text = "Lives: " + playerLives.ToString();
    }

    private void Update()
    {
        livesText.text = "Lives: " + playerLives.ToString();
        if (playerLives <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
