using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLocation : MonoBehaviour {
	public float locationStrength;
	private ItemManager im;

	void Start(){
		im = GameObject.Find ("Item Manager").GetComponent<ItemManager> ();
	}

	void OnMouseDown(){//폭탄을 설치할 수 있는 오브젝트를 클릭한다.
		im.explode(locationStrength);
	}
}
