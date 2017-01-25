using System;
using System.Linq;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

//word script를 필요시 불러오는작업을 한다. 
public class ScriptManager : MonoBehaviour {
	private JsonReader j;
	public Word[] wordAll;
	private Word[] wordList;

	//variable for UI
	public GameObject TextBackGround;
	public Text nameText;//name UI
	public Text senteceText;//sentence UI
	public GameObject QuestionUI;
	public Text[] questionText;

	// Use this for initialization
	void Start () {
		j = GetComponent<JsonReader> ();
		j.getWordSheet();
		wordAll = j.w;
	}

	public Word[] getWordAll(){
		return wordAll;
	}

	public void findWord(short nowStage, int num){//장소 날짜 시간에 맞는 word list를 뽑는다 
		//C# Linq 사용, DB 랑 비슷함
		wordList = 
			(from word in wordAll
			 where (word.location == nowStage) && (word.num==num)
			 select word).ToArray ();
		//foreach (Word word in wordList)
		//{
		//	Debug.Log(word.name);
		//}
	}


	//UI에 대사를 출력하는 함수 
	public IEnumerator printInUI( short nowStage,short day, short time, int num ){
		//1. 데이터를 추린다. ->findWord
		findWord(nowStage,num);

		//2. TextUI가 켜진다.
		if(wordList[0].name != null) nameText.text=wordList[0].name;
		senteceText.text = wordList [0].sentence;
		if(TextBackGround.activeSelf==false)	TextBackGround.SetActive(true);

		int i = 0;
		while(i<=wordList.Length) {
			//	3. enter 또는 space 또는 마우스 클릭을 한다.
			while(!Input.GetMouseButtonDown(0) && !Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.Return) ){// 
				yield return null;//wait until input is coming
			}
			//	4. Text가 보여진다.
				//	1. TextUI가 꺼진다.
			if (i >= wordList.Length-1 ) {
				TextBackGround.SetActive(false);
				break;
			}
				//2. if it is question
			else if(wordList[i].isQuestion.Equals("Question")){
				int answer=1;
				int iter=0;
				for (int j = i+1; j < i+4; j++){//check the answer number
					if (wordList[j].isQuestion.Equals("Answer")) iter++;
				}
				initQuestion(iter);
				//1. answer인 녀석(question 다음 3개)들과 question을 텍스트에 넣는다.
				questionText[0].text="Q. "+wordList[i].sentence;
				for (int j = 1; j <= iter; j++) {
					questionText[j].text=j+". "+wordList[i+j].sentence;
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
						if (answer < iter) {
							TextColorChange (answer, answer+1);
							answer++;
						}
						yield return new WaitForSeconds (0.05f);
					}
					yield return null;//wait until input is coming
				}
				nameText.text = wordList[i + answer + iter].name;
				senteceText.text = wordList [i + answer + iter].sentence;//answer에 따라서 그거 +3인 애를 골라서 sentence에 넣어준다.
				QuestionUI.SetActive (false);
				senteceText.gameObject.SetActive (true);
				i += 2*iter+1;
			}
			//	3. 만약 대사가 남아있는 경우 다음 대사로 바꾼다.(달칵거리는 소리 출력?)
			else {
				nameText.text = wordList [i].name;
				senteceText.text = wordList [i].sentence;
				i++;
			}

			yield return new WaitForSeconds (0.2f);
		}
		yield return null;
	}

	private void initQuestion(int iter)
	{
		for (int i = 1; i < questionText.Length; i++)
		{
			questionText[i].gameObject.SetActive(false);
		}
		for (int i = 1; i <= iter; i++)
		{
			questionText[i].gameObject.SetActive(true);
		}

	}

	//색변화, 앞의 거를 회색으 한 후, 뒤를 흰색으로 함
	private void TextColorChange(int now,int after){
		questionText [now].color = new Color (0.5f,0.5f,0.5f);//make it to gray
		questionText [after].color = Color.white;//make it to white, ==answer
	}
}

