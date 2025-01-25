using UnityEngine;
using TMPro;
using System;

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

    int level = 1;

    private void Start()
    {
        activeCharacters = new Speechbubble[questionAmount];
        //start with first 3 characters
        //ask each character to choose a question
        for(int i = 0;i < questionAmount; i++)
        {
            characters[i].gameObject.SetActive(true);
            characters[i].AskQuestion(level);
            activeCharacters[i] = characters[i];
        }
        nextCharacter = questionAmount;
        if (nextCharacter >= characters.Length) 
        {
            nextCharacter = 0;
            if (level < 3)
            {
                level++;
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

        characters[nextCharacter].gameObject.SetActive(true);
        characters[nextCharacter].AskQuestion(level);
        activeCharacters[freeInActive] = characters[nextCharacter];

        nextCharacter++;
        if(nextCharacter >= characters.Length)
        {
            nextCharacter = 0;
            if (level < 3)
            {
                level++;
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
        string response = currentBubble.ChooseResponse(c);
        typing.StartTyping(response);
        choises.SetActive(false);
    }

    public void OnTypingEnd()
    {
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
