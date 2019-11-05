using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureChecking : MonoBehaviour
{
    GameObject manager;
    FeatureGeneration managerGenerator;

    public WorldSounds Audio;

    Sprite completedArt;
    Sprite completedAudio;
    Sprite completedCode;
    Sprite completedDesign;

    GameObject componentDrop;
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController");
        managerGenerator = manager.GetComponent<FeatureGeneration>();
        completedArt = manager.GetComponent<ManagerUtilities>().completedArt;
        completedAudio = manager.GetComponent<ManagerUtilities>().completedAudio;
        completedCode = manager.GetComponent<ManagerUtilities>().completedCode;
        completedDesign = manager.GetComponent<ManagerUtilities>().completedDesign;
        componentDrop = GameObject.Find("ComponantDrop");
    }
    private void OnTriggerEnter(Collider other)
    {
        ObjectType InsertedObject = other.gameObject.GetComponent<PlayerController>().GetResourceType();
        float Progress = other.gameObject.GetComponent<PlayerController>().GetResourceProgress();

        print("Triggered");
        if (InsertedObject != ObjectType.NO_RESOURCE)
        {
            bool componentMatched = false;
            Feature featureBeingChecked = managerGenerator.Features[0];
            print("fired");

            if (InsertedObject == featureBeingChecked.R1 && !featureBeingChecked.R1Complete)
            {
                componentMatched = true;
                ChangeSprite(InsertedObject, featureBeingChecked, 0);
                featureBeingChecked.R1Complete = true;
                print("Matched slot 1");
            }
            else if (InsertedObject == featureBeingChecked.R2 && !featureBeingChecked.R2Complete)
            {
                componentMatched = true;
                ChangeSprite(InsertedObject, featureBeingChecked, 1);
                featureBeingChecked.R2Complete = true;
                print("Matched slot 2");
            }
            else if (InsertedObject == featureBeingChecked.R3 && !featureBeingChecked.R3Complete)
            {
                componentMatched = true;
                ChangeSprite(InsertedObject, featureBeingChecked, 2);
                featureBeingChecked.R3Complete = true;
                print("Matched slot 3");
            }
            else if (InsertedObject == featureBeingChecked.R4 && !featureBeingChecked.R4Complete)
            {
                componentMatched = true;
                ChangeSprite(InsertedObject, featureBeingChecked, 3);
                featureBeingChecked.R4Complete = true;
                print("Matched slot 4");
            }
            else
            {
                print("No match!");
            }


            if (componentMatched)
            {
                if (Progress < 0.9f)
                {
                    featureBeingChecked.score += Progress;
                }
                else if (Progress > 1.1f)
                {
                    featureBeingChecked.score += 2.0f - Progress;
                }
                else
                {
                    //give bonus score for neer perfect timing?
                    featureBeingChecked.score += 1.25f;
                }
            }


            //PlaceHeldObject must hapen ater all information has been colected as it resets all values
            other.gameObject.GetComponent<PlayerController>().PlaceHeldObject(componentDrop);
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
