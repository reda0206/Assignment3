using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCannonScript : MonoBehaviour
{
    public GameObject iceCannonBallPrefab;
    public float shootCooldown = 1f;
    private float lastShootTime = -Mathf.Infinity;


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
        GameObject cannonBall = Instantiate(iceCannonBallPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = cannonBall.GetComponent<Rigidbody2D>();
    }
}
