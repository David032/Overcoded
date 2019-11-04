using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float FeatureTime = 20; //How long between feature generations?

    FeatureGeneration generationSystem;
    bool generating;

    void Start()
    {
        generationSystem = GetComponent<FeatureGeneration>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && !generating)
        {
            StartCoroutine(EventTimer());
            generating = true;
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
}
