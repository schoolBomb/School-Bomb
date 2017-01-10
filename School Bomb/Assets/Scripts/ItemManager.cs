using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class ItemBasic : MonoBehaviour{
	protected Item data;

	abstract public void detail();

	void OnMouseDown(){
		detail ();
	}
}

class ItemPurchase:ItemBasic{
	public override void detail(){
		//구입아이템
			//마우스 클릭을 할시
			//Text UI가 뜬다.
			//설명 블라블라
			//“뫄뫄”를 구입하시겠습니까? 예 아니오 ->Question UI
				//예-> “뫄뫄”를 구입했습니다.
					// 소속된 곳이 바뀜.
					// 아이템 모습이 없어짐.
				//아니오-> 구입을 취소했습니다.
			//TextUI 닫힘.
	}
}

class ItemGet:ItemBasic{
	public override void detail(){
		//습득아이템
			//마우스클릭
			// TextUI가 뜬다.
			//“뫄뫄”를 습득했습니다.
			// 설명 블라블라
			//TextUI 닫힘.
	}
}

public class ItemManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

}
