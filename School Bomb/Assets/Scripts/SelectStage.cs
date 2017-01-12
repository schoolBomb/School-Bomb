using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStage : MonoBehaviour {
	public GameObject[] gameUI;
	public GameObject[] stages;
		
	public void select(int selectNum){

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
