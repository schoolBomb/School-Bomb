using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NPC : MonoBehaviour {
	private ScriptManager s;
	private ItemManager im;

	public int scriptNum = 0;
	private int c=0;
	private int cOther = 0;
	public int count=1;

	public int[] time;
	public int[] day;

	private AudioSource audio;
    private Ending ee;

	// Use this for initialization
	void Start () {
		s = GameObject.Find ("Script Manager").GetComponent<ScriptManager> ();
		im = GameObject.Find ("Item Manager").GetComponent<ItemManager> ();
        ee = GameObject.Find("Item Manager").GetComponent<Ending>();
		audio=GetComponent<AudioSource>();
	}

	void OnMouseDown() {
		if( !ScriptManager.isShowing ) talk ();
	}

	public void talk(){
		if (this.gameObject.name.Equals ("sto_npc")) {
			if(c != count){
			c++;
			return;
			}
			else{
				detail (1);
			}
		}
		//움직임이 멈추는 코드 
//		//대사 출력, 이벤트 발생 
		StartCoroutine (s.printInUI (Status.nowStage,Status.day,Status.time,scriptNum,detail));//test debugging
//		//마우스 클릭 효과음 출력
	}

	public class Comp{
		int answer;
		int scriptNum;
		int location;

		public Comp( int answer, int scriptNum, int location ){
			this.answer=answer;
			this.scriptNum=scriptNum;
			this.location=location;
		}
		public bool compare( int x, int y, int z ){
			if( (answer==x) && (location == z) && (scriptNum == y) ){
				return true;
			}
			return false;	
		}
	}

	public void detail(int answer){
		if (this.c != count) {//횟수를 센다 
			this.c++;
			return; 
		}
		Comp c = new Comp (answer, this.scriptNum, Status.nowStage);
		string[] s;
		switch(Status.nowStage){
		case 1:
			if (c.compare (1, 0, 1)) {//10 0 1 갤럭시 노트 획득
				im.startGetIt(out s,14);
				this.c = 0;
				audio.Play ();
			}else {
			}
			break;
		case 2:
			if (c.compare (1, 0, 2)) {//1 0 2 의심도 증가
				Status.suspiciousRate += 5;
				this.c = 0;
				audio.Play ();
			} 
			else if (c.compare (3, 0, 2)) {//3 0 2  교수님의 마음획득
				im.startGetIt(out s,16);
			//	im.proHeartCount += 0.2f;
				this.c = 0;
				audio.Play ();
			} 
			else if (c.compare (2, 1, 2)) {//2 1 2 의심도 증가
				Status.suspiciousRate += 5;
				this.c = 0;
				audio.Play ();
			} 
			else if (c.compare (1, 2, 2)) {//1 2 2 교수님의 마음 획득
				im.startGetIt(out s,16);
				this.c = 0;
				audio.Play ();
			} 
			else if (c.compare (2, 2, 2)) {//2 2 2 의심도 증가
				Status.suspiciousRate += 5;
				this.c = 0;
				audio.Play ();
			}
			else if (c.compare (3, 2, 2)) {//3 2 2 의심도 증가
				Status.suspiciousRate += 5;
				this.c = 0;
				audio.Play ();
			}
			else if (c.compare (1, 3, 2)) {//1 3 2 김영란법 엔딩
                    ee.endGame(5, 0);
			}
			else if (c.compare (2, 3, 2)) {//2 3 2 교수님의 마음 획득
				im.startGetIt(out s,16);
				this.c = 0;
				audio.Play ();
			}
			else if (c.compare (1, 4, 2)) {//1 4 2 경찰 엔딩
                    ee.endGame(6, 0);
			}
			else if (c.compare (2, 4, 2)) {//2 4 2 교수님의 마음 획득
				im.startGetIt(out s,16);
				this.c = 0;
				audio.Play ();
			} 
			else {
			}
			break;
		case 3:
			if (c.compare (1, 1, 3)) {//1 1 3 성서 획득
				im.startGetIt (out s, 18);
				this.c = 0;
				audio.Play ();
			}
			else if (c.compare (2, 1, 3)) {//2 1 3 알리바이 획득
				Status.alibi+=1;
				this.c = 0;
				audio.Play ();
			}
			else if (c.compare (1, 2, 3)) {//1 2 3 구겨진 0점 시험지 획득
				im.startGetIt(out s,9);
				this.c = 0;
				audio.Play ();
			}
			else if (c.compare (2, 2, 3)) {//2 2 3 알리바이 획득
				Status.alibi+=1;
				this.c = 0;
				audio.Play ();
			}
			else {
			}
			break;
		case 4://lobby
			if (c.compare (1, 0, 4) && (Status.money >= 10000)) {//1 0 4 레포트 구매 

				Status.money -= 10000;
				GameObject.Find ("Script Manager").GetComponent<SelectStage> ().updateCoin ();
//				cOther++;
//				if (cOther == 13)
//					scriptNum = 1;
				audio.Play ();
			} 
			else if (c.compare (2, 0, 4)) {//2 0 4 레포트 판매
				Status.money += 10000;
				GameObject.Find ("Script Manager").GetComponent<SelectStage> ().updateCoin ();
				cOther++;
				if (cOther == 13)
					scriptNum = 1;
				audio.Play ();
			} 
			else if (c.compare (1, 1, 4) && Status.money >= 100000 ) {//1 0 4 우라늄 획득 
				im.startGetIt (out s, 15);
				this.c = 0;
				audio.Play ();
			} else {
			}
			break;
		case 10:
			if (c.compare (1, 3, 10)) {//1 3 10 데자와 획득
				im.startGetIt (out s, 19);
				im.startGetIt (out s, 20);
				this.c = 0;
				audio.Play ();
			}
			else if (c.compare (1, 4, 10)) {//1 1 7 물 획득
				im.startGetIt (out s, 27);
				this.c = 0;
				audio.Play ();
			}
			else if (c.compare (1, 1, 10)) {//1 1 7 글리세린 획득
				im.startGetIt (out s, 6);
				this.c = 0;
				audio.Play ();
			}
			else {
			}
			break;
		default:
			break;

		}

	}
}
