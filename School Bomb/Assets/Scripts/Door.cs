using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	private string[] txt;
	private ItemManager usePurchase;
	private SelectStage s;
	void Start(){
		usePurchase = GameObject.Find ("Item Manager").GetComponent<ItemManager> ();

		txt = new string[4];
		txt [0] = "";
		txt [1] = "나가시겠습니까? ";
		txt [2] = "예";
		txt [3] = "아니오";
	
		s = GameObject.Find ("Script Manager").GetComponent<SelectStage> ();
	}

	void OnMouseDown(){
		StartCoroutine (usePurchase.purchase(txt,-1,open));
	}

	public void open(int a){
		if(a==1){//예
			//selectStage 등장
			s.select(0);
		}//아니오
	}
}
