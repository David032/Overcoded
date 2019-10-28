using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorLight : MonoBehaviour
{
    /// <summary>
    /// Small gameplay script that simply turns a gameobject(that has a light) on when the player gets close
    /// </summary>
 
    public GameObject indicatorLight;

    void Start()
    {
        indicatorLight.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        indicatorLight.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        indicatorLight.SetActive(false);
    }
}
