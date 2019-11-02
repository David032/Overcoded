using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureChecking : MonoBehaviour
{
    GameObject manager;
    FeatureGeneration managerGenerator;

    Sprite completedArt;
    Sprite completedAudio;
    Sprite completedCode;
    Sprite completedDesign;
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController");
        managerGenerator = manager.GetComponent<FeatureGeneration>();
        completedArt = manager.GetComponent<ManagerUtilities>().completedArt;
        completedAudio = manager.GetComponent<ManagerUtilities>().completedAudio;
        completedCode = manager.GetComponent<ManagerUtilities>().completedCode;
        completedDesign = manager.GetComponent<ManagerUtilities>().completedDesign;
    }
    private void OnTriggerEnter(Collider other)
    {
        ObjectType InsertedObject = other.gameObject.GetComponent<PlayerController>().getResource();
        if (InsertedObject != ObjectType.NO_RESOURCE)
        {
            other.gameObject.GetComponent<PlayerController>().PlaceHeldObject(); //If we can't sort scaling, this may have to sadly be diabled
            //Play animation, or if we run out of time, particle effect over it & pipeline

            foreach (Feature var in managerGenerator.Features)
            {
                if (InsertedObject == var.R1)
                {
                    var.score += other.gameObject.GetComponent<PlayerController>().resourceProgress;
                    ChangeSprite(InsertedObject, var, 0);
                    var.R1Complete = true;
                }
                else if (InsertedObject == var.R2)
                {
                    var.score += other.gameObject.GetComponent<PlayerController>().resourceProgress;
                    ChangeSprite(InsertedObject, var, 1);
                    var.R2Complete = true;
                }
                else if (InsertedObject == var.R3)
                {
                    var.score += other.gameObject.GetComponent<PlayerController>().resourceProgress;
                    ChangeSprite(InsertedObject, var, 2);
                    var.R3Complete = true;
                }
                else if (InsertedObject == var.R4)
                {
                    var.score += other.gameObject.GetComponent<PlayerController>().resourceProgress;
                    ChangeSprite(InsertedObject, var, 3);
                    var.R4Complete = true;
                }
            }
        }
    }

    private void ChangeSprite(ObjectType InsertedObject, Feature var, int spot)
    {
        int spotNum = spot;
        switch (InsertedObject)
        {
            case ObjectType.PROCESSED_SHAPES:
                var.linkedWindow.GetComponent<PopUpUI>().resource[spotNum].GetComponent<SpriteRenderer>().sprite = completedArt;
                break;
            case ObjectType.PROCESSED_CODE:
                var.linkedWindow.GetComponent<PopUpUI>().resource[spotNum].GetComponent<SpriteRenderer>().sprite = completedArt;
                break;
            case ObjectType.PROCESSED_AUDIO:
                var.linkedWindow.GetComponent<PopUpUI>().resource[spotNum].GetComponent<SpriteRenderer>().sprite = completedArt;
                break;
            case ObjectType.PROCESSED_CONCEPTS:
                var.linkedWindow.GetComponent<PopUpUI>().resource[spotNum].GetComponent<SpriteRenderer>().sprite = completedArt;
                break;
            default:
                break;
        }
    }
}
