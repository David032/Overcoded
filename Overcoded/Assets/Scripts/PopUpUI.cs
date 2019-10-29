using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUI : MonoBehaviour
{
    public FeatureGeneration featureGenerator;
    public GameObject[] resource;
    public Sprite audioSprite;
    public Sprite codeSprite;
    public Sprite conceptsSprite;
    public Sprite shapesSprite;
    ObjectType r1;
    ObjectType r2;
    ObjectType r3;
    ObjectType r4;


    public void findTheBoss() 
    {
        featureGenerator = GameObject.FindGameObjectWithTag("GameController").GetComponent<FeatureGeneration>();
    }

    public void PopUp(int fNum)
    {
        //takes the features and stores them internly 
        r1 = featureGenerator.Features[fNum].R1;
        r2 = featureGenerator.Features[fNum].R2;
        r3 = featureGenerator.Features[fNum].R3;
        r4 = featureGenerator.Features[fNum].R4;
        LoadResource(fNum);
    }

    public void LoadResource(int fNum)
    {
        //switches on each feature and sets the sprite
        switch (r1)
        {
            case ObjectType.PROCESSED_AUDIO:
                resource[fNum].GetComponent<SpriteRenderer>().sprite = audioSprite;
                break;
            case ObjectType.PROCESSED_CODE:
                resource[fNum].GetComponent<SpriteRenderer>().sprite = codeSprite;
                break;
            case ObjectType.PROCESSED_CONCEPTS:
                resource[fNum].GetComponent<SpriteRenderer>().sprite = conceptsSprite;
                break;
            case ObjectType.PROCESSED_SHAPES:
                resource[fNum].GetComponent<SpriteRenderer>().sprite = shapesSprite;
                break;

            default:
                break;
        }
        switch (r2)
        {
            case ObjectType.PROCESSED_AUDIO:
                resource[fNum].GetComponent<SpriteRenderer>().sprite = audioSprite;
                break;
            case ObjectType.PROCESSED_CODE:
                resource[fNum].GetComponent<SpriteRenderer>().sprite = codeSprite;
                break;
            case ObjectType.PROCESSED_CONCEPTS:
                resource[fNum].GetComponent<SpriteRenderer>().sprite = conceptsSprite;
                break;
            case ObjectType.PROCESSED_SHAPES:
                resource[fNum].GetComponent<SpriteRenderer>().sprite = shapesSprite;
                break;

            default:
                break;
        }
        switch (r3)
        {
            case ObjectType.PROCESSED_AUDIO:
                resource[fNum].GetComponent<SpriteRenderer>().sprite = audioSprite;
                break;
            case ObjectType.PROCESSED_CODE:
                resource[fNum].GetComponent<SpriteRenderer>().sprite = codeSprite;
                break;
            case ObjectType.PROCESSED_CONCEPTS:
                resource[fNum].GetComponent<SpriteRenderer>().sprite = conceptsSprite;
                break;
            case ObjectType.PROCESSED_SHAPES:
                resource[fNum].GetComponent<SpriteRenderer>().sprite = shapesSprite;
                break;

            default:
                break;
        }
        switch (r4)
        {
            case ObjectType.PROCESSED_AUDIO:
                resource[fNum].GetComponent<SpriteRenderer>().sprite = audioSprite;
                break;
            case ObjectType.PROCESSED_CODE:
                resource[fNum].GetComponent<SpriteRenderer>().sprite = codeSprite;
                break;
            case ObjectType.PROCESSED_CONCEPTS:
                resource[fNum].GetComponent<SpriteRenderer>().sprite = conceptsSprite;
                break;
            case ObjectType.PROCESSED_SHAPES:
                resource[fNum].GetComponent<SpriteRenderer>().sprite = shapesSprite;
                break;

            default:
                break;
        }
        
    }
}



