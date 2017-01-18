﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemBasic : MonoBehaviour{
	public Item data;
	public GameObject imageOfItem;
	protected string[] txt;
//	public bool isPurchase=false;

	void Start(){
		initializeText ();
	}

	public void initializeText(){
		txt = new string[6];
		txt [0] = data.description;
		txt [1] = data.name + "을(를) 구입하시겠습니까? ";
		txt [2] = "예";
		txt [3] = "아니오";
		txt [4] = data.name + "을(를) 얻었습니다.";
		txt [5] = data.name + "구입을 취소했습니다.";
	}

	//abstract public void detail();

	void OnMouseDown(){
		ItemManager manager = GameObject.Find ("Item Manager").GetComponent<ItemManager> ();

		if (data.location == (int)ItemPosition.toStore)
		{//상점 아이템 
			StartCoroutine(manager.purchase(txt, data.num, purchaseDetail));
		}
		else if (data.location == (int)ItemPosition.toUser)
		{

		}
		else {//줍는 아이템 
			StartCoroutine(manager.getIt (txt, data.num));
		}
	}

	public void purchaseDetail(int a){
		
		if(a==1) {
			data.location = (int)ItemPosition.toUser;
			this.gameObject.SetActive(false);
		}
	}
}

