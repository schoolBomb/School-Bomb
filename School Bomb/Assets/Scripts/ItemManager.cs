using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void func1(int a);

public class ItemManager : MonoBehaviour {


	private ItemBasic[] itemList;
	public Bomb[] bombList { get; set; }

	//variable for UI
	public GameObject TextBackGround;
	public Text nameText;//name UI
	public Text senteceText;//sentence UI
	public GameObject QuestionUI;
	public Text[] questionText;

	public Sprite cat;
	public float proHeartCount{ get; set; }
	private float strength;

	private AudioSource ac;

	void Start()
	{
		ac = gameObject.GetComponent<AudioSource> ();
		//아이템 시트 가져오기 
		JsonReader j = GameObject.Find("Script Manager").GetComponent<JsonReader>();
		if (j == null) Debug.Log("jason reader is null!");
		j.getItemSheet();

		itemList = this.GetComponentsInChildren<ItemBasic>();
		for (int i = 0; i < itemList.Length; i++)//deep copy
		{
			itemList [i].data = j.it [i];
            itemList[i].saveData = itemList[i].data.location;
			itemList [i].initializeText ();
		}

		//bomblist 작성 
		bombList = GameObject.Find("Bomb").GetComponentsInChildren<Bomb>();
		conceal();
	}

	public void startGetIt(out string[] s, int itemNum ){
		s = new string[6];
		s = itemList [itemNum].txt;
		itemList[itemNum].data.location = (int)ItemPosition.toUser;
		itemList [itemNum].gameObject.transform.localPosition = itemList [itemNum].dormPos;
		itemList [itemNum].gameObject.SetActive(false);

		if (itemNum == 15) {
			Status.money -= itemList [itemNum].data.price;
			GameObject.Find ("Script Manager").GetComponent<SelectStage> ().updateCoin ();
		}
		//StartCoroutine (getIt(s,itemNum));
	}

	public IEnumerator getIt(string[] s, int itemNum){
		ScriptManager.isShowing = true;
		// TextUI가 뜬다.
		//“뫄뫄”를 습득했습니다
		itemList [itemNum].initializeText ();

		senteceText.text = s[4];// 설명 블라블라
		yield return new WaitForSeconds(0.05f);
		if(TextBackGround.activeSelf==false)	TextBackGround.SetActive(true);//Text UI가 뜬다.

		while(!Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.Return) && !Input.GetMouseButtonDown(0) ){
			yield return null;
		}

