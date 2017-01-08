using UnityEngine;

public static class Status{//캐릭터 정보, 현재 상태 , 저장까지 구현시 필수 저장 부분 

	//variable,Initialize;
	public static short day=(short)DayOfWeek.Monday;
	public static short time=(short)TimeOfDay.Day;
	public static short nowStage=(short)stageNum.SelectStage;
	public static int money=10000;
	public static int suspiciousRate=0;
	public static short alibi=0;
	public static int reportNum=123456789;//instead of infinite

}
