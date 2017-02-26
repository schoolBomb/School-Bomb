using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStage : MonoBehaviour {//change stage and manage UI

	public GameObject[] player;
	public GameObject camera;
	private Camera cam;
	private UserWalk uw;
	private CameraContoller cc;

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
		cam = camera.GetComponent<Camera> ();
		cc = camera.GetComponent<CameraContoller> ();
		uw = player[0].GetComponent<UserWalk> ();
	}

	/// <summary>
	/// select detail, 선택함수에 대한 부분 함수 
	/// gameUI 값 수정 
	void gameUIInformation( bool ui0, bool ui1, bool ui2, bool ui3 ){
		gameUI [0].SetActive (ui0);
		gameUI [1].SetActive (ui1);
		gameUI [2].SetActive (ui2);
		gameUI [3].SetActive (ui3);
	}
	//Camera와 Userwalk에 대한 정보
	void camAndWalking( float camSize, Vector3 camPos, float ccMin, float ccMax, float uwMin, float uwMax){
		cam.orthographicSize = camSize;
		camera.transform.position = camPos;
		cc.rangeChange (ccMin, ccMax);
		uw.rangeChange (uwMin, uwMax);
	}
		
	//when select Stage
	public void select(int selectNum){//받은 parameter에 맞는 stages와 backGround를 활성화한다.
		StartCoroutine(loading());//로딩창 
		im.conceal ();


//		//선택한 스테이지에 따른 실행
//		switch (selectNum) {
//		case (int)stageNum.SelectStage:
//			//21번째 턴에서 엔딩을 실행한다. 
//			if (Status.day > (int)DayOfWeek.Sunday) {
//				if (Status.paper >= 21) {//논문엔딩
//					GameObject.Find ("Item Manager").GetComponent<Ending> ().endGame (4, 0);
//				} else {//아무것도 하지 않았다 
//					GameObject.Find ("Item Manager").GetComponent<Ending> ().endGame (0, 0);
//				}
//			} else {
//				if (Status.nowStage != (short)stageNum.Dormitory)
//					Status.changeTime ();//시간변경
//			}
//			break;
//		case (int)stageNum.Shop:
//			break;
//		case (int)stageNum.Lab:
//			break;
//		case (int)stageNum.ClubRoom:
//			break;
//		case (int)stageNum.Lobbdy:
//			break;
//		case (int)stageNum.ServerRoom:
//			break;
//		case (int)stageNum.Dormitory:
//			break;
//		case (int)stageNum.Corridor:
//			break;
//		case (int)stageNum.SecretRoom:
//			break;
//		default:
//			break;
//		}

		if (Status.day > (int)DayOfWeek.Sunday) {
			Debug.Log (Status.day);
			if (Status.paper >= 21) {
				GameObject.Find ("Item Manager").GetComponent<Ending> ().endGame (0, 0);
			} else {
				GameObject.Find ("Item Manager").GetComponent<Ending> ().endGame (0, 0);
			}
		}

		switch(selectNum){
		case (int)stageNum.SelectStage:
			//21번째 턴에서 엔딩을 실행한다. 
			if (Status.nowStage != (short)stageNum.Dormitory)
				Status.changeTime ();//시간변경
			

			camAndWalking (3.6f, new Vector3 (0, 0, -10), 0, 0, 0, 0);
			stages [Status.nowStage].SetActive (false);
			stages [(int)stageNum.SelectStage].SetActive (true);
			stages [9].SetActive (false);

			gameUIInformation (true, true, false, false);
			Status.nowStage = (short)selectNum;
			updateUpLeftUI();
			break;

		case (int)stageNum.Dormitory:
			im.show ((int)ItemPosition.toUser);
			gameUIInformation (false, false, true, false);
			stages [0].SetActive (false);
			stages [selectNum].SetActive (true);
			Status.nowStage = (short)selectNum;
			im.showDorm ();
			stages [selectNum].GetComponent<Check> ().writing ();
			break;
		default:
			gameUIInformation (false, false, false, false);
			for (int i = 0; i < stages.Length; i++)
				stages [i].SetActive (false);//initialize
			if ((selectNum == 10 || selectNum == 11) && Status.time != (int)TimeOfDay.Night) {
				stages [7].SetActive (true);
				Check chec = stages [7].GetComponent<Check> ();
				chec.checkNPC (selectNum);
			} else {
				stages [selectNum].SetActive (true);
				Check chec = stages [selectNum].GetComponent<Check> ();
				chec.checkNPC (selectNum);
			}
			Status.nowStage = (short)selectNum;
			//Exception
			if (selectNum != (int)stageNum.SecretRoom) {
				stages [9].SetActive (true);//exception for secretRoom
				player [1].SetActive (true);
				player [2].SetActive (true);
			} else {
				stages [9].SetActive (true);//exception for secretRoom
				player [1].SetActive (false);
				player [2].SetActive (false);
			}

			if (selectNum == (int)stageNum.Shop) {
				im.show ((int)ItemPosition.toStore);
			} else {
				im.show (Status.nowStage);
			}
			if (selectNum == (int)stageNum.Corridor || selectNum == 10 || selectNum == 11) {
				camAndWalking (7.0f, new Vector3 (-23.5f, 0, -10), -23.5f, 23.5f, -29.5f, 35);
				player [0].transform.localPosition = new Vector3 (-23.5f, -0.16f, -5f);
			} else {
				if (selectNum == (int)stageNum.Lab) {
					camAndWalking (3.6f, new Vector3 (0, 0, -10), -3.25f, 7, -9, 13);

				} else if (selectNum == (int)stageNum.SecretRoom) {
					camAndWalking (3.6f, new Vector3 (0, 0, -10), 0, 0, -5.5f, 5.2f);

				} else if (selectNum == (int)stageNum.ServerRoom) {
					camAndWalking (3.6f, new Vector3 (0, 0, -10), -1, 6.8f, -7, 12.8f);
				} else {
					camAndWalking (3.6f, new Vector3 (0, 0, -10), 0, 0, -6, 6);
				}
				player [0].transform.localPosition = new Vector3 (0f, -0.16f, -5f);
			}
			break;
		}

	}

	public IEnumerator loading()//잠깐 가짜 로딩 화면 
	{
		load.SetActive(true);
		yield return new WaitForSeconds(0.35f);
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
//		switch (Status.day) {
//		case (int)DayOfWeek.Monday:
//			upLeft [0].text = "月";
//			break;
//		case (int)DayOfWeek.Tuesday:
//			upLeft [0].text = "火";
//			break;
//		case (int)DayOfWeek.Wedesday:
//			upLeft [0].text = "水";
//			break;
//		case (int)DayOfWeek.Thursday:
//			upLeft [0].text = "木";
//			break;
//		case (int)DayOfWeek.Friday:
//			upLeft [0].text = "金";
//			break;
//		case (int)DayOfWeek.Saturday:
//			upLeft [0].text = "土";
//			break;
//		case (int)DayOfWeek.Sunday:
//			upLeft [0].text = "日";
//			break;
//		}
		switch (Status.day) {
		case (int)DayOfWeek.Monday:
			upLeft [0].text = "-7";
			break;
		case (int)DayOfWeek.Tuesday:
			upLeft [0].text = "-6";
			break;
		case (int)DayOfWeek.Wedesday:
			upLeft [0].text = "-5";
			break;
		case (int)DayOfWeek.Thursday:
			upLeft [0].text = "-4";
			break;
		case (int)DayOfWeek.Friday:
			upLeft [0].text = "-3";
			break;
		case (int)DayOfWeek.Saturday:
			upLeft [0].text = "-2";
			break;
		case (int)DayOfWeek.Sunday:
			upLeft [0].text = "-1";
			break;
		}
	}

	public void updateCoin(){
		upLeft [2].text = "©"+Status.money.ToString ();
	}
}
