using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerUtilities : MonoBehaviour
{
    float screenWidth;
    float screenHeight;
    public float getWidth() { return screenWidth; }
    public float getHeight() { return screenHeight; }

    public Sprite completedCode;
    public Sprite completedAudio;
    public Sprite completedDesign;
    public Sprite completedArt;

    public bool amInGame() 
    {
        if (SceneManager.GetActiveScene().handle == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Start()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }

}
