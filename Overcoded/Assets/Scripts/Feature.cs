using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feature : MonoBehaviour
{
    public ObjectType R1;
    public ObjectType R2;
    public ObjectType R3;
    public ObjectType R4;

    public Feature() { }

    public void CreateFeature
        (ObjectType resource1,ObjectType resource2)
        { R1 = resource1;R2 = resource2;}
    public void CreateFeature
        (ObjectType resource1, ObjectType resource2, ObjectType resource3)
        { R1 = resource1; R2 = resource2;R3 = resource3;}
    public void CreateFeature
        (ObjectType resource1, ObjectType resource2,
        ObjectType resource3, ObjectType resource4) { R1 = resource1; R2 = resource2; R3 = resource3; R4 = resource4; }
}
