using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Player Controller Script, that currently contains:
/// * A simple click to move function
/// </summary>



public class PlayerController : MonoBehaviour
{
    public Vector3 velocity;

    NavMeshAgent agent;
    Rigidbody rb;
    AudioController audio;
    public bool canMove;
    public SpriteRenderer spriteRenderer; //This has to be manually set as doing it via GetComponentInChildren gets the player's spriterenderer


    public ObjectType resourceType = ObjectType.NO_RESOURCE; 
    float resourceProgress;

    public Material progressNone;
    public Material progressGold;
    public Material progressMud;

    public bool isHolding = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioController>();
    }

    public bool amHolding() { return isHolding; }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canMove)
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
                audio.Playfootsteps();
            }
        }
    }

    public void PickUpObject(Sprite sprite, ObjectType objectType, float progress = 0)
    {
        if (this.resourceType == ObjectType.NO_RESOURCE && !isHolding)
        {
            spriteRenderer.sprite = sprite;
            resourceType = objectType;
            resourceProgress = progress;

            if (progress < 1.0f)
            {
                spriteRenderer.material.Lerp(progressNone, progressGold, progress);
            }
            else
            {
                spriteRenderer.material.Lerp(progressGold, progressMud, progress - 1);
            }
            isHolding = true;
        }
        audio.PlayPickupitem();
    }

    public void PlaceHeldObject()
    {
        if(resourceType != ObjectType.NO_RESOURCE)
        {
            GameObject resource = new GameObject();
            resource.AddComponent<SpriteRenderer>();
            resource.GetComponent<SpriteRenderer>().sprite = spriteRenderer.sprite;
            resource.GetComponent<SpriteRenderer>().material = spriteRenderer.material;

            resource.AddComponent<ResourceState>();
            resource.GetComponent<ResourceState>().Set(resourceType, resourceProgress);

            Quaternion rot = Quaternion.Euler(90,0,0);
            resource.transform.position = transform.position;
            resource.transform.rotation = rot;

            ClearHeldObject();
        }
        audio.PlayPlaceitemdown();
    }


    public void ClearHeldObject()
    {
        spriteRenderer.sprite = null;
        resourceType = ObjectType.NO_RESOURCE;
        isHolding = false;
        resourceProgress = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Resource")
        {
            spriteRenderer.sprite = other.gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        }
    }

    private void OnMouseDown()
    {
        canMove = true;
        StartCoroutine(countdown());
    }

    IEnumerator countdown() 
    {
        yield return new WaitForSeconds(5);
        canMove = false;
        audio.StopAudio();
    }

    public ObjectType GetResourceType()
    {
        return resourceType;
    }

    public float GetResourceProgress()
    {
        return resourceProgress;
    }
}
