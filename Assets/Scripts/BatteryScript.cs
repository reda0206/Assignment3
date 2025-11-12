using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BatteryScript : MonoBehaviour
{
    public float timer = 15f;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            GameManager.Instance.energy += 20f;
            timer = 15f;
        }
    }
}
