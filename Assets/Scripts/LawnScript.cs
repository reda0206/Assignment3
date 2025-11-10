using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnScript : MonoBehaviour
{
    public bool isOccupied = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            isOccupied = true;
        }
    }
}
