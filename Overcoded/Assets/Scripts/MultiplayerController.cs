using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MultiplayerController : MonoBehaviour
{
    public int numberOfPlayers;
    public List<GameObject> players;
    static int MAXPLAYERS = 4;
    public Scene GameLevel;

    bool hasRan = false;

    //This function should called from the menu
    public void setPlayers(int desiredPlayers) 
    {
        numberOfPlayers = desiredPlayers;
    }

    private void LateUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && !hasRan)
        {
            OnSceneLoaded();
        }
    }

    void OnSceneLoaded()
    {
        players.AddRange(new GameObject[1]);
        FindAllPlayers();
        for (int i = 0; i < numberOfPlayers; i++)
        {
            players[i].SetActive(true);
        }
        hasRan = true;
    }

    void FindAllPlayers()
    {
        for (int i = 0; i < MAXPLAYERS; i++)
        {
            players[i] = GameObject.FindGameObjectWithTag("Player");
            players[i].SetActive(false);
            players.AddRange(new GameObject[1]);
        }
    }
}
