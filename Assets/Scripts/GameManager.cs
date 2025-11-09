using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float timer = 600f;
    public TextMeshProUGUI timerText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        timerText.text = "Time Left: " + Mathf.CeilToInt(timer).ToString() + "s";
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "Time Left: " + Mathf.CeilToInt(timer).ToString() + "s";
        if (timer <= 0)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
