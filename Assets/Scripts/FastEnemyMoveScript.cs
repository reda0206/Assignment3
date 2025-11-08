using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyMoveScript : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float health = 60f;
    public float destroyingCooldown = 0.75f;
    public float damageToTower = 10f;
    private float originalMoveSpeed;
    private bool isStopped = false;
    public float lastDestroyingTime = -Mathf.Infinity;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalMoveSpeed = moveSpeed;
    }


    void Update()
    {
        if (!isStopped)
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CannonBall"))
        {
            health -= 8f;
            Debug.Log("-8 Health!");
            Destroy(collision.gameObject);
            if (health <= 0f)
            {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Tower"))
        {
            isStopped = true;
            moveSpeed = 0f;
            lastDestroyingTime = Time.time - destroyingCooldown;
        }

        else if (collision.gameObject.CompareTag("House"))
        {
            var house = collision.gameObject.GetComponent<LoseLivesScript>();
            if (house != null)
            {
                house.playerLives -= 1;
                Debug.Log("-1 Life!");
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Tower")) return;
        {
            if (Time.time - lastDestroyingTime >= destroyingCooldown)
            {
                var tower = collision.gameObject.GetComponent<TowerScript>();
                if (tower != null)
                {
                    tower.health -= damageToTower;
                    Debug.Log($"- {damageToTower} Tower Health!");
                    if (tower.health <= 0f)
                    {
                        Destroy(collision.gameObject);
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            isStopped = false;
            moveSpeed = originalMoveSpeed;
        }
    }
}
