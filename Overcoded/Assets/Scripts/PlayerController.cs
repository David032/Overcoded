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
    public SpriteRenderer spriteRenderer; //This has to be manually set as doing it via GetComponentInChildren gets the player's spriterenderer
    ObjectType resourceType = ObjectType.NO_RESOURCE;
    public float resourceProgress;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
    }


    public ObjectType GetHeldObjectType()
    {
        return resourceType;
    }

    public void PickUpObject(Sprite sprite, ObjectType objectType, float progress = 0)
    {
        spriteRenderer.sprite = sprite;
        resourceType = objectType;
        resourceProgress = progress;
    }

    public void ClearHeldObject()
    {
        spriteRenderer.sprite = null;
        resourceType = ObjectType.NO_RESOURCE;
        resourceProgress = 0;
    }
}
