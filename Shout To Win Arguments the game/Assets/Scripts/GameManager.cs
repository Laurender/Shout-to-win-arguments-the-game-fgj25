using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public int questionAmount = 6;
    string[] questions;
    public TMP_Text[] bubbles;
    TMP_Text[] closedBubbles;
    private void Start()
    {
        //choose starting questions
        questions = new string[questionAmount];

        for(int i = 0; i < questions.Length; i++)
        {
            //choose random question?
            string q = "No my� sanon notta meij�n pitt��s palata markkaan, ett�!";
            questions[i] = q;
            // ^temp^
        }

        //set starting questions
        //set bubbles active
        int t = 0;

        foreach (TMP_Text bub in bubbles) {
            bub.text = questions[t];
            bub.gameObject.SetActive(true);
            t++;
            if (t == questions.Length) 
            {
                break;
            }
        }

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
}
