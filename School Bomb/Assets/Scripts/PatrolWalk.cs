using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolWalk : MonoBehaviour
{

	public float movePower = 4f;
//움직이는 속도
	float startPos;
//시작위치
	public float endPos;
//끝위치
	float distance;
	Animator animator;
	Vector3 movement;
	Renderer rend;
	Rigidbody2D rb;
	public UserWalk user;
	float waitTime = 4f;
//추격하는 시간
	float IdleSpeed;
//평상시 속도
	float UpSpeed;
//빨라진 속도
	bool facingRight = true;
	public bool left;

	public Animator Guard;//******현지추가
	public bool movingLeft;//******현지추가
	public bool movingRight;//******현지추가

	private string[] talk;
	private ScriptManager sm;
	private ItemManager im;
	private SelectStage ss;

	// Use this for initialization
	void Start ()
	{
		//       animator = gameObject.GetComponent<Animator>();
		Guard = gameObject.GetComponent<Animator>();//******현지추가
		rend = gameObject.GetComponent<Renderer> ();
		rb = gameObject.GetComponent<Rigidbody2D> ();
		startPos = transform.position.x;
//		user = GameObject.FindGameObjectWithTag("Player").GetComponent<UserWalk>();
		IdleSpeed = movePower;//평상시 속도 저장

		//17.02.11
		talk = new string[3];
		talk [0] = "";
		talk [1] = "아니에요, 하하.";
		talk [2] = "(오늘은 더 이상 힘들 것 같다. 다음을 기약하자.)";
		sm = GameObject.Find ("Script Manager").GetComponent<ScriptManager> ();
		im = GameObject.Find ("Item Manager").GetComponent<ItemManager> ();
		ss = sm.GetComponent<SelectStage> ();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		Move ();
		if (user.isTracing == true) {//player가 빛에 감지된 상태면
			StartCoroutine (changeSpeed ());
		}
	}

	public void detected ()//player가 경비원이랑 부딪히면 실행되는 메소드
	{
		if (user.move == true) {//player가 숨어있지 않을때//경비랑 부딪혔을때 멈춘뒤 대사 출력
			//상황에따라서 넘버링
			if (Status.haveBomb == false) {
				if (Status.nowStage == 10) { //1. 폭탄없이 교실복도에서 걸림, 의심도+2
					talk [0] = "밤늦게까지 힘들겠구만, 학생도.";
					whenDetected (3);
				} else {//2. 폭탄없이 서버실복도에서 걸림. 의심도+5
					talk [0] = "이런 저녁까지 학교에 남아있나? 도대체 무슨 일로?";
					talk [1] = "그... 냥요?";
					whenDetected (6);
				}
			} else {//폭탄 가장 위력이 강한 거 압수 및 재료 리젠을 위한 코드 
				if (Status.nowStage == 10) { //3. 폭탄 있고 교실 복도에서 걸림. 의심도+6
					talk [0] = "이건 폭탄 아닌가...? 학생 이건 압수하겠네!!";
					whenDetected (6);
				} else {//4. 폭탄 있고 서버실 복도에서 걸림. 의심도+12
					talk [0] = "이건 폭탄 아닌가…? 학생 지금 이거 들고 어디로… 설마!?";
					talk [1] = "어...";
					talk [2] = "가볼게요!";
					whenDetected (12);
				}
			}
		} else {//player가 숨어있지 않을때
			Debug.Log ("Not Detected");
		}
	}

	IEnumerator changeSpeed ()
	{
		//속도를 올린다
		if (movePower < 8 && movePower > 0) {
			UpSpeed = movePower + 2;
			movePower = UpSpeed;
		} else if (movePower < 0 && movePower > -8) {
			UpSpeed = movePower - 2;
			movePower = UpSpeed;
		}
		user.isTracing = false;//다시 player는 인식 안된 상태로 돌아간다
		yield return new WaitForSeconds (waitTime);//대기시간만큼 빠른 속도로 움직인다


		//평상시 속도로 돌아온다
		if (facingRight == true) {
			movePower = Mathf.Abs (IdleSpeed);
		} else {
			movePower = -Mathf.Abs (IdleSpeed);
		}

	}

	void Flip ()//뒤집기 함수
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		if (theScale.x < 0)
			facingRight = false;
		else
			facingRight = true;
		transform.localScale = theScale;
	}

	void Move ()
	{
		if (left) {//경비원이 왼쪽 포지션이면 하는 행동
			transform.Translate (new Vector3 (movePower, 0, 0) * Time.deltaTime);
			Guard.SetBool("movingRight", true); //******현지추가
			if (transform.position.x <= startPos || transform.position.x >= endPos) {
				Flip ();
				movePower *= -1;
				Guard.SetBool("movingRight", false);//******현지추가
			}
		} else {//경비원이 오른쪽 포지션이면 하는 행동
			transform.Translate (-new Vector3 (movePower, 0, 0) * Time.deltaTime);
			Guard.SetBool("movingLeft", true);//******현지추가
			if (transform.position.x > startPos + 1 || transform.position.x <= endPos) {
				Flip ();
				movePower *= -1;
				Guard.SetBool("movingRight", false);//******현지추가
			}
		}
	}

	private void whenDetected (int suspicious)
	{
		Status.suspiciousRate += suspicious;
		user.Speed = 0;
		movePower = 0;

		Debug.Log ("Before");

		if(!ScriptManager.isShowing) StartCoroutine (sm.patrolScript (talk, returnIt));
	}

	private void returnIt (int a)
	{
		Debug.Log ("Return it");
		//Status.haveBomb = false;
		user.Speed = 4f;
		movePower = 4f;

		int r;
		if (Status.haveBomb==true) {
			do { //랜덤으로 폭탄을 뺏긴다.
				r = (int)Random.Range (0, im.bombList.Length);
			} while (im.bombList [r].isComplete == false);
			im.bombList [r].isComplete = false;
			im.getBackItem (im.bombList [r].name, -1);
		}

		ss.select (0);
	}
}

