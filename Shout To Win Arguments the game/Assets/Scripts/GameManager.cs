using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public int questionAmount = 3;
    //string[] questions;
    //public TMP_Text[] bubbles;
    //TMP_Text[] closedBubbles;
    

    //array with each person
    public Speechbubble[] characters;
    Speechbubble[] activeCharacters;
    int nextCharacter = 0;
    int freeInActive;

    Speechbubble currentBubble;

    public GameObject choises;

    public TypingInput typing;

    int score = 0;
    public TMP_Text scoreT;

    private GameObject win;

    int level = 1;

    private void Start()
    {
        win = GameObject.Find("Win");
        win.SetActive(false);

        activeCharacters = new Speechbubble[questionAmount];
        //start with first 3 characters
        //ask each character to choose a question
        for(int i = 0;i < questionAmount; i++)
        {
            characters[i].gameObject.SetActive(true);
            characters[i].AskQuestion(level, 0);
            activeCharacters[i] = characters[i];
        }
        nextCharacter = questionAmount;
        if (nextCharacter >= characters.Length) 
        {
            nextCharacter = 0;
            if (level < 3)
            {
                //level++;
            }
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    public void AskNextQuestion()
    {
        while (true)
        {
            if (characters[nextCharacter] == activeCharacters[0] || characters[nextCharacter] == activeCharacters[1] || characters[nextCharacter] == activeCharacters[2])
            {
                nextCharacter++;
                if (nextCharacter >= characters.Length)
                {
                    nextCharacter = 0;
                }
            }
            else
            {
                break;
            }
        }

        characters[nextCharacter].gameObject.SetActive(true);
        characters[nextCharacter].AskQuestion(level);
        activeCharacters[freeInActive] = characters[nextCharacter];

        nextCharacter++;
        if(nextCharacter >= characters.Length)
        {
            nextCharacter = 0;
            if (level < 3)
            {
                //level++;
            }
        }
    }

    public void SetCurrentBubble(Speechbubble bub)
    {
        currentBubble = bub;
        choises.SetActive(true);

        foreach (Speechbubble b in characters)
        {
            if (b != bub)
            {
                b.gameObject.SetActive(false);
            }
        }
    }

    public void OnChoiseClick(int c)
    {
        var response = currentBubble.ChooseResponse(c);
        Debug.Log(response.Item1 + ": " + response.Item2);
        typing.StartTyping(response.Item1, response.Item2);
        choises.SetActive(false);
    }

    public void OnTypingEnd(int s)
    {
        score += s;
        scoreT.text = score.ToString() + "/7";
        if(score >= 7)
        {
            win.SetActive(true);
        }

        for (int i = 0; i < activeCharacters.Length; i++) { 
            if(activeCharacters[i] == currentBubble)
            {
                freeInActive = i;
                activeCharacters[i] = null;
                break;
            }
        }

        currentBubble.SetUsable();
        currentBubble.gameObject.SetActive(false);

        AskNextQuestion();

        foreach(Speechbubble b in activeCharacters)
        {
            b.gameObject.SetActive(true);
        }
    }
}
