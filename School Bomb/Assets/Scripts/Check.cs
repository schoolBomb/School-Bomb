using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour {
	public GameObject[] npc;
//	public GameObject[] box;
//	public GameObject[] cam;
//	public GameObject[] door;
//	public GameObject[] etc;

	public void checkNPC(int num){//npc별 시간 또는 요일에 따라 나타남 결정
		NPC[] np=new NPC[npc.Length];
//		Debug.Log (npc.Length + " " + cam.Length + " " + door.Length + " " + etc.Length);

		for (int i = 0; i < npc.Length; i++)
		{
			np[i] = npc[i].GetComponent<NPC>();
			npc[i].SetActive(false);//2. 만약 이게 적당한 시간대가 아니라면 //->false

			for (int j = 0; j < np[i].time.Length; j++)
			{
				if (np[i].time[j] == Status.time) npc[i].SetActive(true);//적당한 시간대라면 true
			}

		}
//		if(num==(int)stageNum.Lab){
//			corLab ();
//		}
//		else if(num==(int)stageNum.ServerRoom){
//			corSer ();
//		}
	}

//	public void corLab(){
//		if (Status.time == (int)TimeOfDay.Day || Status.time == (int)TimeOfDay.Evening) {
//			for (int i = 0; i < box.Length; i++)
//				box [i].SetActive (false);
//			for (int i = 0; i < cam.Length; i++)
//				cam [i].SetActive (false);
//			for (int i = 0; i < door.Length; i++)
//				door [i].SetActive (false);
//			Debug.Log (npc.Length + " " + cam.Length + " " + door.Length + " " + etc.Length);
//		}
//	}
//	public void corSer(){
//	}
}
