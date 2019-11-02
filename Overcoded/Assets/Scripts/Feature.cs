using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feature : MonoBehaviour
{
    public ObjectType R1;
    public ObjectType R2;
    public ObjectType R3;
    public ObjectType R4;

    public bool R1Complete;
    public bool R2Complete;
    public bool R3Complete;
    public bool R4Complete;

    public float score = 0;
    public string FeatureId;

    public GameObject linkedWindow; //make private for release

    public Feature() { }

    public void CreateFeature(ObjectType resource1, ObjectType resource2,ObjectType resource3, ObjectType resource4) 
    {
        R1 = resource1; 
        R2 = resource2; 
        R3 = resource3; 
        R4 = resource4; 
        blankSpots(); 
    }

    void blankSpots() 
    {
        if (R1 == ObjectType.NO_RESOURCE)
        {
            R1Complete = true;
        }
        if (R2 == ObjectType.NO_RESOURCE)
        {
            R2Complete = true;
        }
        if (R3 == ObjectType.NO_RESOURCE)
        {
            R3Complete = true;
        }
        if (R4 == ObjectType.NO_RESOURCE)
        {
            R4Complete = true;
        }
    }

    private void LateUpdate()
    {
        if (R1Complete && R2Complete && R3Complete && R4Complete)
        {
            //Add score to total score
            //Destroy this feature
        }
    }
}
