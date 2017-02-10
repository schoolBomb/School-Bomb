using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour {

	public CameraShake cs;
	private string[] endingName;

	void Start(){
		endingName = new string[10];
		endingName [0] = "trueEnding";
		endingName [1] = "Nothing";
		endingName [2] = "haveToWrite";
		endingName [3] = "Analog";
		endingName [4] = "alreadyWrite";
		endingName [5] = "bribe";
		endingName [6] = "police";
		endingName [7] = "Cat";
		endingName [8] = "dejava";
		endingName [9] = "death";
	}

	public void endGame(int bombNum, float bombStrength){
//		bombNum = 1;
//		bombStrength = 11;//Debug
		/////////////
		if (bombStrength == 0) {
			//		시체
			//		김영란법
			//		포돌이와의 만남

			//		기숙사에서 뒹굴뒹굴

			switch (bombNum) {
			case 4://	논문 자필
				StartCoroutine(boop (3));
				break;
			case 8://	고양이 엔딩
				StartCoroutine(boop (7));
				break;
			case 9:			//	데자와 엔딩
				StartCoroutine(boop (8));
				break;
			default:
				break;
			}
		}
		else if (bombStrength >= 11) {//		죽음
			StartCoroutine(boop (9));
		}
		else if (Status.alibi > 0 && Status.suspiciousRate < 50 && bombStrength >= 9) {//		공항에서 신문
			StartCoroutine(boop (0));
		}
		else if (Status.alibi > 0 && Status.suspiciousRate < 50 && bombStrength < 9) {//		졸업논문 공고
			StartCoroutine(boop (2));
		}
		else if (Status.alibi == 0 && Status.suspiciousRate >= 50 && bombStrength < 6.5f) {//		졸업논문 공고
			StartCoroutine(boop (2));
		}
		else if (Status.alibi == 0 && Status.suspiciousRate >= 50 && bombStrength >= 6.5f) {//		포돌이와의 만남
			StartCoroutine(boop (6));
		}
			

	}

	public IEnumerator boop(int bombNum){
		yield return new WaitForSeconds (2.0f);//1. 2초 카운트다운을 한다.
		cs.ShakeCamera(3,3);//2.카메라에 진동
		//3. 흰색으로 페이드 아웃
		Debug.Log(endingName[bombNum]);
	}

}
