using UnityEngine;

public class HelpScreen : MonoBehaviour
{
    private GameObject helpScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        helpScreen = GameObject.Find("HelpScreen");
        helpScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ShowHelp()
    {
        helpScreen.SetActive(true);
    }

    public void CloseHelp()
    {
        helpScreen.SetActive(false);
    }
}
