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

    bool mute; //used only for creating placed object
    public GameObject PlacedItem;


    public Sprite APlayer;
    bool aPlayer;
    public Sprite APLayerAlt;
    public Sprite APLayerHighlighted;
    public Sprite APLayerAltHighlighted;

    public Sprite APlayer_up;
    public Sprite APLayerAlt_up;
    public Sprite APLayerHighlighted_up;
    public Sprite APLayerAltHighlighted_up;

    public Sprite BPlayer;
    bool bPlayer;
    public Sprite BPLayerAlt;
    public Sprite BPLayerHighlighted;
    public Sprite BPLayerAltHighlighted;

    public Sprite BPlayer_up;
    public Sprite BPLayerAlt_up;
    public Sprite BPLayerHighlighted_up;
    public Sprite BPLayerAltHighlighted_up;

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
        //PlayerA - No Resource - Movement
        if (resourceType == ObjectType.NO_RESOURCE && aPlayer && canMove && transform.position.z < playerMoveTo.z)
        {
            playerRenderer.sprite = APLayerHighlighted_up;
        }

        if (resourceType == ObjectType.NO_RESOURCE && aPlayer && canMove && transform.position.z > playerMoveTo.z)
        {
            playerRenderer.sprite = APLayerHighlighted;
        }

        //PlayerB - No Resource - Movement
        if (resourceType == ObjectType.NO_RESOURCE && bPlayer && canMove && transform.position.z < playerMoveTo.z)
        {
            playerRenderer.sprite = BPLayerHighlighted_up;
        }

        if (resourceType == ObjectType.NO_RESOURCE && bPlayer && canMove && transform.position.z > playerMoveTo.z)
        {
            playerRenderer.sprite = BPLayerHighlighted;
        }

        //PlayerA - Resource - Movement
        if (resourceType != ObjectType.NO_RESOURCE && aPlayer && canMove && transform.position.z < playerMoveTo.z)
        {
            playerRenderer.sprite = APLayerAltHighlighted_up;
        }
        if (resourceType != ObjectType.NO_RESOURCE && aPlayer && canMove && transform.position.z > playerMoveTo.z)
        {
            playerRenderer.sprite = APLayerAltHighlighted;
        }

        //PlayerB - Resource - Movement
        if (resourceType != ObjectType.NO_RESOURCE && bPlayer && canMove && transform.position.z < playerMoveTo.z)
        {
            playerRenderer.sprite = BPLayerAltHighlighted_up;
        }
        if (resourceType != ObjectType.NO_RESOURCE && bPlayer && canMove && transform.position.z > playerMoveTo.z) 
        {
            playerRenderer.sprite = BPLayerAltHighlighted;
        }

        //PlayerA - Not Moveable
        if (resourceType != ObjectType.NO_RESOURCE && aPlayer && !canMove)
        {
            playerRenderer.sprite = APLayerAlt;
        }
        if (resourceType == ObjectType.NO_RESOURCE && aPlayer && !canMove)
        {
            playerRenderer.sprite = APlayer;
        }

        //PlayerB - Not Moveable
        if (resourceType != ObjectType.NO_RESOURCE && bPlayer && !canMove)
        {
            playerRenderer.sprite = BPLayerAlt;
        }
        if (resourceType == ObjectType.NO_RESOURCE && bPlayer && !canMove)
        {
            playerRenderer.sprite = BPlayer;
        }

        //if (resourceType == ObjectType.NO_RESOURCE && aPlayer && canMove)
        //{
        //    playerRenderer.sprite = APLayerHighlighted;
        //}
        //if (resourceType != ObjectType.NO_RESOURCE && aPlayer && canMove)
        //{
        //    playerRenderer.sprite = APLayerAltHighlighted;
        //}





        //if (resourceType == ObjectType.NO_RESOURCE && bPlayer && canMove)
        //{
        //    playerRenderer.sprite = BPLayerHighlighted;
        //}
        //if (resourceType != ObjectType.NO_RESOURCE && bPlayer && canMove)
        //{
        //    playerRenderer.sprite = BPLayerAltHighlighted;
        //}
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

            resource.GetComponent<SpriteRenderer>().sprite = iconRenderer.sprite;
            resource.GetComponent<SpriteRenderer>().material = placedMaterial;

            resource.GetComponent<ResourceState>().Set(resourceType, resourceProgress);

            resource.GetComponent<AudioSource>().mute = mute;

            ClearHeldObject();
        }

        audio.PlayPlaceitemdown();

    }

    private void PlayerMoveToPoint()
    {
        
        Debug.Log(playerSprite.transform);
       
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
