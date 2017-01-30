using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NPC : MonoBehaviour {
	private ScriptManager s;
	private ItemManager im;

	public int scriptNum = 0;

	public int[] time;
	public int[] day;

	// Use this for initialization
	void Start () {
		s = GameObject.Find ("Script Manager").GetComponent<ScriptManager> ();
		im = GameObject.Find ("Item Manager").GetComponent<ItemManager> ();

	}

	void OnMouseDown() {
		talk ();
	}

	public void talk(){
		//StartCoroutine (s.printInUI (2,1,1,0));//test debugging
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
		Comp c = new Comp (answer, this.scriptNum, Status.nowStage);
		string[] s;
//		for (int i = 0; i < s.Length; i++) {
//			s [i] = i.ToString();
//		}

		//answer scriptNum location
		switch(Status.nowStage){
		case 1:
			if (c.compare (10, 0, 1)) {//10 0 1 갤럭시 노트 획득
				im.startGetIt(out s,14);
			} 
			else {
			}

			break;
		case 2:
			if (c.compare (1, 0, 2)) {//1 0 2 의심도 증가
				Status.suspiciousRate += 5;
			} 
			else if (c.compare (3, 0, 2)) {//3 0 2  교수님의 마음획득
				im.startGetIt(out s,16);
			} 
			else if (c.compare (2, 1, 2)) {//2 1 2 의심도 증가
				Status.suspiciousRate += 5;
			} 
			else if (c.compare (1, 2, 2)) {//1 2 2 교수님의 마음 획득
				im.startGetIt(out s,16);
			} 
			else if (c.compare (2, 2, 2)) {//2 2 2 의심도 증가
				Status.suspiciousRate += 5;
			}
			else if (c.compare (3, 2, 2)) {//3 2 2 의심도 증가
				Status.suspiciousRate += 5;
			}
			else if (c.compare (1, 3, 2)) {//1 3 2 김영란법 엔딩
				//
			}
			else if (c.compare (2, 3, 2)) {//2 3 2 교수님의 마음 획득
				im.startGetIt(out s,16);
			}
			else if (c.compare (1, 4, 2)) {//1 4 2 경찰 엔딩
				//
			}
			else if (c.compare (2, 4, 2)) {//2 4 2 교수님의 마음 획득
				im.startGetIt(out s,16);
			} 
			else {
			}

			break;
		case 3:
			if (c.compare (1, 1, 3)) {//1 1 3 성서 획득
				if(im==null) Debug.Log("XXX");
				im.startGetIt (out s, 18);
			}
			else if (c.compare (2, 1, 3)) {//2 1 3 알리바이 획득
				Debug.Log("why");
				Status.alibi+=1;
			}
			else if (c.compare (1, 2, 3)) {//1 2 3 알리바이 획득
				Status.alibi+=1;
			}
			else if (c.compare (2, 2, 3)) {//2 2 3 구겨진 0점 시험지 획득
				im.startGetIt(out s,9);
			}
			else {
			}
			break;
		case 7:
			if (c.compare (1, 0, 7)) {//1 0 7 의심도 증가
				Status.suspiciousRate += 5;
			}
			else if (c.compare (2, 0, 7)) {//2 0 7 의심도 증가
				Status.suspiciousRate += 5;
			}
			else if (c.compare (3, 0, 7)) {//3 0 7 위장용 곰인형으로 인해 회피
			//
			}
			else if (c.compare (4, 0, 7)) {//4 0 7 의심도 증가
				Status.suspiciousRate += 5;
			}
			else if (c.compare (5, 0, 7)) {//5 0 7 경찰 엔딩
			//
			}
			else if (c.compare (1, 1, 7)) {//1 1 7 글리세린 획득
				im.startGetIt(out s,6);
			} 
			else {
			}
			break;
		default:
			break;

		}

	}
}
