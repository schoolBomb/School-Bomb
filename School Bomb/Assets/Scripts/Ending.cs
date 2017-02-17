using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour {

	public CameraShake cs;
	private string[] endingName;
	public static bool end;
	public SpriteRenderer sr;

   // public GameObject[] Endings;

    void Start(){
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

	public void endGame(int bombNum, float bombStrength){
//		Status.haveBomb = true;
//		bombNum = 1
//		bombStrength = 11;//Debug
		/////////////
		if (bombStrength == 0) {
			switch (bombNum) {
			case 4://	논문 자필
				StartCoroutine(boop (3));
				break;
            case 5:
                    StartCoroutine(boop(5));
                    break;
                case 6:
                    StartCoroutine(boop(6));
                    break;
                case 8://	고양이 엔딩
				StartCoroutine(boop (7));
				break;
			case 9:	//	데자와 엔딩
				StartCoroutine(boop (8));
				break;
			default:
				if (Status.suspiciousRate < 50) {//	기숙사에서 뒹굴뒹굴
					StartCoroutine (boop (1));
				} else if (Status.paper == 21) {//시체
					StartCoroutine (boop (4));
				} else if (Status.suspiciousRate >= 50) {//포돌이와의 만남
					StartCoroutine (boop (6));
				} else {//	김영란법
					StartCoroutine (boop (5));
				}
				break;
			}
		}
		else if ( Status.haveBomb && bombStrength >= 11) {//죽음
			StartCoroutine(boop (9));
		}
		else if (Status.haveBomb && Status.alibi > 0 && Status.suspiciousRate < 50 && bombStrength >= 9) {//공항에서 신문
			StartCoroutine(boop (0));
		}
		else if (Status.haveBomb && Status.alibi > 0 && Status.suspiciousRate < 50 && bombStrength < 9) {//졸업논문 공고
			StartCoroutine(boop (2));
		}
		else if (Status.haveBomb && Status.alibi == 0 && Status.suspiciousRate >= 50 && bombStrength < 6.5f) {//졸업논문 공고
			StartCoroutine(boop (2));
		}
		else if (Status.haveBomb && Status.alibi == 0 && Status.suspiciousRate >= 50 && bombStrength >= 6.5f) {//포돌이와의 만남
			StartCoroutine(boop (6));
		}
			

	}

	public IEnumerator boop(int bombNum){
		yield return new WaitForSeconds (2.0f);//1. 2초 카운트다운을 한다.
		cs.ShakeCamera(3,3);//2.카메라에 진동
		StartCoroutine(fadeIn());//3. 흰색으로 페이드 아웃

        Debug.Log(endingName[bombNum]);
        PlayerPrefs.SetInt("EndingNumber", bombNum);
        //로드 씬!!!!!!!!!!!!!!!!

        yield return new WaitForSeconds(1.5f);
        Application.LoadLevel("Ending");

        //Endings[bombNum].SetActive(true);
    }

	public IEnumerator fadeIn(){
		for (var f = 0.0; f <= 1.0; f += 0.01) {
			Color color = new Vector4 (1,1, 1, (float)f);
			sr.color = color;
			yield return new WaitForSeconds (0.01f);
		}
	}
}

