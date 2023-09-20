using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class ShipManifest : MonoBehaviour
{
    private TMPro.TextMeshProUGUI ManifestTextBox;
    private GameObject Ship;

    private string ShipClass;
    //private string EngineType;
    private string[] CargoStr;
    private float[] CargoFlt;
    public string[] cargoText;

    [Multiline()]
    public string Text;

    void Awake()
    {
        Ship = GameObject.FindGameObjectWithTag("Ships");
        if (Ship == null)
        {
            Debug.Log("No ships docked");
        }
        else
        {
            ManifestTextBox = gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            CargoStr = Ship.GetComponentInChildren<CargoManager>().Cargo;
            CargoFlt = Ship.GetComponentInChildren<CargoManager>().CargoQuant;
            ShipClass = Ship.GetComponentInChildren<ShipScript>().ShipType;

            //strcuture of text for the textbox
            Text = ("<size=40><b>Ship Manifest: </size></b><br>"
                    + ShipClass + " class ship<br>"
                    + "<br>"
                    + "<b>Registered Cargo:</b><br>"
                    );

            int iter = 0;
            foreach (string cargo in CargoStr)
            {
                string textline = CargoFlt[iter].ToString() + " of " + cargo + "<br>";
                cargoText = new string[CargoStr.Length];
                cargoText[iter] = textline;
                iter++;
            }
            foreach (string stng in cargoText)
            {
                Text = new string(Text + stng);
            }

            ManifestTextBox.text = Text;
        }
    }
}
