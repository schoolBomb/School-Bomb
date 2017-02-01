using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour {

    bool isTracing;
    GameObject traceTarget;
    // Use this for initialization
    void Start()
    {
        //       animator = gameObject.GetComponent<Animator>();
       
        //      StartCoroutine("ChangeMovement");

    }

    // Update is called once per frame
    void FixedUpdate()
    {


       


    }
    void onCollisionEnter2D(Collision other)
    {
        Debug.Log("enter "+other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            traceTarget = other.gameObject;
            Debug.Log("enter player");
        }
    }
    void onCollisionStay2D(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTracing = true;
        }
    }
    void onCollisionExit2D(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTracing = false;
        }
    }


}
