using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLocation : MonoBehaviour
{
	public float locationStrength;
	private ItemManager im;

	void Start ()
	{
		im = GameObject.Find ("Item Manager").GetComponent<ItemManager> ();
	}

	void OnMouseDown ()
	{//폭탄을 설치할 수 있는 오브젝트를 클릭한다.
		if (this.enabled == true)
			im.explode (locationStrength);
		this.enabled = false;
	}

	public IEnumerator glowingIt ()
	{
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();

		while (true) {
			for (var f = 1.0; f >= 0; f -= 0.01) {
				Color color = new Vector4 (1, (float)f, (float)f, 1);
				sr.color = color;
				yield return new WaitForSeconds (0.01f);
			}
			for (var f = 0.0; f <= 1.0; f += 0.01) {
				Color color = new Vector4 (1, (float)f, (float)f, 1);
				sr.color = color;
				yield return new WaitForSeconds (0.01f);
			}
		}
	}
}
