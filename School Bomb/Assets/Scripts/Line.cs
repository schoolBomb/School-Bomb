using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

	private LineRenderer line;

	void OnTriggerEnter2D(Collider2D other)
	{
		line = GetComponent<LineRenderer>();
		line.SetPosition(1, other.transform.localPosition);
		line = null;
//		other.GetComponent<Bomb>().bc.combine(1, 2);
	}
}
