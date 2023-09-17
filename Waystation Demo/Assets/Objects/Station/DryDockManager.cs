using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DryDockManager : MonoBehaviour
{
    public BoxCollider2D dockdetection;
    public bool dockedatstation;
    public GameObject dockedShip;

    //ship stats
    private StatManager statManager;
    public float dockedHullinteg;
    public float dockedHullCorsn;
    public float dockedIntrnCirct;
    public bool dockedBallastTnk;
    public bool dockedCommsTuned;
    public bool dockedShipDisnfct;

    //cargo
    private CargoManager CargoManager;


    //sprite of docked ship
    public Sprite shipSprite;

    void Start()
    {
        dockdetection = GetComponentInChildren<BoxCollider2D>();
        dockedatstation = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Docking sequence intiated...");
        dockedatstation = true;
        dockedShip = collision.gameObject;

        //stats
        Debug.Log("stats retrieved");
        statManager = collision.GetComponentInChildren<StatManager>();
        dockedHullinteg = statManager.HullInteg;
        dockedHullCorsn = statManager.HullCorosn;
        dockedIntrnCirct = statManager.IntrnCirct;
        dockedBallastTnk = statManager.BallastTnk;
        dockedCommsTuned = statManager.CommsTuned;
        dockedShipDisnfct = statManager.ShipDisinfect;

        //retrieving ship sprite to be rendered in drydock
        shipSprite = dockedShip.GetComponent<SpriteRenderer>().sprite;

        int iter = 0;
        CargoManager = collision.GetComponentInChildren<CargoManager>();
        foreach (string cargo in CargoManager.Cargo)
        {
            Debug.Log(CargoManager.CargoQuant[iter] + " of " + cargo);
                iter++;
        }
    }

   /* private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Ship in dock");
    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Ship departing dock...");
    }
}
