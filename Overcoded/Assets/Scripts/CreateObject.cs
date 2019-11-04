using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public Sprite resourceSprite;
    public ObjectType resourceType;

    private void OnTriggerEnter(Collider other)
    {       
        if (other.GetComponent<PlayerController>())
        {
            other.GetComponent<PlayerController>().ClearHeldObject();
            if (other.GetComponent<PlayerController>().GetResourceType() == ObjectType.NO_RESOURCE)
            {
                other.GetComponent<PlayerController>().PickUpObject(resourceSprite, resourceType);
            }
        }
    }
}
