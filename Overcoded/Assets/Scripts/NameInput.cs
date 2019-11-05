using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInput : MonoBehaviour
{
    public GameObject nextButton;
    public GameObject backButton;
    public bool mouseButtonDown;
    public char[] alphabet = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
    int index = 0;

    public void Start() 
    {

        nextButton = transform.Find("nextButton").gameObject;
        backButton = transform.Find("backButton").gameObject;
    }

    private void Update()
    {
      
        
            char currentLetter = alphabet[index];

            //if (mouseButtonDown == true && transform.Find("nextButton").gameObject)
            //{
            //    if (index < 26)
            //    {
            //        index++;
            //    }
            //    else
            //    {
            //        index = 26;
            //    }
            //}

            //if (mouseButtonDown == true && transform.Find("backButton").gameObject)
            //{
            //    if (index > 0)
            //    {
            //        index--;
            //    }

            //    else
            //    {
            //        index = 0;
            //    }
            //}

            

            GameObject.Find("Letter1").GetComponent<Text>().text = alphabet[index].ToString(); //need to make tgese not repeat across all three scripts (letter1, letter2,letter3)
            //GameObject.Find("Letter2").GetComponent<Text>().text = alphabet[index].ToString();
            //GameObject.Find("Letter3").GetComponent<Text>().text = alphabet[index].ToString();





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


   public void nextButtonPressed()
    {
        if (index < 25)
        {
            index++;
        }
        else
        {
            index = 25;
        }

        //GameObject.Find("Letter1").GetComponent<Text>().text = alphabet[index].ToString();
    }

    public void backButtonPressed()
    {
        if (index > 0)
        {
            index--;
        }

        else
        {
            index = 0;
        }
    }
}


