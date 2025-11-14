using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallGoRightScript : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(0.05f, 0f, 0f);
    }
}
