using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }

}
