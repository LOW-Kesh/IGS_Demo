using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiagnosticsButtonScrp : MonoBehaviour
{
    //data from ship in dock
    private shipInBayManager Bay;
    private StatManager statManager;
    public float[] ShipValuesFlt;
    public float dockedHullinteg;
    public float dockedHullCorsn;
    public float dockedIntrnCirct;
    public bool[] ShipValuesBl;
    public bool dockedBallastTnk;
    public bool dockedCommsTuned;
    public bool dockedShipDisnfct;

    //Text about repair
    private string RepairLevel;
    public GameObject DiagnosticsInterface;
    public GameObject RepairButtonUI;

    //Buttons on repair menu
    private float SliderValue;
    private Slider[] RepairSliders;
    private float[] SliderStatic;
    private bool ToggleValue;
    private Toggle[] RepairToggles;
    private bool[] ToggleStatic;
    private int iterS;
    private int iterT;
    private bool StatDefaultOn;


    void Awake()
    {
        Bay = gameObject.GetComponent<shipInBayManager>();
        DiagnosticsInterface = GameObject.Find("DiagnosticsMenu");
        RepairButtonUI = GameObject.Find("RepairButtons");
        RepairSliders = new Slider[3] { GameObject.Find("HISlider").GetComponent<Slider>(), GameObject.Find("HCSlider").GetComponent<Slider>(), GameObject.Find("ICSlider").GetComponent<Slider>()};
        SliderStatic = new float[3]; 
        RepairToggles = new Toggle[3] { GameObject.Find("BTToggle").GetComponent<Toggle>(), GameObject.Find("CAToggle").GetComponent<Toggle>(), GameObject.Find("SDToggle").GetComponent<Toggle>()};
        ToggleStatic = new bool[3];
        iterS = -1;
        iterT = -1;
        StatDefaultOn = false;
    }
    void FixedUpdate()
    {
        //Sets the randomlly generated value of the ship as the minimum so te player cannot weaken it in the repair bay.
        int iterS = 0;
        int iterT = 0;
        if (StatDefaultOn)
        {
            foreach (Slider slider in RepairSliders)
            {
                if (slider.value < SliderStatic[iterS])
                {
                    slider.value = SliderStatic[iterS];
                }
                iterS++;
            }

            foreach (Toggle toggle in RepairToggles)
            {
                if (ToggleStatic[iterT])
                {
                    toggle.isOn = true;
                }
                iterT++;
            }
        }
    }

    public void RunDiagnositcCheck()
    {
        DiagnosticsInterface.SetActive(true);
        RepairButtonUI.SetActive(true);

        statManager = Bay.shipInBay.GetComponentInChildren<StatManager>();
        dockedHullinteg = statManager.HullInteg;
        dockedHullCorsn = statManager.HullCorosn;
        dockedIntrnCirct = statManager.IntrnCirct;
        dockedBallastTnk = statManager.BallastTnk;
        dockedCommsTuned = statManager.CommsTuned;
        dockedShipDisnfct = statManager.ShipDisinfect;

        //arrays holding the stats from the ship
        ShipValuesFlt = new float[] 
            {statManager.HullInteg, statManager.HullCorosn, statManager.IntrnCirct};
        ShipValuesBl = new bool[]
            {statManager.BallastTnk, statManager.CommsTuned, statManager.ShipDisinfect};

        foreach (float value in ShipValuesFlt)
        {
            iterS++;
            RepairCalcFloat(value);
            DiagnosticsInterface.BroadcastMessage("MenuTextGet", RepairLevel);
            RepairSliders[iterS].value = value;
            SliderStatic[iterS] = value;
        }

        foreach (bool value in ShipValuesBl)
        {
            iterT++;
            RepairCalcBool(value);
            DiagnosticsInterface.BroadcastMessage("MenuTextGet", RepairLevel);
            RepairToggles[iterT].isOn = value;
            ToggleStatic[iterT] = value;
        }
        StatDefaultOn = true;
    }

    private void RepairCalcFloat(float value)
    {
        switch (value)
        {
            case 1:
                RepairLevel = new string("Level 4 Repairs Needed");
                break;

            case 2:
                RepairLevel = new string("Level 3 Repairs Needed");
                break;

            case 3:
                RepairLevel = new string("Level 2 Repairs Needed");
                break;

            case 4:
                RepairLevel = new string("Level 1 Repairs Needed");
                break;

            case 5:
                RepairLevel = new string("No Repairs Needed");
                break;

            default:
                RepairLevel = new string("Diagnostic Error");
                break;
        }
    }

    private void RepairCalcBool(bool value)
    {
        switch (value)
        {
            case true:
                RepairLevel = new string("At Standard");
                break;

            case false:
                RepairLevel = new string("Requires Maintenance");
                break;
        }
    }

    public void CommitRepairs()
    {
        Debug.Log("Repairs Commited to");
        int iterS = 0;
        int iterT = 0;
        foreach (Slider slider in RepairSliders)
        {
            ShipValuesFlt[iterS] = slider.value;
            SliderStatic[iterS] = slider.value;
            iterS++;
        }

        foreach (Toggle toggle in RepairToggles)
        {
            ShipValuesBl[iterT] = toggle.isOn;
            ToggleStatic[iterT] = toggle.isOn;
            iterT++;
        }
        statManager.BroadcastMessage("ResetStats"); 
    }
}
