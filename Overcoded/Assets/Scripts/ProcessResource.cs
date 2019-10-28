using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessResource : MonoBehaviour
{
    bool procesing = false;
    float progress = 0;
    public float progressSpeed;
    public Sprite outputResourceSprite;
    public ObjectType outputResourceType;
    public ObjectType inputResourceType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!procesing)
            {
                if (other.GetComponent<PlayerController>().GetHeldObjectType() == inputResourceType)
                {
                    other.GetComponent<PlayerController>().ClearHeldObject();
                    procesing = true;
                }
            }
            else
            {
                progress += Time.deltaTime / progressSpeed;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && procesing)
        {
            other.GetComponent<PlayerController>().PickUpObject(outputResourceSprite, outputResourceType, progress);
            procesing = false;
        }
    }
}
