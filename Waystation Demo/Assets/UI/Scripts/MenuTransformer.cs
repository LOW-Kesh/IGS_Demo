using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTransformer : MonoBehaviour
{
    public string DryDockWindow;
    public string Map;
    public string DialogueManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void DryDockInit()
    {
        SceneManager.LoadScene(DryDockWindow);
    }
    public void MainMenuReturn()
    {
        SceneManager.LoadScene("HomeScreen");
    }
    public void CounterOpen()
    {
        SceneManager.LoadScene(DialogueManager);
    }
}
