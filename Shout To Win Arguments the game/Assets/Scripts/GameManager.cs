using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public int questionAmount = 3;
    string[] questions;
    public TMP_Text[] bubbles;
    TMP_Text[] closedBubbles;
    

    //array with each person
    public GameObject[] characters;
    int nextCharacter = 0;

    private void Start()
    {
        /*
        //choose starting questions
        questions = new string[questionAmount];

        for(int i = 0; i < questions.Length; i++)
        {
            //choose random question?
            string q = "No myö sanon notta meijän pittääs palata markkaan, että!";
            questions[i] = q;
            // ^temp^
        }

        //set starting questions
        //set bubbles active
        int t = 0;

        foreach (TMP_Text bub in bubbles)
        {
            bub.text = questions[t];
            bub.gameObject.SetActive(true);
            t++;
            if (t == questions.Length)
            {
                break;
            }
        }*/

        //
        //start with first 3 characters
        //ask each character to choose a question
        for(int i = 0;i < questionAmount; i++)
        {
            //characters[i].AskQuestion();
        }
        nextCharacter = questionAmount;

    }

    private void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {
            Application.Quit();
        }
    }

    public string[] ChangeQuestions(string[] newQs)
    {
        int i = 0;
        foreach (TMP_Text bub in closedBubbles)
        {
            bub.text = newQs[i];
            bub.gameObject.SetActive(true);
            i++;
            if(i == newQs.Length)
            {
                string[] emptyArray = new string[0];
                return emptyArray;
            }
        }
        string[] leftovers = new string[newQs.Length - i];
        for (int j = i; j < newQs.Length; j++) {
            leftovers[j] = newQs[j];
        }
        return leftovers;
    }

    public void AskNextQuestion()
    {
        //characters[nextCharacter].AskQuestion();
        nextCharacter++;
        if(nextCharacter >= characters.Length)
        {
            nextCharacter = 0;
        }
    }
}
