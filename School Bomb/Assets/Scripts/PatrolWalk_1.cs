using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolWalk_1 : MonoBehaviour
{

    public float movePower = 4f;//움직이는 속도
    float startPos;//시작위치
    float endPos = 2.5f;//끝위치
    float distance;
    Animator animator;
    Vector3 movement;
    Renderer rend;
    Rigidbody2D rb;
    UserWalk user;
    float waitTime = 4f;//추격하는 시간
    float IdleSpeed;//평상시 속도
    float UpSpeed;//빨라진 속도
    bool facingRight = true;

    // Use this for initialization
    void Start()
    {
        //       animator = gameObject.GetComponent<Animator>();
        rend = gameObject.GetComponent<Renderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        startPos = transform.position.x;
        user = GameObject.FindGameObjectWithTag("Player").GetComponent<UserWalk>();
        IdleSpeed = movePower;//평상시 속도 저장

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        if (user.isTracing == true)//player가 빛에 감지된 상태면
        {
            StartCoroutine(changeSpeed_1());
        }
    }

    public void detected_1()//player가 경비원이랑 부딪히면 실행되는 메소드
    {

        if (user.move == true)//player가 숨어있지 않을때
        {
            Debug.Log("Game Over : Patrol 1");
        }
        else//player가 숨어있지 않을때
        {
            Debug.Log("Not Detected : Patrol 1");
        }
    }

    IEnumerator changeSpeed_1()
    {
        Debug.Log("SpeedUp : Patrol 1");
        //속도를 올린다
        if(movePower<8 && movePower>0)
        {
            UpSpeed = movePower + 2;
            movePower = UpSpeed;
        }
        else if(movePower < 0 && movePower > -8)
        {
            //  movePower -= 2;
            UpSpeed = movePower-2;
            movePower = UpSpeed;
        }
        user.isTracing = false;//다시 player는 인식 안된 상태로 돌아간다
        yield return new WaitForSeconds(waitTime);//대기시간만큼 빠른 속도로 움직인다

        
        //평상시 속도로 돌아온다
        if(facingRight==true)
        {
            movePower = Mathf.Abs(IdleSpeed);
        }
        else
        {
            movePower = -Mathf.Abs(IdleSpeed);
        }
            

    }



    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        if (theScale.x < 0)
            facingRight = false;
        else
            facingRight = true;
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
