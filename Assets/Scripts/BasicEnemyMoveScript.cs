using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMoveScript : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float health = 120f;
    public float destroyingCooldown = 0.75f;
    private float lastDestroyingTime = Mathf.Infinity;
    public bool isDestroying = false;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
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
            StartCoroutine(Destroying());
        }
    }

    private IEnumerator Destroying()
    {
        isDestroying = true;

        while (isDestroying == true);
        {
            moveSpeed = 0f;
            if (Time.time - lastDestroyingTime < destroyingCooldown)
            {
                yield return null;
            }
        }
    }
}
