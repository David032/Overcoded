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
        timer_text.text = game_min.ToString() + ":" + game_sec.ToString();
    }
}
