using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonPress : MonoBehaviour
{
    public AudioClip menu_move;
    public AudioSource audio_source;

    bool move = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        move = Input.GetButtonDown("P1Vertical");
        PlaySound();
    }

    private void PlaySound()
    {
        audio_source.clip = menu_move;
        audio_source.Play();
    }
}
