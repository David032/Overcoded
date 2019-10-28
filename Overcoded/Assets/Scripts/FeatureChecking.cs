using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureChecking : MonoBehaviour
{
    GameObject manager;
    FeatureGeneration managerGenerator;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController");
        managerGenerator = manager.GetComponent<FeatureGeneration>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //ObjectDesc = other.gameobject.getcomponent<ObjectDescription>();
        if (other) //This should check against 'ObjectDescription' component - not yet done
        {
            foreach (Feature var in managerGenerator.Features)
            {
                if (other) //ObjectDesc.resource == var.R1 
                {
                    //var.score += ObjectDesc.Score;
                    //CHANGE ICON FROM PROCESSED TO COMPLETE HERE
                    //var.R1Complete = true
                }
                else if (other) //ObjectDesc.resource == var.R2
                {
                    //var.score += ObjectDesc.Score;
                    //CHANGE ICON FROM PROCESSED TO COMPLETE HERE
                    //var.R2Complete = true
                }
                else if (other) //ObjectDesc.resource == var.R3
                {
                    //var.score += ObjectDesc.Score;
                    //CHANGE ICON FROM PROCESSED TO COMPLETE HERE
                    //var.R3Complete = true
                }
                else if (other) //ObjectDesc.resource == var.R4
                {
                    //var.score += ObjectDesc.Score;
                    //CHANGE ICON FROM PROCESSED TO COMPLETE HERE
                    //var.R4Complete = true
                }
            }
        }
    }

}
