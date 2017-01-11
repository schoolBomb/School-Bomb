using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

	public ItemBasic[] itemList;

	//variable for UI
	public GameObject TextBackGround;
	public Text nameText;//name UI
	public Text senteceText;//sentence UI
	public GameObject QuestionUI;
	public Text[] questionText;

	public IEnumerator getIt(string[] s, int itemNum){
		// TextUI가 뜬다.
		//“뫄뫄”를 습득했습니다
		senteceText.text = s[4];// 설명 블라블라
		if(TextBackGround.activeSelf==false)	TextBackGround.SetActive(true);//Text UI가 뜬다.

		while(!Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.Return) && !Input.GetMouseButtonDown(0) ){
			yield return null;
		}

		senteceText.text = itemList [itemNum].data.description;// 설명 블라블라
		while(!Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.Return) && !Input.GetMouseButtonDown(0) ){
			yield return null;
		}
		//TextUI 닫힘.
		TextBackGround.SetActive(false);
		yield return null;
	}

	public IEnumerator purchase(string[] s, int itemNum){
		//마우스 클릭을 할시
		//설명 블라블라
		nameText.text = itemList [itemNum].data.name;
		senteceText.text = itemList [itemNum].data.description;
		if(TextBackGround.activeSelf==false)	TextBackGround.SetActive(true);//Text UI가 뜬다.

		int i = 0;
		while(!Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.Return) && !Input.GetMouseButtonDown(0) ){
			yield return null;
		}
		if (i == 1) {//Question
			int answer=1;

			//“뫄뫄”를 구입하시겠습니까? 예 아니오 ->Question UI
			for (int j = 0; j < 3; j++,i++) {
				questionText[j].text=s[i];
			}
			senteceText.gameObject.SetActive (false);//2.현재 sentenceUI를 끈다.
			QuestionUI.gameObject.SetActive (true);
			//선택할때까지 대기
			yield return new WaitForSeconds(0.05f);

			while(!Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.Return) ){//
				if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
					if (answer > 1) {
						TextColorChange (answer, answer - 1);
						answer--;
					}
					yield return new WaitForSeconds (0.05f);
				}
				if (Input.GetKeyDown (KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.S)) {
					if (answer < 2) {
						TextColorChange (answer, answer+1);
						answer++;
					}
					yield return new WaitForSeconds (0.05f);
				}
				yield return null;//wait until input is coming
			}
			//예-> “뫄뫄”를 구입했습니다.
			//아니오-> 구입을 취소했습니다.	
			senteceText.text = s [2 + answer];//answer에 따라서 그거 +3인 애를 골라서 sentence에 넣어준다.
			itemList[itemNum].data.location=(int)ItemPosition.toUser;// 소속된 곳이 바뀜.
			// 아이템 모습이 없어짐.
			QuestionUI.SetActive (false);
			senteceText.gameObject.SetActive (true);
			TextBackGround.SetActive (false);
		}
		//TextUI 닫힘.

		yield return null;
	}

	private void TextColorChange(int now,int after){
		questionText [now].color = new Color (0.5f,0.5f,0.5f);//make it to gray
		questionText [after].color = Color.white;//make it to white, ==answer
	}
}
