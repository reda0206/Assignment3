using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] spawnPrefabs;
    public float spawnInterval = 50f;
    private float timer;
    public float timer2 = 60f;
    public int difficultyLevel = 1;
    public TextMeshProUGUI prepareText;
    public float prepareTime = 60f;

    private void Start()
    {
        prepareText.text = "Prepare... " + Mathf.CeilToInt(prepareTime).ToString() + "s";
    }

    private void Update()
    {
        timer += Time.deltaTime;
        prepareText.text = "Prepare... " + Mathf.CeilToInt(prepareTime).ToString() + "s";
        prepareTime -= Time.deltaTime;

        if (prepareTime <= 0f)
        {
            prepareText.gameObject.SetActive(false);
        }
        if (timer >= spawnInterval)
        {
            if (spawnInterval == 50f)
            {
                spawnInterval = 10f;
                timer = 0f;
            }
            else
            {
                SpawnEnemy();
                timer = 0f;
            }
        }
        timer2 -= Time.deltaTime;

        if (timer2 <= 0f)
        {
            difficultyLevel += 1;
            timer2 = 60f;

            if (spawnInterval > 3f) 
            {
               spawnInterval -= 1f;
            }
        }
    }

    void SpawnEnemy()
    {
        if (difficultyLevel < 3)
        {
        int enemyIndex = Random.Range(0, 0);
        int spawnIndex = Random.Range(0, spawnPrefabs.Length);
        Instantiate(enemyPrefabs[enemyIndex], spawnPrefabs[spawnIndex].transform.position, Quaternion.identity);
        }
        else if (difficultyLevel < 5)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length - 1);
            int spawnIndex = Random.Range(0, spawnPrefabs.Length);
            Instantiate(enemyPrefabs[enemyIndex], spawnPrefabs[spawnIndex].transform.position, Quaternion.identity);
        }

        else 
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            int spawnIndex = Random.Range(0, spawnPrefabs.Length);
            Instantiate(enemyPrefabs[enemyIndex], spawnPrefabs[spawnIndex].transform.position, Quaternion.identity);
        }
    }
}
