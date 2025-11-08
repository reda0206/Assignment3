using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] spawnPrefabs;
    public float spawnInterval = 8f;
    private float timer;
    public float timer2 = 60f;
    public int difficultyLevel = 1;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
        timer2 -= Time.deltaTime;
        if (timer2 <= 0f)
        {
            difficultyLevel += 1;
            timer2 = 16f;
            if (spawnInterval > 2f)
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
        else if (difficultyLevel >= 3)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length - 1);
            int spawnIndex = Random.Range(0, spawnPrefabs.Length);
            Instantiate(enemyPrefabs[enemyIndex], spawnPrefabs[spawnIndex].transform.position, Quaternion.identity);
        }

        else if (difficultyLevel >= 6)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            int spawnIndex = Random.Range(0, spawnPrefabs.Length);
            Instantiate(enemyPrefabs[enemyIndex], spawnPrefabs[spawnIndex].transform.position, Quaternion.identity);
        }
    }
}
