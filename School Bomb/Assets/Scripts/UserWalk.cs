using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class UserWalk : MonoBehaviour
{

    public float Speed = 4f;//유저가 움직이는 속도
	private float min,max;
    Animator anim;
    Renderer rend;
    Rigidbody2D rb2;
    bool enter;//들어가는거, 나오는거 제어
    public bool move;//player의 움직임 제어한다, true면 움직임 가능 및 경비원 인식 못함
    public bool isTracing = false;

    public Animator Player;//********
    public bool moveRight;//********
    public bool moveLeft;//********

    // Use this for initialization
    void Start()
    {
        Player = GetComponent<Animator>();
        //      anim = GetComponent<Animator>();
        //       transform.position = new Vector3(0, 0, 0);
        rend = gameObject.GetComponent<Renderer>();
        rb2 = gameObject.GetComponent<Rigidbody2D>();
        rend.enabled = true;
        enter = false;
        move = true;
    }

    void FixedUpdate()
    {
       
        //if (Input.anyKey != false)//입력이 존재할 때..
        //{
        //    if (move == true && Input.GetKey(KeyCode.A)) //적절한 방향키의 입력이 확인되었으면
        //    {
        //        Player.SetBool("moveLeft", true);//********//애니메이션 재생인데
                
                
        //    }
        //    if (move == true && Input.GetKey(KeyCode.D))
        //    {
        //        Player.SetBool("moveRight", true);//********//왜 한쪽으로만 걷니..?
                
                
        //    }
           
        //}
        //else
        //{
        //    Player.SetBool("moveLeft", false);//********
        //    Player.SetBool("moveRight", false);//********
        //}
       
        Movement();
        
    }

    void OnTriggerEnter2D(Collider2D other)//문에 도착했을때 
    {
        if (other.gameObject.tag == "Door")
        {
            enter = true;//문에 부딪치는 동안은 w키와 s키를 사용할 수 있다
        }

        if (other.gameObject.tag == "next")
        {
            if (Status.nowStage == 10)
            {
                GameObject.Find("Script Manager").GetComponent<SelectStage>().select((int)stageNum.Lab);
            }
            else if (Status.nowStage == 11)
            {
                GameObject.Find("Script Manager").GetComponent<SelectStage>().select((int)stageNum.ServerRoom);
            }
        }


        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<PatrolWalk>().detected();//경비원과 부딪치면 실행
        }
        else if (other.gameObject.tag == "EnemyLight")
        {
            other.GetComponent<LightMovement>().changeSpeed();//cctv와 손전등 빛과 부딪치면 실행
        }

		if (other.gameObject.tag == "next") {
			GameObject.Find ("Script Manager").GetComponent<SelectStage> ().select (Status.nowStage);
		}

    }



    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Door")
        {
            enter = false;//문에서 나오면 w키와 s키를 사용할 수 없다
        }
    }

    void Movement()//움직임 제어하는 함수
    {
        if (move == true && Input.GetKey(KeyCode.A) && transform.position.x > min)//왼쪽으로 이동, 복도를 벗어나지 않게 범위 제한
        {
            Player.SetBool("moveRight", true);
            Player.SetBool("moveLeft", false);

            transform.Translate(Vector2.right * Speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 180, 0);//바라보는 방향 바뀐다
        }
		else if (move == true && Input.GetKey(KeyCode.D)&& transform.position.x < max)//오른쪽으로 이동, 복도를 벗어나지 않게 범위 제한
        {
            Player.SetBool("moveLeft", true);
            Player.SetBool("moveRight", false);

            transform.Translate(Vector2.right * Speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, 0);//바라보는 방향 바뀐다
        }
        else if (Input.GetKey(KeyCode.W) && enter == true)//숨기
        {
            rend.enabled = false;//player의 모습이 보이지 않는다
            move = false;//이때 player는 움직일 수 없다

        }
        else if (Input.GetKey(KeyCode.S) && enter == true)//나오기
        {
            rend.enabled = true;//player의 모습이 다시 나타난다
            move = true;//다시 player는 움직이는 것이 가능해진다
        }
      

    }

	public void rangeChange(float min, float max){
		this.min = min;
		this.max = max;
	}

}
