using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	public int whereToGo=0;
	private string[] txt;
	private ItemManager usePurchase;
	private SelectStage s;
	public AudioClip ac;

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
			s.select(whereToGo);
			usePurchase.getAudioClip (ac);
		}//아니오
	}
/*
    void OnTriggerEnter2D(Collider2D other)//문에 도착했을때 
    {
        
        Debug.Log("Collided with "+ other.name);
        if (other.gameObject.tag=="Door")
        {
            Debug.Log("Collided with Door : enter");
        }
        
    }*/
    /*
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided with Door : exit");
        }
    }
    */
}
