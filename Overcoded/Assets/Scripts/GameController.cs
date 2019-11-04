using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float FeatureTime = 20; //How long between feature generations?

    FeatureGeneration generationSystem;

    void Start()
    {
        generationSystem = GetComponent<FeatureGeneration>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 )
        {
            StartCoroutine(EventTimer());
            StopCoroutine(EventTimer());
        }
    }

    IEnumerator EventTimer() 
    {
        yield return new WaitForSeconds(FeatureTime);
        generationSystem.createFeature();
    }
}
