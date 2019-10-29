using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerController : MonoBehaviour
{
    public int numberOfPlayers;
    public List<GameObject> players;
    static int MAXPLAYERS = 4;

    //This function should called from the menu
    void setPlayers(int desiredPlayers) 
    {
        numberOfPlayers = desiredPlayers;
    }

    private void Start() // This may need to be changed based on how the menu system is working
    {
        players.AddRange(new GameObject[1]);
        FindAllPlayers();
        for (int i = 0; i < numberOfPlayers; i++)
        {
            players[i].SetActive(true);
        }
    }

    void FindAllPlayers()
    {
        for (int i = 0; i < MAXPLAYERS; i++)
        {
            players[i] = GameObject.FindGameObjectWithTag("Player");
            print("Found player:" + players[i]);
            players[i].SetActive(false);
            players.AddRange(new GameObject[1]);
        }
    }
}
