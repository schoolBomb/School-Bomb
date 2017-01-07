using System;
using System.Linq;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

//word script를 필요시 불러오는작업을 한다. 
public class ScriptManager : MonoBehaviour {
	private JsonReader j;
	private Word[] wordList;

	//variable for UI
	public GameObject TextBackGround;
	public Text nameText;//name UI
	public Text senteceText;//sentence UI

	// Use this for initialization
	void Start () {
		j = GetComponent<JsonReader> ();
//		StartCoroutine (printInUI (2, 1, 1));//test debugging
	}
		
	public void findWord(short nowStage,short day, short time){//장소 날짜 시간에 맞는 word list를 뽑는다 
		//C# Linq 사용, DB 랑 비슷함
		wordList = 
			(from word in j.w
			 where (word.location == nowStage) && (word.day == day) && (word.time == time)
			 select word).ToArray ();
	}

	//UI에 대사를 출력하는 함수 
	public IEnumerator printInUI(short nowStage,short day, short time){
		//1. 데이터를 추린다. ->findWord
		findWord(nowStage,day,time);

		//2. TextUI가 켜진다.
		nameText.text=wordList[0].name;
		senteceText.text = wordList [0].sentence;
		if(TextBackGround.activeSelf==false)	TextBackGround.SetActive(true);

		for (int i = 1; i < wordList.Length; i++) {
			//	3. enter 또는 space 또는 마우스 클릭을 한다.
			while(!Input.GetMouseButtonDown(0) && !Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.Return) ){// 
				yield return null;//wait until input is coming
			}
			//	4. Text가 보여진다.
				//	1. 만약 대사가 남아있는 경우 다음 대사로 바꾼다.(달칵거리는 소리 출력?)
			if (i == wordList.Length-1) {
				TextBackGround.SetActive(false);
			}
				//	2. TextUI가 꺼진다.
			else {
				nameText.text = wordList [i].name;
				senteceText.text = wordList [i].sentence;
			}
			yield return new WaitForSeconds (0.2f);
		}
		yield return null;
	}

}

