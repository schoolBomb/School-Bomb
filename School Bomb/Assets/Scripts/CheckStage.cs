using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStage : MonoBehaviour {

	//1.npc를 받는다.
	public GameObject[] npc;

	public void checkNPC(){//npc별 시간 또는 요일에 따라 나타남 결정
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
	
	}
}
