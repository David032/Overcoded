using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUI : MonoBehaviour
{
    public FeatureGeneration featureGenerator;
    public GameObject managerLocation;
    public Sprite managerSprite;
    public GameObject bubbleLocation;
    public Sprite bubbleSprite;
    public GameObject[] resource;
    public Sprite audioSprite;
    public Sprite codeSprite;
    public Sprite conceptsSprite;
    public Sprite shapesSprite;
    ObjectType r1;
    ObjectType r2;
    ObjectType r3;
    ObjectType r4;

    public void Update ()
        {
            PopUp();
        }
    public void PopUp()
    {
       // managerLocation.GetComponent<SpriteRenderer>().sprite = managerSprite;
        bubbleLocation.GetComponent<SpriteRenderer>().sprite = bubbleSprite;
        //takes the features and stores them internly 
        r1 = featureGenerator.Features[0].R1;
        r2 = featureGenerator.Features[0].R2;
        r3 = featureGenerator.Features[0].R3;
        r4 = featureGenerator.Features[0].R4;
        LoadResource();
    }

    public void LoadResource()
    {
        //switches on each feature and sets the sprite
        switch (r1)
        {
            case ObjectType.PROCESSED_AUDIO:
                resource[0].GetComponent<SpriteRenderer>().sprite = audioSprite;
                break;
            case ObjectType.PROCESSED_CODE:
                resource[0].GetComponent<SpriteRenderer>().sprite = codeSprite;
                break;
            case ObjectType.PROCESSED_CONCEPTS:
                resource[0].GetComponent<SpriteRenderer>().sprite = conceptsSprite;
                break;
            case ObjectType.PROCESSED_SHAPES:
                resource[0].GetComponent<SpriteRenderer>().sprite = shapesSprite;
                break;

            default:
                break;
        }
        switch (r2)
        {
            case ObjectType.PROCESSED_AUDIO:
                resource[1].GetComponent<SpriteRenderer>().sprite = audioSprite;
                break;
            case ObjectType.PROCESSED_CODE:
                resource[1].GetComponent<SpriteRenderer>().sprite = codeSprite;
                break;
            case ObjectType.PROCESSED_CONCEPTS:
                resource[1].GetComponent<SpriteRenderer>().sprite = conceptsSprite;
                break;
            case ObjectType.PROCESSED_SHAPES:
                resource[1].GetComponent<SpriteRenderer>().sprite = shapesSprite;
                break;

            default:
                break;
        }
        switch (r3)
        {
            case ObjectType.PROCESSED_AUDIO:
                resource[2].GetComponent<SpriteRenderer>().sprite = audioSprite;
                break;
            case ObjectType.PROCESSED_CODE:
                resource[2].GetComponent<SpriteRenderer>().sprite = codeSprite;
                break;
            case ObjectType.PROCESSED_CONCEPTS:
                resource[2].GetComponent<SpriteRenderer>().sprite = conceptsSprite;
                break;
            case ObjectType.PROCESSED_SHAPES:
                resource[2].GetComponent<SpriteRenderer>().sprite = shapesSprite;
                break;

            default:
                break;
        }
        switch (r4)
        {
            case ObjectType.PROCESSED_AUDIO:
                resource[3].GetComponent<SpriteRenderer>().sprite = audioSprite;
                break;
            case ObjectType.PROCESSED_CODE:
                resource[3].GetComponent<SpriteRenderer>().sprite = codeSprite;
                break;
            case ObjectType.PROCESSED_CONCEPTS:
                resource[3].GetComponent<SpriteRenderer>().sprite = conceptsSprite;
                break;
            case ObjectType.PROCESSED_SHAPES:
                resource[3].GetComponent<SpriteRenderer>().sprite = shapesSprite;
                break;

            default:
                break;
        }
        
    }
}



