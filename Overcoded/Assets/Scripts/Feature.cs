using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feature : MonoBehaviour
{
    public int FeatureId;
    public float score = 0;

    public ObjectType R1;
    public ObjectType R2;
    public ObjectType R3;
    public ObjectType R4;

    public bool R1Complete;
    public bool R2Complete;
    public bool R3Complete;
    public bool R4Complete;

    GameObject linkedWindow; //make private for release

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
            GetComponent<FeatureGeneration>().totalScore += score;
            GetComponent<FeatureGeneration>().deleteFeature(FeatureId);
            Destroy(this);
        }
    }

    public GameObject getLinkedWindow() 
    {
        return linkedWindow;
    }
    public void setLinkedWindow(GameObject window) 
    {
        linkedWindow = window;
    }
    public void MoveLinkedWindow()
    {
        if (linkedWindow)
        {
            linkedWindow.transform.Translate(0, 3, 0);
        }
    }
    public void DeleteLinkedWindow()
    {
        if (linkedWindow)
        {
            Destroy(linkedWindow);
        }
    }
}
