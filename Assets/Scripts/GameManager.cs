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

    private bool isCannon = false;
    private bool isIceCannon = false;
    private bool isWall = false;

    public GameObject cannonPrefab;
    public GameObject iceCannonPrefab;
    public GameObject wallPrefab;

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

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Lawn"))
            {
                LawnScript lawn = hit.collider.GetComponent<LawnScript>();
                if (!lawn.isOccupied)
                {
                    if (isCannon)
                    {
                        GameObject newTower = Instantiate(cannonPrefab, hit.collider.transform.position, Quaternion.identity);
                        TowerScript towerScript = newTower.GetComponent<TowerScript>();
                        towerScript.lawnTile = hit.collider.GetComponent<LawnScript>();
                        isCannon = false;
                    }
                    else if (isIceCannon)
                    {
                        Instantiate(iceCannonPrefab, hit.collider.transform.position, Quaternion.identity);
                        lawn.isOccupied = true;
                        isIceCannon = false;
                    }
                    else if (isWall)
                    {
                        Instantiate(wallPrefab, hit.collider.transform.position, Quaternion.identity);
                        lawn.isOccupied = true;
                        isWall = false;
                    }
                }
            }
        }
    }

    public void CannonButton()
    {
        isCannon = true;
        isIceCannon = false;
        isWall = false;

    }

    public void IceCannonButton()
    {
        isCannon = false;
        isIceCannon = true;
        isWall = false;
    }

    public void WallButton()
    {
        isCannon = false;
        isIceCannon = false;
        isWall = true;
    }
}
