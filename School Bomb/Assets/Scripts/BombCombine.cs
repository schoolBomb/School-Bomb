using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCombine : MonoBehaviour {

	private LineRenderer line;
	private Vector3 mousePos;
	private Vector3 startPos;
	private Vector3 endPos;

	private int[] ingreLength;
	private int[] making;
	private short pointer = -1;

	public GameObject[] bombList;

	// Use this for initialization
	void Start()
	{
		makeBombList();
	}

	private void makeBombList()
	{
		ingreLength = new int[10];
		ingreLength[0] = 2;
		ingreLength[1] = 2;
		ingreLength[2] = 2;
		ingreLength[3] = 3;
		ingreLength[4] = 3;
		ingreLength[5] = 2;
		ingreLength[6] = 3;
		ingreLength[7] = 3;
		ingreLength[8] = 3;
		ingreLength[9] = 3;
		                
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0) && line)
		{
			if (line)
			{
				mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				mousePos.z = 0;
				line.SetPosition(1, mousePos);
				endPos = mousePos;
				addColliderToLine();
				line = null;
			}
		}
		else if (Input.GetMouseButton(0))
		{
			if (line)
			{
				mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				mousePos.z = 0;
				line.SetPosition(1, mousePos);
			}
		}

	}

	public void startLine(Vector3 tr)//아이템이 눌렸을 때 그리기 시작하ㄴ 함수 
	{
		if (line == null) createLine();
		line.SetPosition(0, tr);
		line.SetPosition(1, tr);
		startPos = tr;
		Debug.Log(startPos.x);

	}

	private void createLine()
	{
		line = new GameObject("Line").AddComponent<LineRenderer>();
		line.gameObject.AddComponent<Rigidbody2D>();
		line.gameObject.AddComponent<Line>();
		line.material = new Material(Shader.Find("Diffuse"));
		line.numPositions = 2;
		line.startWidth = 0.2f;
		line.endWidth = 0.2f;
		line.startColor = Color.white;
		line.endColor = Color.white;
		line.useWorldSpace = true;
	}

	private void addColliderToLine()
	{
		BoxCollider2D col = new GameObject("Collider").AddComponent<BoxCollider2D>();
//		col.gameObject.AddComponent<Rigidbody2D>();
		col.transform.parent = line.transform;
		float lineLength = Vector3.Distance(startPos, endPos);
		col.size = new Vector3(lineLength, 0.1f, 1f);
		Vector3 midPoint = (startPos + endPos) / 2;
		col.transform.position = midPoint;
		float angle = (Mathf.Abs(startPos.y - endPos.y) / (Mathf.Abs(startPos.x - endPos.x)));
		if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x))
		{
			angle *= -1;
		}
		if (angle != angle)
		{
			Destroy(line.gameObject);
		}
		else
		{
			angle = Mathf.Rad2Deg * Mathf.Atan(angle);
			col.transform.Rotate(0, 0, angle);
		}
		            
		               
	}

	public void combine(int canMakeBomb, int ingLength)
	{
		if (pointer==-1)
		{
			making = new int[ingLength];
			making[0] = canMakeBomb;
			pointer++;
		}
		else
		{
			making[pointer] = canMakeBomb;
			if ((pointer + 1) == ingLength)//재료를 다 넣은 경우 
			{
				if (making[pointer] == making[pointer - 1]) Instantiate(bombList[canMakeBomb]);
				else
				{
					//Destroy(line.gameObject);
				}
			}
			else if (making.Length == 3)
			{
				if (making[pointer] == making[pointer - 1])
				{
				}
				else
				{
					//Destroy(line.gameObject);
				}

			}
			else
			{
				//Destroy(line.gameObject);
			}
		}

	}
}
