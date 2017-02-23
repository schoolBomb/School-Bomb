using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public int id;//id용 넘버
	public string name;//이름
	public int strength;//위력
	public string description;//설명
	public bool isComplete = false;

	private SpriteRenderer spriteRend;//모습
	private BoxCollider2D collid;

	void Start(){
		collid = GetComponent<BoxCollider2D> ();
		spriteRend = GetComponent<SpriteRenderer> ();
	}

	public void offSpriteAndCollid(bool onOff){
		collid.enabled = onOff;
		spriteRend.enabled = onOff;
	}
}
