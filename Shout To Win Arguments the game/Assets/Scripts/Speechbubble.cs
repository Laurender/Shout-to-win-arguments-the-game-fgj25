using UnityEngine;
using TMPro;
using System;

public class Speechbubble : MonoBehaviour
{
    public GameObject[] bubbles;
    //public GameObject choises;

    public TMP_Text bubbleText;

    public string character = "test";
    public BubblesReader bRead;
    Bubble nextBub;
    public GameManager gm;
    bool active = true;

    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChooceBubble()
    {
        if (active)
        {
            gm.SetCurrentBubble(this);
            active = false;
        }
    }

    public string ChooseResponse(int choise)
    {
        //use int choise to choose response
        //1=agree, 2=disagree, 3=angry?
        string response = null;
        switch (choise) 
        { 
            case 1:
                response = nextBub.answers.like;
                break;
            case 2:
                response = nextBub.answers.dislike;
                break;
            case 3:
                response = nextBub.answers.hate;
                break;
        }

        return response;
    }

    public void AskQuestion(int l)
    {
        nextBub = bRead.getNextBubble(character, l);
        bubbleText.text = nextBub.phrase;

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void SetUsable()
    {
        active = true;
    }
}
