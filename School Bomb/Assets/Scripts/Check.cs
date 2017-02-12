using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour {
	public GameObject[] npc;
	public BombLocation bl;
	public Sprite[] professor;

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
	}
}
