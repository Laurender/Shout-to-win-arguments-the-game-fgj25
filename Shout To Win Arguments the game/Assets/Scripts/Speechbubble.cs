using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

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
    void Awake()
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

    /*public string ChooseResponse(int choise)
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
    }*/

    public (string, bool) ChooseResponse(int choise)
    {
        //use int choise to choose response
        //1=agree, 2=disagree, 3=angry?
        string response = null;
        bool correct = false;
        switch (choise)
        {
            case 1:
                response = nextBub.answers.like;
                correct = "like" == nextBub.correct;
                break;
            case 2:
                response = nextBub.answers.dislike;
                correct = "dislike" == nextBub.correct;
                break;
            case 3:
                response = nextBub.answers.hate;
                correct = "hate" == nextBub.correct;
                break;
        }
        //Debug.Log(correct);



        return (response, correct);
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

    public void AskQuestion(int l, int i)
    {
        nextBub = bRead.getNextBubble(character, l);
        bubbleText.text = nextBub.phrase;

    }

    public void SetUsable()
    {
        active = true;
    }
}
