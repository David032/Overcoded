using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameInput : MonoBehaviour
{

    private string initials = "";
    private GameObject nextButton;
    private GameObject backButton;
    public char[] alphabet = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
    int index = 0;



    private void Update()
    {
        
            char currentLetter = alphabet[index];

            if (Input.GetMouseButtonDown(0) && GameObject.Find("nextButton"))
            {
                if (index < 26)
                {
                    index++;
                }
                else
                {
                    index = 26;
                }
            }

            if (Input.GetMouseButtonDown(0) && GameObject.Find("backButton"))
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
}
