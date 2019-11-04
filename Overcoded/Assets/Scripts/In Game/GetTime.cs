using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTime : MonoBehaviour
{
    GameObject manager;
    FeatureGeneration managerGenerator;
    FeatureGeneration generationSystem;




    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController");
        managerGenerator = manager.GetComponent<FeatureGeneration>();
        
    }

    void Update()
    {
        
    }
}
