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
    public SpriteRenderer carrying; //This has to be manually set as doing it via GetComponentInChildren gets the player's spriterenderer

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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Resource")
        {
            carrying.sprite = other.gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        }
    }
}
