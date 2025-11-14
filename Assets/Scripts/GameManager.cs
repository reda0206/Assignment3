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
    public float energy = 40f;
    public float timer2 = 10f;
    public float prepareTime = 65f;
    public TextMeshProUGUI energyText;

    private bool isBattery = false;
    private bool isCannon = false;
    private bool isIceCannon = false;
    private bool isWall = false;

    public GameObject batteryPrefab;
    public GameObject cannonPrefab;
    public GameObject iceCannonPrefab;
    public GameObject wallPrefab;

    public float batteryCost = 40f;
    public float cannonCost = 80f;
    public float iceCannonCost = 100f;
    public float wallCost = 60f;

    public GameObject pauseMenuUi;
    public bool isPaused = false;
    private List<AudioSource> audioSources = new List<AudioSource>();
    public List<AudioSource> excludedAudioSources = new List<AudioSource>();

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
        energyText.text = "Energy: " + Mathf.CeilToInt(energy).ToString();
        timerText.gameObject.SetActive(false);
    }

    private void Update()
    {
        prepareTime -= Time.deltaTime;
        if (prepareTime <= 0)
        {
            timerText.gameObject.SetActive(true);

            timer -= Time.deltaTime;
            timerText.text = "Time Left: " + Mathf.CeilToInt(timer).ToString() + "s";
            if (timer <= 0)
            {
                SceneManager.LoadScene("WinScene");
            }
        }

        timer2 -= Time.deltaTime;
        energyText.text = "Energy: " + Mathf.CeilToInt(energy).ToString();
        if (timer2 <= 0)
        {
            energy += 10f;
            timer2 = 10f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Lawn"))
            {
                LawnScript lawn = hit.collider.GetComponent<LawnScript>();
                if (!lawn.isOccupied)
                {
                    Vector3 spawnPos = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, 0.1f);
                    if (isBattery)
                    {
                        if (energy >= batteryCost)
                        {
                            GameObject newTower = Instantiate(batteryPrefab, spawnPos, Quaternion.identity);
                            TowerScript towerScript = newTower.GetComponent<TowerScript>();
                            towerScript.lawnTile = hit.collider.GetComponent<LawnScript>();
                            lawn.isOccupied = true;
                            energy -= batteryCost;
                            isBattery = false;
                        }
                    }

                    else if (isCannon)
                    {
                        if (energy >= cannonCost)
                        {
                            GameObject newTower = Instantiate(cannonPrefab, spawnPos, Quaternion.identity);
                            TowerScript towerScript = newTower.GetComponent<TowerScript>();
                            towerScript.lawnTile = hit.collider.GetComponent<LawnScript>();
                            lawn.isOccupied = true;
                            energy -= cannonCost;
                            isCannon = false;
                        }
                    }
                    else if (isIceCannon)
                    {
                        if (energy >= iceCannonCost)
                        {
                            GameObject newTower = Instantiate(iceCannonPrefab, spawnPos, Quaternion.identity);
                            TowerScript towerScript = newTower.GetComponent<TowerScript>();
                            towerScript.lawnTile = hit.collider.GetComponent<LawnScript>();
                            lawn.isOccupied = true;
                            energy -= iceCannonCost;
                            isIceCannon = false;
                        }
                    }
                    else if (isWall)
                    {
                        if (energy >= wallCost)
                        {
                            GameObject newTower = Instantiate(wallPrefab, spawnPos, Quaternion.identity);
                            TowerScript towerScript = newTower.GetComponent<TowerScript>();
                            towerScript.lawnTile = hit.collider.GetComponent<LawnScript>();
                            lawn.isOccupied = true;
                            energy -= wallCost;
                            isWall = false;
                        }
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
      

    public void BatteryButton()
    {
        isBattery = true;
        isCannon = false;
        isIceCannon = false;
        isWall = false;
    }

    public void CannonButton()
    {
        isBattery = false;
        isCannon = true;
        isIceCannon = false;
        isWall = false;
    }

    public void IceCannonButton()
    {
        isBattery = false;
        isCannon = false;
        isIceCannon = true;
        isWall = false;
    }

    public void WallButton()
    {
        isBattery = false;
        isCannon = false;
        isIceCannon = false;
        isWall = true;
    }

    public void Pause()
    {
        isPaused = true;
        pauseMenuUi.SetActive(true);
        PauseAudio();
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenuUi.SetActive(false);
        ResumeAudio();
        Time.timeScale = 1f;
    }

    public void PauseAudio()
    {
        foreach (AudioSource audio in FindObjectsOfType<AudioSource>())
        {
            if (!excludedAudioSources.Contains(audio) && audio.isPlaying)
            {
                audio.Pause();
                audioSources.Add(audio);
            }
        }
    }

    public void ResumeAudio()
    {
        for (int i = audioSources.Count - 1; i >= 0; i--)
        {
            if (audioSources[i])
            {
                audioSources[i].UnPause();
                audioSources.RemoveAt(i);
            }
        }
    }

    public void QuitToMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGameButton()
    {
               Application.Quit();
    }
}
