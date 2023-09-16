using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    //floats
    public float HullInteg;
    public float HullCorosn;
    public float IntrnCirct;
    
    //bools
    public bool BallastTnk;
    public bool CommsTuned;
    public bool ShipDisinfect;


    void Start()
    {
        //Generates values for the ship
        //Float values
        HullInteg = Random.Range(1, 5);
        HullCorosn = Random.Range(1, 5);
        IntrnCirct = Random.Range(1, 5);

        //boolean values
        RandomValueGen(BallastTnk);
        RandomValueGen(CommsTuned);
        RandomValueGen(ShipDisinfect);
    }

    public void RandomValueGen(bool value)
    {
        if ((Random.Range(1, 10)) > 5)
        {
            value = true;
        }
        else if ((Random.Range(1, 10)) < 5)
        {
            value = false;
        }
    }

    public void ResetStats()
    {
        DiagnosticsButtonScrp values = GameObject.Find("ShipInBay").GetComponent<DiagnosticsButtonScrp>();
        
        //float values reset
        HullInteg = values.ShipValuesFlt[0];
        HullCorosn = values.ShipValuesFlt[1];
        IntrnCirct = values.ShipValuesFlt[2];

        //bool values reset
        BallastTnk = values.ShipValuesBl[0];
        CommsTuned =  values.ShipValuesBl[1];
        ShipDisinfect = values.ShipValuesBl[2];
    }
}
