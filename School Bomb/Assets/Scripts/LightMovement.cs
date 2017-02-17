using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour {

	UserWalk user;

	// Use this for initialization
	void Start()
	{


	}

	// Update is called once per frame
	void FixedUpdate()
	{





	}
	public void changeSpeed()
	{
		user = GameObject.FindGameObjectWithTag("Player").GetComponent<UserWalk>();
		if (user.move == true)//player가 숨어있지 않을때
		{
			Debug.Log("Detected by light!");
			user.isTracing = true;
		}
		else//player가 상자나 문에 숨어있을때
		{
			Debug.Log("Not Detected by light!");
		}

	}



}