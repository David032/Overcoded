using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceState : MonoBehaviour
{
    ObjectType type;
    float progress;

    public void Set(ObjectType newType, float newProgress)
    {
        type = newType;
        progress = newProgress;
    }

    public ObjectType GetResourceType()
    {
        return type;
    }
    public float GetProgress()
    {
        return progress;
    }
}
