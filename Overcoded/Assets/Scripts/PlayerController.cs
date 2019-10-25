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
    SpriteRenderer carrying;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        carrying = GetComponentInChildren<SpriteRenderer>();
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
