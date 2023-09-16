using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipInBayManager : MonoBehaviour
{
    public GameObject shipInBay;
    private bool shipPresent;
    private bool f;

    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Ships") == null)
        {
            Debug.Log("No ships in dock");
        }
        else
        {
            shipInBay = GameObject.FindGameObjectWithTag("Ships");
            shipPresent = true;
            f = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shipPresent)
        {
            if ((shipInBay.transform.position != gameObject.transform.position) && f)
            {
                shipInBay.transform.position = gameObject.transform.position;
                shipInBay.BroadcastMessage("AnchorShip");
                f = false;
            }
        }
    }
}
