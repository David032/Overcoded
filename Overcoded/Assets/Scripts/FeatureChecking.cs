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
        float Progress = other.gameObject.GetComponent<PlayerController>().GetResourceProgress();

        if (InsertedObject != ObjectType.NO_RESOURCE)
        {
            bool componantMatched = false;
            Feature featuer = managerGenerator.Features[0];

            if (InsertedObject == featuer.R1 && !featuer.R1Complete)
            {
                componantMatched = true;
                ChangeSprite(InsertedObject, featuer, 0);
                featuer.R1Complete = true;
                print("Matched slot 1");
            }
            else if (InsertedObject == featuer.R2 && !featuer.R2Complete)
            {
                componantMatched = true;
                ChangeSprite(InsertedObject, featuer, 1);
                featuer.R2Complete = true;
                print("Matched slot 2");
            }
            else if (InsertedObject == featuer.R3 && !featuer.R3Complete)
            {
                componantMatched = true;
                ChangeSprite(InsertedObject, featuer, 2);
                featuer.R3Complete = true;
                print("Matched slot 3");
            }
            else if (InsertedObject == featuer.R4 && !featuer.R4Complete)
            {
                componantMatched = true;
                ChangeSprite(InsertedObject, featuer, 3);
                featuer.R4Complete = true;
                print("Matched slot 4");
            }
            else
            {
                print("No match!");
            }


            if (componantMatched)
            {
                if (Progress < 0.9f)
                {
                    featuer.score += Progress;
                }
                else if (Progress > 1.1f)
                {
                    featuer.score += 2.0f - Progress;
                }
                else
                {
                    //give bonus score for neer perfect timing?
                    featuer.score += 1.25f;
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
                var.getLinkedWindow().GetComponent<PopUpUI>().resource[spotNum].GetComponent<SpriteRenderer>().sprite = completedArt;
                break;
            case ObjectType.PROCESSED_CODE:
                var.getLinkedWindow().GetComponent<PopUpUI>().resource[spotNum].GetComponent<SpriteRenderer>().sprite = completedCode;
                break;
            case ObjectType.PROCESSED_AUDIO:
                var.getLinkedWindow().GetComponent<PopUpUI>().resource[spotNum].GetComponent<SpriteRenderer>().sprite = completedAudio;
                break;
            case ObjectType.PROCESSED_CONCEPTS:
                var.getLinkedWindow().GetComponent<PopUpUI>().resource[spotNum].GetComponent<SpriteRenderer>().sprite = completedDesign;
                break;
            default:
                break;
        }
    }
}
