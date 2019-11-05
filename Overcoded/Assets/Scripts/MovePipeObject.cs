using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipeObject : MonoBehaviour
{
    bool moving;
    
    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        StartCoroutine(move());

    }

    // Update is called once per frame
    void Update()
    {
        if(moving)
        {
            transform.position += new Vector3(1.5f, 0, 0) * Time.deltaTime;
        }
    }

    IEnumerator move()
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(deleteItem());
        moving = true;
    }

    IEnumerator deleteItem()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }
}
