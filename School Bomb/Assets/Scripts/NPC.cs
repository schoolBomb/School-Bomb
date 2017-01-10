using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
	private ScriptManager s;

	public int scriptNum = 0;

	// Use this for initialization
	void Start () {
		s = GameObject.Find ("Script Manager").GetComponent<ScriptManager> ();
	}

	void OnMouseDown() {
		talk ();
	}

	public void talk(){
		//StartCoroutine (s.printInUI (2,1,1,0));//test debugging
		//움직임이 멈추는 코드 
//		//대사 출력, 이벤트 발생 
		StartCoroutine (s.printInUI (Status.nowStage, Status.day, Status.time,scriptNum));//test debugging
//		//마우스 클릭 효과음 출력

	}
}
