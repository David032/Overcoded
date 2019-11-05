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
    public SpriteRenderer iconRenderer; //This has to be manually set as doing it via GetComponentInChildren gets the player's spriterenderer
    public GameObject playerSprite;
    SpriteRenderer playerRenderer;
    bool isHighlighted;


    public ObjectType resourceType = ObjectType.NO_RESOURCE; 
    float resourceProgress;

    public Material progressNone;
    public Material progressGold;
    public Material progressMud;

    public bool isHolding = false;
    public bool move;




    public Sprite APlayer;
    bool aPlayer;
    public Sprite APLayerAlt;
    public Sprite APLayerHighlighted;
    public Sprite APLayerAltHighlighted;
    public Sprite BPlayer;
    bool bPlayer;
    public Sprite BPLayerAlt;
    public Sprite BPLayerHighlighted;
    public Sprite BPLayerAltHighlighted;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioController>();
        playerRenderer = playerSprite.GetComponent<SpriteRenderer>();

        int rndNumber = Random.Range(0, 2);
        if (rndNumber == 0)
        {
            playerRenderer.sprite = APlayer;
            aPlayer = true;
        }
        if (rndNumber == 1)
        {
            playerRenderer.sprite = BPlayer;
            bPlayer = true;
        }
    }

    public bool amHolding() { return isHolding; }

    void Update()
    {
        spriteChange();
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



    private void spriteChange()
    {
        if (resourceType != ObjectType.NO_RESOURCE && aPlayer && !canMove)
        {
            playerRenderer.sprite = APLayerAlt;
        }
        if (resourceType == ObjectType.NO_RESOURCE && aPlayer && !canMove)
        {
            playerRenderer.sprite = APlayer;
        }
        if (resourceType == ObjectType.NO_RESOURCE && aPlayer && canMove)
        {
            playerRenderer.sprite = APLayerHighlighted;
        }
        if (resourceType != ObjectType.NO_RESOURCE && aPlayer && canMove)
        {
            playerRenderer.sprite = APLayerAltHighlighted;
        }


        if (resourceType != ObjectType.NO_RESOURCE && bPlayer && !canMove)
        {
            playerRenderer.sprite = BPLayerAlt;
        }
        if (resourceType == ObjectType.NO_RESOURCE && bPlayer && !canMove)
        {
            playerRenderer.sprite = BPlayer;
        }
        if(resourceType == ObjectType.NO_RESOURCE && bPlayer && canMove)
        {
            playerRenderer.sprite = BPLayerHighlighted;
        }
        if (resourceType != ObjectType.NO_RESOURCE && bPlayer && canMove)
        {
            playerRenderer.sprite = BPLayerAltHighlighted;
        }
    }

    public void PickUpObject(Sprite sprite, ObjectType objectType, float progress = 0)
    {
        if (this.resourceType == ObjectType.NO_RESOURCE && !isHolding)
        {
            iconRenderer.sprite = sprite;
            resourceType = objectType;
            resourceProgress = progress;

            if (progress < 1.0f)
            {
                iconRenderer.material.Lerp(progressNone, progressGold, progress);
            }
            else
            {
                iconRenderer.material.Lerp(progressGold, progressMud, progress - 1);
            }
            isHolding = true;
        }
        audio.PlayPickupitem();
    }

    public void PlaceHeldObject(GameObject dropPoint)
    {
        if(resourceType != ObjectType.NO_RESOURCE)
        {
            GameObject resource = new GameObject();
            resource.AddComponent<SpriteRenderer>();
            resource.GetComponent<SpriteRenderer>().sprite = iconRenderer.sprite;
            resource.GetComponent<SpriteRenderer>().material = iconRenderer.material;

            resource.AddComponent<ResourceState>();
            resource.GetComponent<ResourceState>().Set(resourceType, resourceProgress);
            resource.AddComponent<MovePipeObject>();
            Quaternion rot = Quaternion.Euler(90,0,0);
            resource.transform.position = dropPoint.transform.position;
            resource.transform.rotation = rot;

            ClearHeldObject();

            

        }

        audio.PlayPlaceitemdown();
       
    }



    public void ClearHeldObject()
    {
        iconRenderer.sprite = null;
        resourceType = ObjectType.NO_RESOURCE;
        isHolding = false;
        resourceProgress = 0;
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
