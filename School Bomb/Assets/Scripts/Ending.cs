using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{

	public CameraShake cs;
	private string[] endingName;
	public static bool end;
	public SpriteRenderer sr;

	private bool isGoing = false;

	void Start ()
	{
		endingName = new string[10];
		endingName [0] = "airportEnding";
		endingName [1] = "dormitoryEnding";
		endingName [2] = "normalPaper10";
		endingName [3] = "HandWrite";
		endingName [4] = "overwork";
		endingName [5] = "lawbreaker";
		endingName [6] = "police";
		endingName [7] = "CatEnding";
		endingName [8] = "dejavaEnding";
		endingName [9] = "bombExplodeEnding";
	}

	public void endGame (int bombNum, float bombStrength)
	{
		switch (bombNum) {
		case 1://dorm
			if (bombStrength == 0) {
				StartCoroutine (boop (1, 0));
				isGoing = true;
			}
			break;
		case 2://overwork
			if (bombStrength == 0) {
				StartCoroutine (boop (4, 0));
				isGoing = true;
			}
			break;
		case 4://handwrite
			if (bombStrength == 0) {
				StartCoroutine (boop (3, 2));
				isGoing = true;
			}
			break;
		case 5://lawbreaker
			if (bombStrength == 0) {
				StartCoroutine (boop (5, 2));
				isGoing = true;
			}
			break;
		case 6://police
			if (bombStrength == 0) {
				StartCoroutine (boop (6, 2));
				isGoing = true;
			}
			break;
		case 8://Cat
			if (bombStrength == 0) {
				StartCoroutine (boop (7, 2));
				isGoing = true;
			}
			break;
		case 9://dejava
			if (bombStrength == 0) {
				StartCoroutine (boop (8, 2));
				isGoing = true;
			}
			break;
		default:
			break;
		}	

		if (isGoing == false) {
			if (bombStrength >= 11) {//죽음
				StartCoroutine (boop (9, 2));
			} else if (Status.alibi > 0 && Status.suspiciousRate < 30 && bombStrength >= 9) {//공항에서 신문
				StartCoroutine (boop (0, 2));
			} else if (Status.alibi > 0 && Status.suspiciousRate < 30 && bombStrength < 9) {//졸업논문 공고
				StartCoroutine (boop (2, 2));
			} else if (Status.alibi == 0 && Status.suspiciousRate >= 30 && bombStrength < 6.5f) {//졸업논문 공고
				StartCoroutine (boop (2, 2));
			} else if (Status.alibi == 0 && Status.suspiciousRate >= 30 && bombStrength >= 6.5f) {//포돌이와의 만남
				StartCoroutine (boop (6, 2));
			} else {
				StartCoroutine (boop (2, 2));
			}
		}
	}

	public IEnumerator boop (int bombNum, float time)
	{
		yield return new WaitForSeconds (time);//1. 2초 카운트다운을 한다.
		cs.ShakeCamera (3, 3);//2.카메라에 진동
		StartCoroutine (fadeIn ());//3. 흰색으로 페이드 아웃

		Debug.Log (endingName [bombNum]);
		PlayerPrefs.SetInt ("EndingNumber", bombNum);
		//로드 씬!!!!!!!!!!!!!!!!

		yield return new WaitForSeconds (1.5f);
		Application.LoadLevel ("Ending");
	}

	public IEnumerator fadeIn ()
	{
		for (var f = 0.0; f <= 1.0; f += 0.01) {
			Color color = new Vector4 (1, 1, 1, (float)f);
			sr.color = color;
			yield return new WaitForSeconds (0.01f);
		}
	}
}

