using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlaceScript : MonoBehaviour
{
    private bool isCannon = false;
    private bool isIceCannon = false;
    private bool isWall = false;

    public GameObject cannonPrefab;
    public GameObject iceCannonPrefab;
    public GameObject wallPrefab;

    public void CannonButton()
    {
        isCannon = true;
        isIceCannon = false;
        isWall = false;

    }

    public void IceCannonButton()
    {
        isCannon = false;
        isIceCannon = true;
        isWall = false;
    }

    public void WallButton()
    {
        isCannon = false;
        isIceCannon = false;
        isWall = true;
    }

    private void OnMouseDown()
    {
        if (isCannon == true)
        {
            Instantiate(cannonPrefab, transform.position, Quaternion.identity);
            cannonPrefab.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            isCannon = false;
        }
        else if (isIceCannon == true)
        {
            Instantiate(iceCannonPrefab, transform.position, Quaternion.identity);
            iceCannonPrefab.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            isIceCannon = false;
        }
        else if (isWall == true)
        {
            Instantiate(wallPrefab, transform.position, Quaternion.identity);
            wallPrefab.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            isWall = false;
        }
    }
}
