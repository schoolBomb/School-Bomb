using UnityEngine;

public static class Status{//캐릭터 정보, 현재 상태 , 저장까지 구현시 필수 저장 부분 

	//variable,Initialize;
	public static short day=(short)DayOfWeek.Monday;
	public static short time=(short)TimeOfDay.Day;
	public static short nowStage=(short)stageNum.SelectStage;
	public static int money=30000;
	public static int suspiciousRate=0;
	public static short alibi=0;
	public static int reportNum=123456789;//instead of infinite
	public static bool haveBomb=false;
	public static int paper = 0;

	public static void changeTime(){
		//그일이 끝난 후 selectStage로 돌아올 때 
		//time을 올린다.
		if (Status.time == 3) {//만약 time이 3일경우, time=1, day=+1
			Status.time = 1;
			if (Status.day < 7)//이때 day는 7까지;;
				Status.day++;
		}
		else {
			Status.time++;
		}
	}

}
