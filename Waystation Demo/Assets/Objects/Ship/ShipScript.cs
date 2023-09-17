using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public string ShipType;
    public float Sspeed;
    public Vector3 destination;
    public Vector3 entrance;
    private bool ready;
    public bool docked;
    public bool release;

    void Start()
    {
        ready = false;
        docked = false;
        release = false;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ready && !docked)
        {
            entrance = GameObject.Find("DockEntr").transform.position;
            Debug.Log("Ship in transit...");
            transform.position = Vector2.MoveTowards(this.transform.position, entrance, (Sspeed * 1.5f) * Time.deltaTime);
            if (transform.position == entrance)
            {
                ready = true;
            }
        }

        if (ready && !docked)
        {
            destination = GameObject.Find("shipDest").transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, destination, Sspeed * Time.deltaTime);
            if (transform.position == destination)
            {
                docked = true;
                Debug.Log("ship docked at station");
                return;
            }
        }

        if (docked & !release)
        {
            destination = GameObject.Find("shipDest").transform.position;
            transform.position = destination;
        }
    }

    private void AnchorShip()
    {
        Debug.Log("Anchor activated");
        Transform Anchor;
        Anchor = GameObject.FindGameObjectWithTag("Anchor").transform;
        gameObject.transform.position = Anchor.position;
        gameObject.transform.localScale = Anchor.localScale;
        Debug.Log("Anchor is " + Anchor.name + ". Scale = " + Anchor.localScale);
    }
}
