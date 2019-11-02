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
    public bool canMove;
    public SpriteRenderer spriteRenderer; //This has to be manually set as doing it via GetComponentInChildren gets the player's spriterenderer


    ObjectType resourceType = ObjectType.NO_RESOURCE; //DEBUG - CHANGE TO PRIVATE FOR RELEASE
    float resourceProgress;

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
        if (Input.GetMouseButtonDown(0) && canMove)
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
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

            Quaternion rot = Quaternion.Euler(90,0,0);
            resource.transform.position = transform.position;
            resource.transform.rotation = rot;
            resource.transform.localScale.Set(0.15f, 0.15f, 1); //This isn't scaling properly and I don't know why :(
            resource.transform.localScale.Scale(new Vector3(0.15f, 0.15f, 1));

            //Instantiate(resource, transform.position, rot); - The moment a new gameobject is created, it's spawned in the worldspace

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

    public ObjectType GetResourceType()
    {
        return resourceType;
    }

    public float GetResourceProgress()
    {
        return resourceProgress;
    }
}
