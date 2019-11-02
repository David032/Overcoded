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
        ObjectType InsertedObject = other.gameObject.GetComponent<PlayerController>().GetResourceType();
        if (InsertedObject != ObjectType.NO_RESOURCE)
        {

            foreach (Feature var in managerGenerator.Features)
            {
                if (InsertedObject == var.R1 && !var.R1Complete)
                {
                    var.score += other.gameObject.GetComponent<PlayerController>().GetResourceProgress();
                    ChangeSprite(InsertedObject, var, 0);
                    var.R1Complete = true;
                    print("Matched slot 1");
                }
                else if (InsertedObject == var.R2 && !var.R2Complete)
                {
                    var.score += other.gameObject.GetComponent<PlayerController>().GetResourceProgress();
                    ChangeSprite(InsertedObject, var, 1);
                    var.R2Complete = true;
                    print("Matched slot 2");
                }
                else if (InsertedObject == var.R3 && !var.R3Complete)
                {
                    var.score += other.gameObject.GetComponent<PlayerController>().GetResourceProgress();
                    ChangeSprite(InsertedObject, var, 2);
                    var.R3Complete = true;
                    print("Matched slot 3");
                }
                else if (InsertedObject == var.R4 && !var.R4Complete)
                {
                    var.score += other.gameObject.GetComponent<PlayerController>().GetResourceProgress();
                    ChangeSprite(InsertedObject, var, 3);
                    var.R4Complete = true;
                    print("Matched slot 4");
                }
                else
                {
                    print("No match!");
                }
            }

            //PlaceHeldObject must hapen ater all information has been colected as it resets all values
            other.gameObject.GetComponent<PlayerController>().PlaceHeldObject();
            //Play animation, or if we run out of time, particle effect over it & pipeline
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
                var.linkedWindow.GetComponent<PopUpUI>().resource[spotNum].GetComponent<SpriteRenderer>().sprite = completedCode;
                break;
            case ObjectType.PROCESSED_AUDIO:
                var.linkedWindow.GetComponent<PopUpUI>().resource[spotNum].GetComponent<SpriteRenderer>().sprite = completedAudio;
                break;
            case ObjectType.PROCESSED_CONCEPTS:
                var.linkedWindow.GetComponent<PopUpUI>().resource[spotNum].GetComponent<SpriteRenderer>().sprite = completedDesign;
                break;
            default:
                break;
        }
    }
}
