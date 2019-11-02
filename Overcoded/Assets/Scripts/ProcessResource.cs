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
    //has to be public because unity's getcompnentinchild function sucks
    public SpriteRenderer progressBar;
    public SpriteRenderer progressBar1;
    public Animator progressAnimation;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //set progress bar animation to 'progress' through
        if (progress < 1.0f)
        {
            progressAnimation.Play("Progress", 0, progress);
        }
        else if (progress > 1.0f)
        {
            //makes animated progress bar red and enables green backing 
            progressBar.color = new Color32(194, 24, 24, 255);
            progressBar1.enabled = true;
            progressAnimation.Play("Progress", 0, progress - 1.0f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!procesing)
            {
                if (other.GetComponent<PlayerController>().GetResourceType() == inputResourceType)
                {
                    other.GetComponent<PlayerController>().ClearHeldObject();
                    procesing = true;
                }
            }
            else
            {
                //cap overworking a resource to 200%
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
        //if player leaves station while processing give player procesed resource and reset progess indicators
        if (other.tag == "Player" && procesing)
        {
            other.GetComponent<PlayerController>().PickUpObject(outputResourceSprite, outputResourceType, progress);
            procesing = false;
            progressBar1.enabled = false;
            progressBar.color = new Color32( 24, 170, 24, 255);
            progress = 0;
        }
    }
}
