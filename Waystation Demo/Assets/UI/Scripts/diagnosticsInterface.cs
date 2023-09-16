using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diagnosticsInterface : MonoBehaviour
{
    //UI text
    private TMPro.TextMeshProUGUI MenuTextmPRO;
    private Text MenuText;
    private string[] TextPrint;
    public GameObject[] MenuTextBoxes;
    public int iter;
    public int iterM;
    private string textToPrint;

    void Awake()
    {
        MenuTextBoxes = new GameObject[6] { GameObject.Find("HullIntegText"), GameObject.Find("HullCorrosnText"), GameObject.Find("IntrnCrcText"), GameObject.Find("BallastTnkText"), GameObject.Find("CommsTnedText"), GameObject.Find("ShpDisnfectText") };
        gameObject.SetActive(false);
        iter = -1;
        iterM = -1;
        TextPrint = new string[6];
    }

    void Update()
    {
        //MenuText = gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        //MenuText.text = (text);
    }

    private void MenuTextGet(string text)
    {
        iter++;
        TextPrint[iter] = text;

        if (iter >= 5)
        {
            foreach (string stat in TextPrint)
            {
                iterM++;
                if (MenuTextBoxes[iterM].GetComponent<TMPro.TextMeshProUGUI>())
                {
                    MenuTextmPRO = MenuTextBoxes[iterM].GetComponent<TMPro.TextMeshProUGUI>();
                    MenuTextmPRO.text = stat;
                }
                else if (MenuTextBoxes[iterM].GetComponent<Text>())
                {
                    MenuText = MenuTextBoxes[iterM].GetComponent<Text>();
                    MenuText.text = stat;
                }
            }
            
        }
    }
}
