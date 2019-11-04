using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteHeldResource : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().ClearHeldObject();
            other.GetComponent<AudioController>().Playthrowinbin();
        }
    }
}
