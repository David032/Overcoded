using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip Pickupitem;
    public AudioClip Placeitemdown;
    public AudioClip footsteps;
    public AudioClip throwinbin;

    public bool isPlaying = false;

    AudioSource player;

    private void Start()
    {
        player = GetComponent<AudioSource>();
    }

    public void PickUp()
    {
        player.clip = Pickupitem;
        player.Play();
    }

    public void PlaceDown()
    {
        player.clip = Placeitemdown;
        player.Play();

    }
    public void Playfootsteps()
    {
        player.clip = footsteps;
        player.pitch = Random.Range(0.75f, 1.25f);
        player.Play();
    }

    public void PlayPickupitem()
    {
        player.clip = Pickupitem;
        player.Play();
    }

    public void PlayPlaceitemdown()
    {
        player.clip = Placeitemdown;
        player.Play();
    }

    public void Playthrowinbin()
    {
        player.clip = throwinbin;
        player.Play();
    }

    public void StopAudio()
    {
        player.Stop();
    }
}