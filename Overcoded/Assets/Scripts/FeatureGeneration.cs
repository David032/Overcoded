﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class FeatureGeneration : MonoBehaviour
{
    public float totalScore;
    public Vector3 position;
    public List<Feature> Features;
    public int featureNumber = 0;
    public GameObject popUp;

    WorldSounds audio;

    GameObject eventPosition;
    bool hasRan = false;
    GameObject lastFeature;

    private void Start()
    {
        audio = GetComponent<WorldSounds>();
    }

    public void createFeature() 
    {
        //At most, 6 features should be generated, so if it goes past that, we'll need to delete the oldest one?
        //posable prevent new features at 6
        if (Features.Count >= 6) { return; }

        Feature newFeature = gameObject.AddComponent<Feature>();

        newFeature.CreateFeature(randomFeature(), randomFeature(), randomFeature(), randomFeature());
        if (newFeature.R1 == ObjectType.NO_RESOURCE && newFeature.R2 == ObjectType.NO_RESOURCE
            && newFeature.R3 == ObjectType.NO_RESOURCE && newFeature.R4 == ObjectType.NO_RESOURCE)
        {
            createFeature();
        }
        newFeature.FeatureId = featureNumber;

        Features.Add(newFeature);
        CreateFeatureWindow();

        featureNumber = Features.Count;
        audio.Playgibberish();
    }

    private void CreateFeatureWindow()
    {
        foreach (Feature item in Features)
        {
            item.MoveLinkedWindow();
        }
        Quaternion rot = Quaternion.Euler(90, 0, 0);
        GameObject featureWindow = Instantiate(popUp, position, rot, eventPosition.transform);
        featureWindow.name = "Feature " + featureNumber.ToString();
        featureWindow.GetComponent<PopUpUI>().findTheBoss();
        featureWindow.GetComponent<PopUpUI>().FeatureId = Features[featureNumber].FeatureId;
        featureWindow.GetComponent<PopUpUI>().PopUp(featureNumber);
        Features[featureNumber].setLinkedWindow(featureWindow);
    }

    ObjectType randomFeature() 
    {
        int rndNumber = Random.Range(1, 6);
        ObjectType featureToReturn = ObjectType.NO_RESOURCE;
        if (rndNumber == 1)
        {
            featureToReturn = ObjectType.PROCESSED_AUDIO;
        }
        else if (rndNumber == 2)
        {
            featureToReturn = ObjectType.PROCESSED_CODE;
        }
        else if (rndNumber == 3)
        {
            featureToReturn = ObjectType.PROCESSED_CONCEPTS;
        }
        else if (rndNumber == 4)
        {
            featureToReturn = ObjectType.PROCESSED_SHAPES;
        }
        else if (rndNumber == 5)
        {
            featureToReturn = ObjectType.NO_RESOURCE;
        }

        return featureToReturn;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) //Debug function
        {
            createFeature();
        }

        if (SceneManager.GetActiveScene().buildIndex == 1 && !hasRan) 
        {
            Features = new List<Feature>();

            eventPosition = GameObject.FindGameObjectWithTag("EventHolder");
            createFeature();

            hasRan = true;
        }
    }

    public void deleteFeature(int id) 
    {
        Features[id].DeleteLinkedWindow();
        Features.RemoveAt(id);

        for (int i = 0; i < Features.Count; i++)
        {
            Features[i].FeatureId = i;
        }
        featureNumber = Features.Count;
    }


}
