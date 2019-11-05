using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTime : MonoBehaviour
{
    GameObject manager;
    public Text timer_text;
    float game_time;


    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController");
        game_time = manager.GetComponent<GameController>().GameTime;
    }

    void Update()
    {
        game_time -= Time.deltaTime;
        int game_timer_int = Mathf.CeilToInt(game_time);
        int game_min, game_sec;
        game_min = (game_timer_int / 60);
        game_sec = (game_timer_int % 60);
        string str_min = game_min.ToString();
        string str_sec = game_sec.ToString();

        if (game_sec < 10)
        {
            str_sec = "0" + game_sec;
        }

        timer_text.text = str_min + ":" + str_sec;
    }
}
