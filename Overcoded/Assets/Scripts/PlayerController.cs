using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Player Controller Script, that currently contains:
/// * A simple click to move function
/// * Space for sprite manipulation -> Animating, and applying a highlight when selected
/// * Resource acquisition
/// </summary>



public class PlayerController : MonoBehaviour
{
    NavMeshAgent agent;
    Rigidbody rb;
    bool canMove;
    public SpriteRenderer spriteRenderer; //This has to be manually set as doing it via GetComponentInChildren gets the player's spriterenderer


    ObjectType resourceType = ObjectType.NO_RESOURCE;
    public float resourceProgress;

    public Material progressNone;
    public Material progressGold;
    public Material progressMud;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        highlightCheck();

        if (Input.GetMouseButtonDown(0) && canMove)
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
    }

    private void highlightCheck()
    {
        if (canMove)
        {
            //Apply the player highlight here
        }
        else
        {
            //Reset to default player sprite
        }
    }

    bool getMovableState() { return canMove; } //this might be useful for checking whether or not the player needs animating

    public ObjectType GetHeldObjectType()
    {
        return resourceType;
    }

    public void PickUpObject(Sprite sprite, ObjectType objectType, float progress = 0)
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


            Instantiate(resource, transform.position, new Quaternion(0.25f, 0.0f, 0.0f, 0.0f));

            ClearHeldObject();
        }
    }


    public void ClearHeldObject()
    {
        spriteRenderer.sprite = null;
        resourceType = ObjectType.NO_RESOURCE;

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
    }
}
