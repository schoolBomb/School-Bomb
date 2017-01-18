using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStage : MonoBehaviour {//change stage and manage UI
	public GameObject[] gameUI;
	public GameObject[] stages;
	public Text[] upLeft;

	//variable for change select stage background
	public Sprite[] selectBack;	

	//when select Stage
	public void select(int selectNum){
		//받은 parameter에 맞는 stages와 backGround를 활성화한다.
		if (selectNum == 0) {//이때 dorm과 selectStage는 제외
			stages [Status.nowStage].SetActive (false);
			Status.changeTime();//시간변경
			Status.nowStage = (short)selectNum;
			stages [0].SetActive (true);
			gameUI[0].SetActive (true);
			gameUI[1].SetActive (true);
			updateUpLeftUI ();
		}
		else {
			if ( selectNum == 6 || selectNum==8 ) {//if dormitory
			} 
			else {
				stages [9].SetActive (true);
				//updateUpLeftUI ();
			}
			Status.nowStage = (short)selectNum;
			gameUI[0].SetActive (false);//selectButton
			gameUI[1].SetActive (false);//dorm
			stages [0].SetActive (false);
			stages [selectNum].SetActive (true);
		}
		//필요에따른 로딩차아아앙
	}

	public void updateUpLeftUI(){
		updateTime ();
		updateDay ();

	}

	public void updateTime(){
		SpriteRenderer s = stages [0].GetComponent<SpriteRenderer> ();

		switch (Status.time) {
		case (int)TimeOfDay.Day:
			upLeft [1].text = "낮";
			s.sprite = selectBack [0];
			break;
		case (int)TimeOfDay.Evening:
			upLeft [1].text = "저녁";
			s.sprite = selectBack [1];
			break;
		case (int)TimeOfDay.Night:
			upLeft [1].text = "밤";
			s.sprite = selectBack [2];
			break;
		default:
			break;
		}
	}

	public void updateDay(){
		switch (Status.day) {
		case (int)DayOfWeek.Monday:
			upLeft [0].text = "月";
			break;
		case (int)DayOfWeek.Tuesday:
			upLeft [0].text = "火";
			break;
		case (int)DayOfWeek.Wedesday:
			upLeft [0].text = "水";
			break;
		case (int)DayOfWeek.Thursday:
			upLeft [0].text = "木";
			break;
		case (int)DayOfWeek.Friday:
			upLeft [0].text = "金";
			break;
		case (int)DayOfWeek.Saturday:
			upLeft [0].text = "土";
			break;
		case (int)DayOfWeek.Sunday:
			upLeft [0].text = "日";
			break;
		}
	}
}
