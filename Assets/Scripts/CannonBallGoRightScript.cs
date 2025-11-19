using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallGoRightScript : MonoBehaviour
{
    public float speed = 5f;
    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isPaused) return;

        if (Mathf.Approximately(Time.timeScale, 0f)) return;

        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
