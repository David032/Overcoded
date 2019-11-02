using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public Sprite resourceSprite;
    public ObjectType resourceType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<PlayerController>().GetResourceType() == ObjectType.NO_RESOURCE)
            {
                other.GetComponent<PlayerController>().PickUpObject(resourceSprite, resourceType);
            }
        }
    }
}
