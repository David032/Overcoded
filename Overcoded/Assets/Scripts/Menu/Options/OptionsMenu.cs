using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    private GameObject AudioManager;

    private bool music_state;

    private void Start()
    {
        //AudioManager = GameObject.FindGameObjectWithTag("AudioManager");
    }
    public void MusicEnabled()
    {
        //AudioManager.GetComponent<MenuMusic>().SetNewState(true);
    }
    public void MusicDisabled()
    {
        //AudioManager.GetComponent<MenuMusic>().SetNewState(false);
    }
}
