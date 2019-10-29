<<<<<<< HEAD
﻿using System.Collections;
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
        if (progress < 1.0f)
        {
            spriteRenderer.material.Lerp(progressNone, progressGold, progress);
        }
        else
        {
            spriteRenderer.material.Lerp(progressGold, progressMud, progress - 1);
        }
    }

=======
﻿using System.Collections;
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
    public ObjectType resourceType;
    public bool canMove;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        resourceType = ObjectType.NO_RESOURCE;
        spriteRenderer.sprite = null;
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

>>>>>>> develop
    public void ClearHeldObject()
    {
        spriteRenderer.sprite = null;
        resourceType = ObjectType.NO_RESOURCE;
<<<<<<< HEAD
        resourceProgress = 0;
    }
}
=======
    }

    IEnumerator countdown() 
    {
        yield return new WaitForSeconds(5);
        canMove = false;
    }
}
>>>>>>> develop
