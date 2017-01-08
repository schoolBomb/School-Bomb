using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStage : MonoBehaviour {
	public GameObject[] gameUI;
	public GameObject[] stages;
		
	public void select(int selectNum){
		/*그일이 끝난 후 selectStage로 돌아올 때 
		//time을 올린다.
		if (Status.time == 3) {//만약 time이 3일경우, time=1, day=+1
			Status.time = 1;
			if (Status.day < 7)//이때 day는 7까지;;
				Status.day++;
		} else {
			Status.time++;
		}
		*/
		//받은 parameter에 맞는 stages와 backGround를 활성화한다.
		if (selectNum == 0) {
			stages [0].SetActive (true);
			gameUI[0].SetActive (true);
			gameUI[1].SetActive (true);
		}
		else {
			if (selectNum == 6) {//if dormitory
			} else {
				stages [9].SetActive (true);
			}
			gameUI[0].SetActive (false);
			gameUI[1].SetActive (false);
			stages [0].SetActive (false);
			stages [selectNum].SetActive (true);
		}
		//이때 dorm과 selectStage는 제외
		//필요에따른 로딩차아아앙

	}
}
