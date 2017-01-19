using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolWalk : MonoBehaviour
{

    public float movePower = 4f;
    float startPos;
    float endPos = -3f;
    float distance;
    Animator animator;
    Vector3 movement;
    bool isTracing;
    GameObject traceTarget;
    Renderer rend;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        //       animator = gameObject.GetComponent<Animator>();
        rend = gameObject.GetComponent<Renderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        startPos = transform.position.x;
        //      StartCoroutine("ChangeMovement");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            Move();
    }

	public void changeSpeed()
	{
		Debug.Log("Hit to Patrol");
	}
    
    //void onCollisionEnter2D(Collision other)
    //{
    //    Debug.Log("entered "+other.gameObject.name);
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Debug.Log("Game Over");
    //    }
    //}
    
    //void onTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log("entered " + other.gameObject.name);
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Debug.Log("Game Over");
    //    }
    //}

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Move()
    {
        transform.Translate(new Vector3(movePower, 0, 0) * Time.deltaTime);
        if (transform.position.x <= startPos || transform.position.x >= endPos)
        {
            Flip();
            movePower *= -1;
        }
    }
}
