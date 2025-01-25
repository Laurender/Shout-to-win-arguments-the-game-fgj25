using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypingInput : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (char c in Input.inputString)
        {
            if ((c != '\b') && (c != '\n') && (c != '\r'))
            {
                text.text += c;
            }
        }
    }
}
