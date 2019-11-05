using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    private GameObject AudioManager;

    private bool music_state;

    private void Start()
    {
        AudioManager = GameObject.FindGameObjectWithTag("GameController");
    }
    public void MusicEnabled()
    {
        AudioManager.GetComponent<GameController>().SetMuted(false);
    }
    public void MusicDisabled()
    {
        AudioManager.GetComponent<GameController>().SetMuted(true);
    }
}
