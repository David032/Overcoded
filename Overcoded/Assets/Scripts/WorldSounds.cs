using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSounds : MonoBehaviour
{
    public AudioSource audio_source;

    public AudioClip Gears;
    public AudioClip gibberish;
    public AudioClip Levelchange;
    public AudioClip Score;

    public void SetNewState(bool music_state)
    {
        audio_source.mute = music_state;
    }

    public void PlayGears ()
    {
        audio_source.clip = Gears;
        audio_source.Play();
    }

    public void Playgibberish()
    {
        audio_source.clip = gibberish;
        audio_source.Play();
    }

    public void PlayLevelChange()
    {
        audio_source.clip = Levelchange;
        audio_source.Play();
    }

    public void PlayScore()
    {
        audio_source.clip = Score;
        audio_source.Play();
    }
}