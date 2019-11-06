using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float FeatureTime = 20; //How long between feature generations?
    public float GameTime = 135; //time the game lasts for

    FeatureGeneration generationSystem;
    bool generating;

    string playerName;

    bool muted;
    void Start()
    {
        generationSystem = GetComponent<FeatureGeneration>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && !generating)
        {
            StartCoroutine(EventTimer());
            StartCoroutine(GameTimer());
            MuteSceen();
            generating = true;
            playerName = "";
        }
        else if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            generating = false;
        }

    }

    IEnumerator EventTimer() 
    {
        if (!generating) { StopCoroutine(EventTimer()); }
        yield return new WaitForSeconds(FeatureTime);
        generationSystem.createFeature();
        StartCoroutine(EventTimer());
    }

    IEnumerator GameTimer()
    {
        yield return new WaitForSeconds(GameTime);
        SceneManager.LoadScene(3);
    }

    public bool IsMuted()
    {
        return muted;
    }

    public void SetMuted(bool mute)
    {
        muted = mute;
        MuteSceen();
    }

    void MuteSceen()
    {
        var audioSources = FindObjectsOfType<AudioSource>();
        foreach (var item in audioSources)
        {
            item.mute = muted;
        }
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void SetPlayerName(string newName)
    {
        playerName = newName;
    }
}
