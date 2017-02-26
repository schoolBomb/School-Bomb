﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour {
	public GameObject[] npc;
	public BombLocation bl;
	public Sprite[] professor;

	string[] s;

	public void checkNPC(int num){//npc별 시간 또는 요일에 따라 나타남 결정
		NPC[] np=new NPC[npc.Length];

		if (num == 10) {
			npc [0].SetActive (false);
			npc [1].SetActive (false);
			npc [2].SetActive (true);
			npc [3].SetActive (true);

		} else if (num == 11) {
			npc [0].SetActive (true);
			npc [1].SetActive (true);
			npc [2].SetActive (false);
			npc [3].SetActive (false);
		} else {
			for (int i = 0; i < npc.Length; i++)
			{
				np[i] = npc[i].GetComponent<NPC>();
				npc[i].SetActive(false);//2. 만약 이게 적당한 시간대가 아니라면 //->false

				for (int j = 0; j < np[i].time.Length; j++)
				{
					//만약 서버실 복도라면 
					if (np[i].time[j] == Status.time ){
						npc[i].SetActive(true);//적당한 시간대라면 true
					}
				}
			}

		}


		if (num == (int)stageNum.Lab) {
			if (!(Status.day == (int)DayOfWeek.Saturday || Status.day == (int)DayOfWeek.Sunday)) {
				npc [0].GetComponent<SpriteRenderer> ().sprite = professor [(int)Status.day - 1];
				np [0].scriptNum = Status.day - 1;
			} else {
				npc [0].SetActive (false);
				np [0].scriptNum = Status.day - 1;
			}
		}

		bombLocationCheck ();
	}

	public void bombLocationCheck(){
		if (Status.day == (int)DayOfWeek.Saturday || Status.day == (int)DayOfWeek.Sunday) {
			if ((Status.nowStage == 2) || (Status.nowStage == 7) || (Status.nowStage == 5) || (Status.nowStage == 8)) {
				bl.enabled = true;
				StartCoroutine (bl.glowingIt ());
			}
		}
	}

	public void writing(){

		s = new string[4];
		s [0] = "기숙사에 들어왔다.";
		s [1] = "그냥 논문 쓸까…";
		s [2] = "쓰자.";
		s [3] = "개뿔, 폭탄이나 만들어.";

		ItemManager im = GameObject.Find ("Item Manager").GetComponent<ItemManager> ();
		StartCoroutine (im.purchase (s, -1,2, detail));
	}

	private void detail(int a){
		if (a == 1) {
			Status.paper += 3;
			Status.day += 1;
			if(Status.day<=(int)DayOfWeek.Sunday) GameObject.Find ("Script Manager").GetComponent<SelectStage> ().select (0);
			//			ItemManager im = GameObject.Find ("Item Manager").GetComponent<ItemManager> ();
			//
			//			s = new string[4];
			//			s [0] = "(!!!!!하루가 지났어?!)";
			//
			//			StartCoroutine (im.getIt(s,-1));
		}
	}
}
