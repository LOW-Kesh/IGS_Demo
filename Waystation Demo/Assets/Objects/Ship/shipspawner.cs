using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipspawner : MonoBehaviour
{
    //Anchor
    private GameObject[] Ships;

    //ship intialization
    public GameObject ShipPreFab;
    public SpriteRenderer Shipskin;
    private int skinNum;

    public Sprite ShipBody1;
    public Sprite ShipBody2;
    public Sprite ShipBody3;

    private string[] ShipType;

    //ship release
    public bool leave;
    public bool ready;

    void Awake()
    {
        //anchoring ship to dock on load
        Ships = GameObject.FindGameObjectsWithTag("Ships");
        foreach (GameObject ship in Ships)
        {
            if (ship.GetComponent<ShipScript>().docked)
            {
                ship.BroadcastMessage("AnchorShip");
            }
        }
    }

    void Update()
    {
        if (leave)
        {
            float Sspeed = 2f;
            Vector3 entrance = GameObject.Find("DockEntr").transform.position;
            Vector3 Exit = new Vector3(-15, 0.7f, 0);

            
            foreach (GameObject ship in Ships)
            {
                if (!ready)
                {
                    Debug.Log("stage 1 release");
                    ship.GetComponent<SpriteRenderer>().flipX = true;
                    ship.GetComponent<ShipScript>().release = true;
                    ship.transform.position = Vector2.MoveTowards(ship.transform.position, entrance, Sspeed * Time.deltaTime);
                    if (ship.transform.position == entrance)
                    {
                        ready = true;
                    }
                }

                if (ready)
                {
                    Debug.Log("stage 2 release");
                    ship.transform.position = Vector2.MoveTowards(ship.transform.position, Exit, (Sspeed * 1.5f) * Time.deltaTime);
                }
                if (ship.transform.position == Exit)
                {
                    Debug.Log("stage 3 release");
                    Destroy(ship.gameObject);
                    leave = false;
                }
            }
        }
    }

    public void SpawnShip()
    {
        //ship type generator
        ShipType = new string[5]
            {"Hauler","Civillian","Scientific","Mining","Military"};
        int typeNum = Random.Range(0, ShipType.Length);
        ShipPreFab.GetComponent<ShipScript>().ShipType = ShipType[typeNum];

        //list of skins for body
        Sprite[] ShipBodySkins = new Sprite[3]
        {
        ShipBody1 = Resources.Load<Sprite>("ShipGen/shipBody1"),
        ShipBody2 = Resources.Load<Sprite>("ShipGen/shipBody2"),
        ShipBody3 = Resources.Load<Sprite>("ShipGen/shipBody3")
        };

        //Retrieves Sprite Renderer  and randomly chooses a body from the list
        Shipskin = ShipPreFab.GetComponent<SpriteRenderer>();
        skinNum = Random.Range(0, ShipBodySkins.Length);
        Shipskin.sprite = ShipBodySkins[skinNum];

        //spawns ship
        Instantiate(ShipPreFab, transform.position + new Vector3(0,0,10), Quaternion.identity);

    }
    public void ReleaseShip()
    {
        leave = true;
        ready = false;
        Ships = GameObject.FindGameObjectsWithTag("Ships");
    }
}
