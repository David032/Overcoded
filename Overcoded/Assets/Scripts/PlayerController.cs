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
    private bool at_work = false; 

    public ObjectType resourceType = ObjectType.NO_RESOURCE; 
    float resourceProgress;

    public Material progressNone;
    public Material progressGold;
    public Material progressMud;

    public bool isHolding = false;
    public bool move;

    bool mute; //used only for creating placed object
    public GameObject PlacedItem;

    //Sprite Male - Downward
    public Sprite APlayer;
    bool aPlayer;
    public Sprite APlayerAlt;
    public Sprite APlayerHighlighted;
    public Sprite APlayerAltHighlighted;

    //Sprite Male - Upward
    public Sprite APlayer_up;
    public Sprite APlayerAlt_up;
    public Sprite APlayerHighlighted_up;
    public Sprite APlayerAltHighlighted_up;

    //Sprite Female - Downward
    public Sprite BPlayer;
    bool bPlayer;
    public Sprite BPlayerAlt;
    public Sprite BPlayerHighlighted;
    public Sprite BPlayerAltHighlighted;

    //Sprite Female - Upward
    public Sprite BPlayer_up;
    public Sprite BPlayerAlt_up;
    public Sprite BPlayerHighlighted_up;
    public Sprite BPlayerAltHighlighted_up;

    //Testing
    Vector3 playerMoveTo;

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


        GameObject manager = GameObject.FindGameObjectWithTag("GameController");
        mute = manager.GetComponent<GameController>().IsMuted();
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
                playerMoveTo = agent.destination;
            }
        }
    }



    private void spriteChange()
    {
        if (!at_work)
        {
            //PlayerA - No Resource - Movement
            if (resourceType == ObjectType.NO_RESOURCE && aPlayer && canMove && transform.position.z < playerMoveTo.z)
            {
                playerRenderer.sprite = APlayerHighlighted_up;
            }

            if (resourceType == ObjectType.NO_RESOURCE && aPlayer && canMove && transform.position.z > playerMoveTo.z)
            {
                playerRenderer.sprite = APlayerHighlighted;
            }

            //PlayerB - No Resource - Movement
            if (resourceType == ObjectType.NO_RESOURCE && bPlayer && canMove && transform.position.z < playerMoveTo.z)
            {
                playerRenderer.sprite = BPlayerHighlighted_up;
            }

            if (resourceType == ObjectType.NO_RESOURCE && bPlayer && canMove && transform.position.z > playerMoveTo.z)
            {
                playerRenderer.sprite = BPlayerHighlighted;
            }

            //PlayerA - Resource - Movement
            if (resourceType != ObjectType.NO_RESOURCE && aPlayer && canMove && transform.position.z < playerMoveTo.z)
            {
                playerRenderer.sprite = APlayerAltHighlighted_up;
            }
            if (resourceType != ObjectType.NO_RESOURCE && aPlayer && canMove && transform.position.z > playerMoveTo.z)
            {
                playerRenderer.sprite = APlayerAltHighlighted;
            }

            //PlayerB - Resource - Movement
            if (resourceType != ObjectType.NO_RESOURCE && bPlayer && canMove && transform.position.z < playerMoveTo.z)
            {
                playerRenderer.sprite = BPlayerAltHighlighted_up;
            }
            if (resourceType != ObjectType.NO_RESOURCE && bPlayer && canMove && transform.position.z > playerMoveTo.z)
            {
                playerRenderer.sprite = BPlayerAltHighlighted;
            }

            //PlayerA - Not Moveable
            if (resourceType != ObjectType.NO_RESOURCE && aPlayer && !canMove)
            {
                playerRenderer.sprite = APlayerAlt;
            }
            if (resourceType == ObjectType.NO_RESOURCE && aPlayer && !canMove)
            {
                playerRenderer.sprite = APlayer;
            }

            //PlayerB - Not Moveable
            if (resourceType != ObjectType.NO_RESOURCE && bPlayer && !canMove)
            {
                playerRenderer.sprite = BPlayerAlt;
            }
            if (resourceType == ObjectType.NO_RESOURCE && bPlayer && !canMove)
            {
                playerRenderer.sprite = BPlayer;
            }
        }
        else if (at_work)
        {
            if (resourceType != ObjectType.NO_RESOURCE && aPlayer && canMove)
            {
                playerRenderer.sprite = APlayerHighlighted_up;
            }
            if (resourceType != ObjectType.NO_RESOURCE && bPlayer && canMove)
            {
                playerRenderer.sprite = BPlayerHighlighted_up;
            }

            if (resourceType == ObjectType.NO_RESOURCE && aPlayer && !canMove)
            {
                playerRenderer.sprite = APlayer_up;
            }
            if (resourceType == ObjectType.NO_RESOURCE && bPlayer && !canMove)
            {
                playerRenderer.sprite = BPlayer_up;
            }
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
        if (resourceType != ObjectType.NO_RESOURCE)
        {
            Quaternion rot = Quaternion.Euler(90,0,0);
            GameObject resource = Instantiate(PlacedItem, dropPoint.transform.position, rot);

            Material placedMaterial = new Material(iconRenderer.material);

            placedMaterial.color = iconRenderer.material.color;
            placedMaterial.shader = iconRenderer.material.shader;

            resource.GetComponent<SpriteRenderer>().sprite = iconRenderer.sprite;
            resource.GetComponent<SpriteRenderer>().material = placedMaterial;

            resource.GetComponent<ResourceState>().Set(resourceType, resourceProgress);

            resource.GetComponent<AudioSource>().mute = mute;

            ClearHeldObject();
        }

        audio.PlayPlaceitemdown();

    }

    public void PlayerAtWorkstation(bool at_station)
    {
        at_work = at_station;
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
        yield return new WaitForSeconds(2.5f);
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
