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

    private Timer timer;

    private string expectedString;

    private bool active;

    public GameManager gm;

    bool correct = false;

    private AudioSource audioSource;
    public AudioSource booAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        writtenText = transform.Find("WrittenText").GetComponent<TMPro.TextMeshProUGUI>();
        expectedText = transform.Find("ExpectedText").GetComponent<TMPro.TextMeshProUGUI>();
        errorAnimator = transform.Find("Error").GetComponent<Animator>();

        timer = FindFirstObjectByType<Timer>();

        //StartTyping("TESTING TESTING");
        active = false;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
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
                    }
                    else
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
    }

    public void SetExpectedString(string expected) {
        writtenText.text = "";
        expectedString = expected;
        expectedText.text = expected;
    }

    public void StartTyping(string expected, bool c)
    {
        SetExpectedString(expected);
        correct = c;
        active = true;
        timer.StartTimer();
    }

    public void Fail()
    {
        Debug.Log("Fail");
        SetExpectedString("");
        active = false;
        errorAnimator.Play("Error", -1, 0f);
        gm.OnTypingEnd(0);
    }

    void Success()
    {
        Debug.Log("Success");
        SetExpectedString("");

        active = false;

        timer.StopTimer();

        if (correct)
        {
            gm.OnTypingEnd(1);

            if (audioSource != null)
            {
                audioSource.Play();
            }
        } else
        {
            gm.OnTypingEnd(0);

            if (booAudio != null)
            {
                booAudio.Play();
            }
        }


        
    }

}
