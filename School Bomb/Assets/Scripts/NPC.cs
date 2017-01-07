using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
	private ScriptManager s;

	// Use this for initialization
	void Start () {
		s = GameObject.Find ("Json Controller").GetComponent<ScriptManager> ();
	}

	void OnMouseDown() {
		talk ();
	}

	public void talk(){
		//대사 출력, 이벤트 발생 
		StartCoroutine (s.printInUI (2, 1, 1));//test debugging
		//마우스 클릭 효과음 출력

	}
}
