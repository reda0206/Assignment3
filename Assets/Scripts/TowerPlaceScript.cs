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

    public Image cannonImage;
    public Image iceCannonImage;
    public Image wallImage;

    private void Update()
    {
        if (isCannon == true)
        {
            cannonImage.color = Color.green;
            iceCannonImage.color = Color.white;
            wallImage.color = Color.white;

            cannonImage.transform.position = Input.mousePosition;
        }
        else if (isIceCannon == true)
        {
            cannonImage.color = Color.white;
            iceCannonImage.color = Color.green;
            wallImage.color = Color.white;

            iceCannonImage.transform.position = Input.mousePosition;
        }
        else if (isWall == true)
        {
            cannonImage.color = Color.white;
            iceCannonImage.color = Color.white;
            wallImage.color = Color.green;

            wallImage.transform.position = Input.mousePosition;
        }
    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lawn"))
        {
            {
                if (collision.gameObject.GetComponent<LawnScript>().isOccupied == false)
                {
                    if (isCannon == true)
                    {
                        Instantiate(cannonPrefab, collision.transform.position, Quaternion.identity);
                        collision.gameObject.GetComponent<LawnScript>().isOccupied = true;
                    }
                    else if (isIceCannon == true)
                    {
                        Instantiate(iceCannonPrefab, collision.transform.position, Quaternion.identity);
                        collision.gameObject.GetComponent<LawnScript>().isOccupied = true;
                    }
                    else if (isWall == true)
                    {
                        Instantiate(wallPrefab, collision.transform.position, Quaternion.identity);
                        collision.gameObject.GetComponent<LawnScript>().isOccupied = true;
                    }
                }
            }
        }
    }
}
