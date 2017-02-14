using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour {
	public GameObject[] npc;
	public BombLocation bl;
	public Sprite[] professor;

	string[] s;

	public void checkNPC(int num){//npc별 시간 또는 요일에 따라 나타남 결정
		NPC[] np=new NPC[npc.Length];
		for (int i = 0; i < npc.Length; i++)
		{
			np[i] = npc[i].GetComponent<NPC>();
			npc[i].SetActive(false);//2. 만약 이게 적당한 시간대가 아니라면 //->false

			for (int j = 0; j < np[i].time.Length; j++)
			{
				if (np[i].time[j] == Status.time) npc[i].SetActive(true);//적당한 시간대라면 true
			}
		}
		if (num == (int)stageNum.Lab) {
			if (Status.day != 6 || Status.day != 7) {
				npc [0].GetComponent<SpriteRenderer> ().sprite = professor [(int)Status.day-1];
				np [0].scriptNum = Status.day-1;
			}
		}

		if(bl!=null) bombLocationCheck ();
	}

	public void bombLocationCheck(){
		if (Status.time == 6 || Status.time == 7) {
			bl.enabled = true;
			StartCoroutine (bl.glowingIt ());
		} else {
			bl.enabled = false;
		}
	}
		
	public void writing(){
		
		s = new string[4];
		s [0] = "기숙사에 들어왔다.";
		s [1] = "그냥 논문 쓸까…";
		s [2] = "쓰자.";
		s [3] = "개뿔, 폭탄이나 만들어.";

		ItemManager im = GameObject.Find ("Item Manager").GetComponent<ItemManager> ();
		StartCoroutine (im.purchase (s, -1, detail));
	}

	private void detail(int a){
		if (a == 1) {
			Status.paper += 3;
			Status.day += 1;
			GameObject.Find ("Script Manager").GetComponent<SelectStage> ().select (0);
//			ItemManager im = GameObject.Find ("Item Manager").GetComponent<ItemManager> ();
//
//			s = new string[4];
//			s [0] = "(!!!!!하루가 지났어?!)";
//
//			StartCoroutine (im.getIt(s,-1));
		}
	}
}
