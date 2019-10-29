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

    public int score = 0;
    public string FeatureId;

    public Feature() { }

    public void CreateFeature
        (ObjectType resource1, ObjectType resource2,
        ObjectType resource3, ObjectType resource4) { R1 = resource1; R2 = resource2; R3 = resource3; R4 = resource4; }

    public void RenderFeature() 
    {
        
    
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
