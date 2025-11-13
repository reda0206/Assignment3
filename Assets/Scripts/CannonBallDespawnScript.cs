using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallDespawnScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CannonBall"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("IceCannonBall"))
        {
            Destroy(collision.gameObject);
        }
    }
}
