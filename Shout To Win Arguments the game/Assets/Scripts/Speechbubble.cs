using UnityEngine;
using TMPro;
using System;

public class Speechbubble : MonoBehaviour
{
    public GameObject[] bubbles;
    public GameObject choises;

    public TMP_Text bubbleText;

    public void ChooceBubble()
    {
        //Disable other bubbles
        foreach (GameObject bub in bubbles) 
        {
            if (bub != this.gameObject) 
            {
                bub.SetActive(false);
            }
        }

        //Open choises
        choises.SetActive(true);

    }

    public void ChooseResponse(int choise)
    {
        choises.SetActive(false);

        //use int choise to choose response
        //1=agree, 2=disagree, 3=angry?
    }
}
