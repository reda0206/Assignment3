using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlaceScript : MonoBehaviour
{
    public GameObject cannonPrefab;
    public Image cannonIcon;

    void OnMouseDown()
    {
        if (cannonPrefab != null)
        {
            Instantiate(cannonIcon, transform.position, Quaternion.identity);
        }
    }

    private void OnMouseDrag()
    {
        if (cannonIcon != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cannonIcon.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);
        }
    }

    private void OnMouseUp()
    {
        if (cannonIcon != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(cannonPrefab, new Vector3(mousePosition.x, mousePosition.y, 0f), Quaternion.identity);
            Destroy(cannonIcon.gameObject);
        }
    }
}
