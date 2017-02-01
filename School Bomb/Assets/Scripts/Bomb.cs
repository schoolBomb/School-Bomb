using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

<<<<<<< HEAD
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
=======
	public int id;//id용 넘버
	public string name;//이름
	public int strength;//위력
	public string description;//설명
	public bool isComplete = false;
	//public Sprite endingCut;//엔딩그림

	public IEnumerator explosion(int a){//폭파함수->엔딩롤

		yield return new WaitForSeconds(2);//2초를 기다린다.

		switch (a)
		{
			case 8:
				Debug.Log("Nyang");
				break;
			case 9:
				Debug.Log("Dejava");
				break;
			default:
				Debug.Log("Boom");//엔딩
				break;
		}


		//아니오->질문창 꺼짐.
		yield return null;
	}
	//public GameObject b;
	//public BombCombine bc;

	//// Use this for initialization
	//void Start () {
	//	bc = b.GetComponent<BombCombine>();
	//}


	//void OnMouseDown()
	//{
	//	b.SetActive(true);
	//	bc.startLine(this.transform.localPosition);
	//	bc.combine(1, 2);
	//}
>>>>>>> Temp
}
