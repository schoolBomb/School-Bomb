using System;
using System.Collections;

[Serializable]//직렬화
public struct Word{//대사 출력용 구조체  
	//데이터만 있으므로 구조체로 선언했다.
	public int location;
	public int num;
	public string name;
	public string isQuestion;
	public int day;
	public int time;
	public string sentence;
}

[Serializable]
public struct Item{//아이템 정보 
	public int name;
	public string description;
	public ArrayList bomb;
	public int location;
}