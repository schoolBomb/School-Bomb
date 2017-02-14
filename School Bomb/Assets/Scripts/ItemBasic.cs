using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemBasic : MonoBehaviour{
	public Item data;
	public string[] txt{ get; set;}
	public Vector3 dormPos;
	private Vector3 beforePos;

	public GameObject bc;
	public int time=0;

	public AudioClip ac;

	void Start(){
		beforePos = this.gameObject.transform.localPosition;
		//ac = GetComponent<AudioSource> ();
	}

	public void initializeText(){
		txt = new string[6];
		txt [0] = data.description;
		txt [1] = data.name + "을(를) "+data.price +"원에 구입하시겠습니까? ";
		txt [2] = "예";
		txt [3] = "아니오";
		txt [4] = data.name + "을(를) 얻었습니다.";
		txt [5] = data.name + "구입을 취소했습니다.";
	}

	void OnMouseDown(){
		ItemManager manager = GameObject.Find ("Item Manager").GetComponent<ItemManager> ();

		if (data.location == (int)ItemPosition.toStore)
		{//상점 아이템 
			if (!ScriptManager.isShowing) {
				StartCoroutine (manager.purchase (txt, data.num, purchaseDetail));
				manager.getAudioClip (ac);
			}
		}
		else if (data.location == (int)ItemPosition.toUser)
		{

		}
		else {//줍는 아이템 
			//manager.startGetIt(out txt,data.num);
			if (!ScriptManager.isShowing) {
				StartCoroutine (manager.getIt (txt, data.num));
				manager.getAudioClip (ac);
			}
			//ac.Play ();
		}
	}

	public void purchaseDetail(int a){
		if (a == 1 && (Status.money >= data.price)) {
			data.location = (int)ItemPosition.toUser;
			this.gameObject.SetActive (false);
			Status.money -= data.price;
			GameObject.Find ("Script Manager").GetComponent<SelectStage> ().updateCoin ();
		} else {
			return;
		}
	}
}

