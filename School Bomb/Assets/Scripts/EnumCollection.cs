using UnityEngine;
using System.Collections;

public enum DayOfWeek : short{
	Monday=1,Tuesday=2,Wedesday=3,Thursday=4,Friday=5,Saturday=6,Sunday=7
}

public enum TimeOfDay : short{
	Day=0,Evening=1,Night=2
}

public enum stageNum : short{
	SelectStage=0, Shop, Lab, ClubRoom, Lobbdy, Center, Dormitory, Corridor
}

public enum ItemPosition : short{
	toStore=0,toUser=1,alreadyUsed=2
}