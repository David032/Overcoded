using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProcessResource : MonoBehaviour
{
    bool procesing = false;
    float progress = 0;
    public float progressSpeed;
    public Sprite outputResourceSprite;
    public ObjectType outputResourceType;
    public ObjectType inputResourceType;
    Image progressBar;
    SpriteRenderer progressBar1;

    // Start is called before the first frame update
    void Start()
    {
        progressBar = GetComponentInChildren<Image>();
        progressBar1 = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (progress < 1.0f)
        {
            //progressBar.fillAmount = progress;
        }
        else if (progress > 1.0f)
        {
            progressBar1.enabled = true;
            //progressBar.fillAmount = progress - 1.0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!procesing)
            {
                if (other.GetComponent<PlayerController>().GetHeldObjectType() == inputResourceType)
                {
                    other.GetComponent<PlayerController>().ClearHeldObject();
                    procesing = true;
                }
            }
            else
            {
                if (progress < 2.0f)
                {
                    //takes progressSpeed seconds for progress = 1.0f;
                    progress += Time.deltaTime / progressSpeed;
                }
                else
                {
                    progress = 2.0f;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && procesing)
        {
            other.GetComponent<PlayerController>().PickUpObject(outputResourceSprite, outputResourceType, progress);
            procesing = false;
            progressBar1.enabled = false;
            progress = 0;
        }
    }
}
