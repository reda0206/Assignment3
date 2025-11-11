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
    private Rigidbody2D rb;
    private Coroutine destroying;
    private Color originalColor;
    private Color slowedColor = Color.cyan;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalMoveSpeed = moveSpeed;
        originalColor = GetComponent<SpriteRenderer>().color;
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
        else if (collision.gameObject.CompareTag("IceCannonBall"))
        {
            StartCoroutine(SlowDown());
            Debug.Log("Enemy Slowed!");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Tower"))
        {
            isStopped = true;
            moveSpeed = 0f;
            
            if (destroying == null)
            {
                var tower = collision.gameObject.GetComponent<TowerScript>();
                destroying = StartCoroutine(DestroyTower(tower));
            }
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            isStopped = false;
            moveSpeed = originalMoveSpeed;
        }
    }

    private IEnumerator DestroyTower(TowerScript tower)
    {
        if (tower == null) yield break;

        LawnScript lawn = tower.lawnTile;
        if (lawn == null) yield break;

        while (tower != null)
        {
            tower.health -= damageToTower;
            Debug.Log("-10 Tower Health!");

            if (tower.health <= 0f)
            {
                Destroy(tower.gameObject);
                lawn.isOccupied = false;
                break;
            }

            yield return new WaitForSeconds(destroyingCooldown);
        }

        destroying = null;
        isStopped = false;
        moveSpeed = originalMoveSpeed;
    }

    private IEnumerator SlowDown()
    {
        moveSpeed = 4f;
        GetComponent<SpriteRenderer>().color = slowedColor;
        yield return new WaitForSeconds(5f);
        moveSpeed = originalMoveSpeed;
        GetComponent<SpriteRenderer>().color = originalColor;
    }
}
