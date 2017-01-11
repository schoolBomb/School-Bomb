using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemBasic : MonoBehaviour{
	public Item data;
	public GameObject imageOfItem;
	protected string[] txt;
	public bool isPurchase=false;

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

		if (isPurchase) {
			StartCoroutine(manager.purchase (txt, data.num));
		} else {
			StartCoroutine(manager.getIt (txt, data.num));
		}
	}
}
//
////구입 아이템과 습득아이템의 superclass
//public abstract class ItemBasic : MonoBehaviour{
//	public Item data{ get; set; }
//	protected string[] txt;
//
//	void Start(){
//		initializeText ();
//	}
//
//	public void initializeText(){
//		txt = new string[6];
//		txt [0] = data.description;
//		txt [1] = data.name + "을(를) 구입하시겠습니까?";
//		txt [2] = "예";
//		txt [3] = "아니오";
//		txt [4] = data.name + "을(를) 구입했습니다.";
//		txt [5] = data.name + "구입을 취소했습니다.";
//	}
//
//	abstract public void detail();
//
//	void OnMouseDown(){
//		detail ();
//	}
//}
//
//class ItemPurchase:ItemBasic{//구입아이템
//	public override void detail(){
//		//마우스 클릭을 할시
//		//Text UI가 뜬다.
//		//설명 블라블라
//		//“뫄뫄”를 구입하시겠습니까? 예 아니오 ->Question UI
//		//예-> “뫄뫄”를 구입했습니다.
//		// 소속된 곳이 바뀜.
//		// 아이템 모습이 없어짐.
//		//아니오-> 구입을 취소했습니다.
//		//TextUI 닫힘.
//	}
//}
//
//class ItemGet:ItemBasic{//습득아이템
//	public override void detail(){
//		//마우스클릭
//		// TextUI가 뜬다.
//		//“뫄뫄”를 습득했습니다.
//		// 설명 블라블라
//		//TextUI 닫힘.
//	}
//}
