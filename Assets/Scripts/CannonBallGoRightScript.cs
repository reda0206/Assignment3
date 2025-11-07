using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallGoRightScript : MonoBehaviour
{
    public float lifetime = 3f;
    void Update()
    {
        transform.position += new Vector3(0.025f, 0f, 0f);
        lifetime -= Time.deltaTime;

        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
