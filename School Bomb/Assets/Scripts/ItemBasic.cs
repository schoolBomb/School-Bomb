using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemBasic : MonoBehaviour{
	public Item data;
	public string[] txt{ get; set;}
    public int saveData { get; set; }
	public Vector3 dormPos;
	public Vector3 beforePos { get; set; }

	public GameObject bc;
	public int time=0;
	private SelectStage sm;

	public AudioClip ac;
	public DragHandler dh{get;set;}

	void Start(){
		beforePos = this.gameObject.transform.localPosition;
		dh = GetComponent<DragHandler> ();
		dh.enabled = false;
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
				StartCoroutine (manager.purchase (txt, data.num, 2,purchaseDetail));
				manager.getAudioClip (ac);
			}
		}
		else if (data.location == (int)ItemPosition.toUser)
		{

		}
		else {//줍는 아이템 
			if (!ScriptManager.isShowing) {
				StartCoroutine (manager.getIt (txt, data.num));
				manager.getAudioClip (ac);
			}
		}
	}

	public void purchaseDetail(int a){
		if (a == 1 && (Status.money >= data.price)) {
			data.location = (int)ItemPosition.toUser;
			this.gameObject.SetActive (false);
			transform.localPosition = dormPos;
			Status.money -= data.price;
			dh.enabled = true;
			GameObject.Find ("Script Manager").GetComponent<SelectStage> ().updateCoin ();
		} else {
			return;
		}
	}
}

