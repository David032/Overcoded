using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureGeneration : MonoBehaviour
{
    public List<Feature> Features;
    public int featureNumber = 0;
    public GameObject popUp;


    void createFeature() 
    {
        Features[featureNumber] = gameObject.AddComponent<Feature>();
        Features[featureNumber].CreateFeature(randomFeature(), randomFeature(), randomFeature(), randomFeature());
        if (Features[featureNumber].R1 == ObjectType.NO_RESOURCE && Features[featureNumber].R2 == ObjectType.NO_RESOURCE
            && Features[featureNumber].R3 == ObjectType.NO_RESOURCE && Features[featureNumber].R4 == ObjectType.NO_RESOURCE)
        {
            createFeature();
        }

        GameObject featureWindow = Instantiate(popUp,this.gameObject.transform,true);
        featureWindow.name = "Feature" + featureNumber.ToString();
        featureWindow.GetComponent<PopUpUI>().findTheBoss();
        featureWindow.GetComponent<PopUpUI>().PopUp(featureNumber);


        featureNumber += 1;
        Features.AddRange(new Feature[1]);
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
    private void Start()
    {
        Features.AddRange(new Feature[1]);
        createFeature();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            createFeature();
        }
    }
}
