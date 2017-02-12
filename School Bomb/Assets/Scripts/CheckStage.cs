//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class CheckStage : MonoBehaviour {
//	public GameObject[] box;
//	public GameObject[] cam;
//	public GameObject[] door;
//	public GameObject[] xxx;
////	public GameObject[] jabda;
//
//	//1.npc를 받는다.
//	public GameObject[] npc;
//
//	public void checkNPC(int num){//npc별 시간 또는 요일에 따라 나타남 결정
//		NPC[] np=new NPC[npc.Length];
//
//		for (int i = 0; i < npc.Length; i++)
//		{
//			np[i] = npc[i].GetComponent<NPC>();
//			npc[i].SetActive(false);//2. 만약 이게 적당한 시간대가 아니라면 //->false
//
//			for (int j = 0; j < np[i].time.Length; j++)
//			{
//				if (np[i].time[j] == Status.time) npc[i].SetActive(true);//적당한 시간대라면 true
//			}
//
//		}
//		if(num==(int)stageNum.Lab){
//			corLab ();
//		}
//		else if(num==(int)stageNum.ServerRoom){
//			corSer ();
//		}
//	}
//
//	private void corLab(){
//		if (Status.time == (int)TimeOfDay.Day || Status.time == (int)TimeOfDay.Evening) {
//			for (int i = 0; i < box.Length; i++)	box [i].SetActive (false);
//			for (int i = 0; i < cam.Length; i++)	cam [i].SetActive (false);
//			for (int i = 0; i < door.Length; i++)	door [i].SetActive (false);
//			Debug.Log (npc.Length);
//			Debug.Log (door.Length+xxx.Length);
////			xxx [0].transform.localPosition = new Vector3 (-18.51f, 0, -1);
////			xxx [2].transform.localPosition = new Vector3 (-25.3f, 1.0f, -1);
////			xxx [1].SetActive (true);
////			xxx [3].SetActive (true);
////			xxx [4].SetActive (false);
//		}
//		else{
//			box [0].transform.localPosition = new Vector3 (-17.69f, 1.7f, 5);
//			box [1].transform.localPosition = new Vector3 (13.77f, 1.7f, 5);
//
//			cam [0].transform.localPosition = new Vector3 (-17.81f, 5.67f, 5);
//			cam [1].transform.localPosition = new Vector3 (-0.71f, 5.67f, 5);
//			cam [2].transform.localPosition = new Vector3 (-13.79f, 5.67f, 5);
//
//			door [0].transform.localPosition = new Vector3 (-0.65f, 2.31f, 5);
//			door [1].transform.localPosition = new Vector3 (23.57f, 2.31f, 5);
//
//			for (int i = 0; i < box.Length; i++)	box [i].SetActive (true);
//			for (int i = 0; i < cam.Length; i++)	cam [i].SetActive (true);
//			for (int i = 0; i < door.Length; i++)	door [i].SetActive (true);
//
////			jabda [0].transform.localPosition = new Vector3 (-12.9f, 0.5f, -1);
////			jabda [2].transform.localPosition = new Vector3 (-22, 1.0f, -1);
////			jabda [1].SetActive (false);
////			jabda [3].SetActive (false);
////			jabda [4].SetActive (true);
//			//경비 움직임 수정
//			npc[2].gameObject.transform.localPosition=new Vector3(-25,2,5);
//			npc [2].gameObject.GetComponent<PatrolWalk> ().endPos = 2.5f;
//			npc[3].gameObject.transform.localPosition=new Vector3(21,2,5);
//			npc [3].gameObject.GetComponent<PatrolWalk> ().endPos = 0;
//		}
//	}
//	private void corSer(){
//	}
//}
