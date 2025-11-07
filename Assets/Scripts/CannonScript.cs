using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public GameObject cannonBallPrefab;
    public float health = 100f;
    public float shootCooldown = 1f;
    private float lastShootTime = -Mathf.Infinity;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Time.time - lastShootTime >= shootCooldown)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    void Shoot()
    {
        GameObject cannonBall = Instantiate(cannonBallPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = cannonBall.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10f;
            Debug.Log("-10 Health!");
            if (health <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
