using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInput : MonoBehaviour
{
    public GameObject nextButton;
    public GameObject backButton;
    public bool mouseButtonDown;
    public char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
    int index1 = 0;
    int index2 = 0;
    int index3 = 0;

    public void Start() 
    {

        nextButton = transform.Find("nextButton").gameObject;
        backButton = transform.Find("backButton").gameObject;
    }

    private void Update()
    {
          
            char currentLetter1 = alphabet[index1];
            char currentLetter2 = alphabet[index2];
            char currentLetter3 = alphabet[index3];


        GameObject manager = GameObject.FindGameObjectWithTag("GameController");
        GameController game = manager.GetComponent<GameController>();
        game.SetPlayerName(currentLetter1.ToString() + currentLetter2.ToString() + currentLetter3.ToString());
    }
    private void OnMouseDown()
    {
        mouseButtonDown = true;
        StartCoroutine(countdown());
    }


    IEnumerator countdown()
    {
        yield return new WaitForSeconds(5);
        mouseButtonDown = false;
    }


   public void nextButton1Pressed()
    {
        if (index1 < 25)
        {
            index1++;
        }
        else
        {
            index1 = 25;
        }

        GameObject.Find("Letter1").GetComponent<Text>().text = alphabet[index1].ToString();
    }

    public void backButton1Pressed()
    {
        if (index1 > 0)
        {
            index1--;
        }

        else
        {
            index1 = 0;
        }

        GameObject.Find("Letter1").GetComponent<Text>().text = alphabet[index1].ToString();
    }

    public void nextButton2Pressed()
    {
        if (index2 < 25)
        {
            index2++;
        }
        else
        {
            index2 = 25;
        }

        GameObject.Find("Letter2").GetComponent<Text>().text = alphabet[index2].ToString();
    }

    public void backButton2Pressed()
    {
        if (index2 > 0)
        {
            index2--;
        }

        else
        {
            index2 = 0;
        }

        GameObject.Find("Letter2").GetComponent<Text>().text = alphabet[index2].ToString();
    }

    public void nextButton3Pressed()
    {
        if (index3 < 25)
        {
            index3++;
        }
        else
        {
            index3 = 25;
        }

        GameObject.Find("Letter3").GetComponent<Text>().text = alphabet[index3].ToString();
    }

    public void backButton3Pressed()
    {
        if (index3 > 0)
        {
            index3--;
        }

        else
        {
            index3 = 0;
        }

        GameObject.Find("Letter3").GetComponent<Text>().text = alphabet[index3].ToString();
    }
}


