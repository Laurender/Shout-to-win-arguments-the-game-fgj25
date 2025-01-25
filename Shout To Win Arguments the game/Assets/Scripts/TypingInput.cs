using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using static System.Net.Mime.MediaTypeNames;

public class TypingInput : MonoBehaviour
{
    private TMPro.TextMeshProUGUI writtenText;
    private TMPro.TextMeshProUGUI expectedText;
    private Animator errorAnimator;

    private string expectedString;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        writtenText = transform.Find("WrittenText").GetComponent<TMPro.TextMeshProUGUI>();
        expectedText = transform.Find("ExpectedText").GetComponent<TMPro.TextMeshProUGUI>();
        errorAnimator = transform.Find("Error").GetComponent<Animator>();

        SetExpectedString("TESTING TESTING");
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach (char c in Input.inputString)
        {
            // Do not append line breaks or backspaces
            if ((c != '\b') && (c != '\n') && (c != '\r'))
            {
                // Only append character if it is correct
                if (c == expectedString[writtenText.text.Length + i])
                {
                    writtenText.text += c;
                } else
                {
                    errorAnimator.Play("Error", -1, 0f);
                }

                if (writtenText.text == expectedString)
                {
                    Success();
                }
                
            }
            i++;
        }
    }

    void SetExpectedString(string expected) {
        writtenText.text = "";
        expectedString = expected;
        expectedText.text = expected;
    }

    void Success()
    {
        Debug.Log("Success");
        SetExpectedString("");
    }

}
