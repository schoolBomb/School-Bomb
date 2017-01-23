using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStage : MonoBehaviour {//change stage and manage UI

	public GameObject player;
	public GameObject[] gameUI;
	public GameObject[] stages;
	public Text[] upLeft;
	private ItemManager im;
	public GameObject load;

	//variable for change select stage background
	public Sprite[] selectBack;

	void Start()
	{
		im=GameObject.Find("Item Manager").GetComponent<ItemManager>();
	}

	//when select Stage
	public void select(int selectNum){//받은 parameter에 맞는 stages와 backGround를 활성화한다.

		StartCoroutine(loading());//로딩창 

		switch(selectNum){
			case (int)stageNum.SelectStage:
				if (!(Status.nowStage == (short)stageNum.Dormitory)) Status.changeTime();//시간변경

				stages[Status.nowStage].SetActive(false);
				stages[(int)stageNum.SelectStage].SetActive(true);
				stages[9].SetActive(false);
				gameUI[0].SetActive(true);
				gameUI[1].SetActive(true);
				gameUI[2].SetActive(false);
				updateUpLeftUI();
				break;
			
			case (int)stageNum.Dormitory:
				im.show((int)ItemPosition.toUser);
				gameUI[1].SetActive(false);
				gameUI[2].SetActive(true);
				gameUI[0].SetActive(false);//selectButton
				stages[0].SetActive(false);
				stages[selectNum].SetActive(true);
				break;

			default:
				gameUI[0].SetActive(false);//selectButton
				gameUI[1].SetActive(false);//dorm
				for (int i = 0; i < stages.Length; i++)	stages[i].SetActive(false);//initialize
				stages[selectNum].SetActive(true);

				//Exception
				if (!(selectNum == (int)stageNum.SecretRoom)) stages[9].SetActive(true);//exception for secretRoom
				if (selectNum == (int)stageNum.Shop) im.show((int)ItemPosition.toStore);

				break;
		}
		Status.nowStage = (short)selectNum;

	}

	public IEnumerator loading()//잠깐 가짜 로딩 화면 
	{
		load.SetActive(true);
		yield return new WaitForSeconds(1);
		load.SetActive(false);
		yield return null;
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