		if(itemNum != -1) senteceText.text = itemList [itemNum].data.description;// 설명 블라블라
		while(!Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.Return) && !Input.GetMouseButtonDown(0) ){
			yield return null;
		}
		//TextUI 닫힘.
		TextBackGround.SetActive(false);

		if (itemNum != -1) {
			itemList [itemNum].data.location = (int)ItemPosition.toUser;
			itemList [itemNum].gameObject.transform.localPosition = itemList [itemNum].dormPos;
			itemList [itemNum].gameObject.SetActive (false);
			if (itemNum == 17) {
				itemList [itemNum].gameObject.GetComponent<SpriteRenderer> ().sprite = cat;
			}
		}

		if (ac.clip != null) {
			ac.Play ();
		}
		ScriptManager.isShowing = false;
		yield return null;
	}

	public IEnumerator purchase(string[] s, int itemNum, func1 another){
		ScriptManager.isShowing = true;
		initQuestion(2);
		//마우스 클릭을 할시
		//설명 블라블라
		if(itemNum>=0) nameText.text = itemList [itemNum].data.name;
		senteceText.text = s[0];
		if(TextBackGround.activeSelf==false)	TextBackGround.SetActive(true);//Text UI가 뜬다.

		int i = 0;
		while(!Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.Return) && !Input.GetMouseButtonDown(0) ){
			yield return null;
		}
		i = 1;
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
			//예-> “뫄뫄”를 구입했습니다.//아니오-> 구입을 취소했습니다.	
			if(s.Length>=5) senteceText.text = s [2 + answer];//not door
			/////////////17.01.14
			another(answer); 
			// 아이템 모습이 없어짐.
			QuestionUI.SetActive (false);
			senteceText.gameObject.SetActive (true);
			TextBackGround.SetActive (false);//TextUI 닫힘.
		}
		ScriptManager.isShowing = false;
		if (ac.clip != null) {
			ac.Play ();
			//ac.clip = null;
		}
		yield return null;
	}

	public void ending(int bombNum)
	{
		Ending e = GetComponent<Ending> ();
		e.endGame (bombNum, bombList [bombNum].strength + strength);
	}

	public void explode(float locStrength)//폭발 진행 
	{
		strength = locStrength;
		string[] str = new string[14];
		str[0] = "";
		str[1] = "폭탄을 설치하시겠습니까?";//질문을 한다: 폭탄을 설치하시겠습니까?
		int i = 2;
		for (int j = 2 ; j < bombList.Length ; j++){//폭탄 종류가 쫙 뜬다. 다이너마이트…
			if ( bombList[j-2].isComplete==true )
			{
				str[i] = string.Copy(bombList[j-2].name);
				i++;
			}
		}
		str[i++] = "네";
		str[i] = "아니오";
		StartCoroutine(purchase(str, -1,ending));
		//폭탄 선택
		//설치하시겠습니까? 예, 아니오
	}



	private void TextColorChange(int now,int after){
		questionText [now].color = new Color (0.5f,0.5f,0.5f);//make it to gray
		questionText [after].color = Color.white;//make it to white, ==answer
	}

	//상점에서 구입할수 있는 아이템을 출력한다.
	public void show(int location)//parameter로 출력하고 싶은 상황을 받는다.
	{
		//아이템 location을 확인
		for (int i = 0; i < itemList.Length; i++)
		{//0일 경우 그냥 띄운다.//그외에는 현재시간과 같을 경우만 띄운다.
			if (location == itemList[i].data.location && (itemList[i].time==0 || itemList[i].time == Status.time ))
			{
				if (i == 2 || i == 3 ) {//show를 할때 i가 2이면
					int x = (int)Random.Range (2, 3.99999f);//random를 돌리고 그중하나를 키고 i=3으로 맞춘다.
					itemList [x].gameObject.SetActive (true);
					i = 3;
				}
				else {
                    if (location == (int)ItemPosition.toUser)
                    {
                        itemList[i].gameObject.transform.localPosition = itemList[i].dormPos;
                    }
                    itemList [i].gameObject.SetActive (true);
				}
			}
		}
	}

	public void showDorm(){
		if (proHeartCount == 1.00f) {
			itemList [16].gameObject.SetActive (true);
		} else {
			itemList [16].gameObject.SetActive (false);
		}
	}

	private void initQuestion(int iter)
	{
		nameText.text = "";

		for (int i = 1; i < questionText.Length; i++)
		{
			questionText [i].text = "";
			questionText[i].gameObject.SetActive(false);
		}
		for (int i = 1; i <= iter; i++)
		{
			if (i == 1) {
				questionText [i].color = Color.white;
			} else {
				questionText [i].color = new Color (0.5f,0.5f,0.5f);
			}
			questionText[i].gameObject.SetActive(true);
		}

	}

	public void conceal()
	{
		for (int i = 0; i < itemList.Length; i++)
		{
			itemList[i].gameObject.SetActive(false);
		}

		for (int i = 0; i < bombList.Length; i++)
		{
			bombList[i].gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
	}

	public void getAudioClip(AudioClip ac){
		this.ac.clip = ac;
	}

    public void getBackItem(string bomb)
    {
        for(int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i].data.bomb.Equals(bomb))
            {
                itemList[i].data.location = itemList[i].saveData;
                itemList[i].transform.localPosition = itemList[i].beforePos;
            }
        }
    }
}
