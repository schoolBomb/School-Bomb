using System;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;



//word script를 필요시 불러오는작업을 한다. 
public class ScriptManager : MonoBehaviour {
	private JsonReader j;
	Word[] w;

	//variable for UI
	public GameObject TextBackGround;
	public Text nameText;//name UI
	public Text senteceText;//sentence UI

	// Use this for initialization
	void Start () {
		j = GetComponent<JsonReader> ();
		w = j.w;
	}

	void Update(){

	}

	public void findWord(short nowStage,short day, short time){//장소 날짜 시간에 맞는 word list를 뽑는다 
		//C# Linq 사용, DB 랑 비슷함
		var result = 
			from word in w
			where (word.location == nowStage) && (word.day == day) && (word.time == time)
			select word;

		//for test
		foreach (var word in result) {
			Debug.Log (word.location+" "+word.day+" "+word.time+word.sentence);
		}

	}

	public void printInUI(short nowStage,short day, short time){
		
//		1. 데이터를 추린다. ->findWord
		findWord (nowStage, day, time);
//		2. TextUI가 켜진다.

//		3. Text가 보여진다.
//		4. enter 또는 마우스 클릭을 한다.(Update문에 올리고)
//			1. 만약 대사가 남아있는 경우 다음 대사로 바꾼다.(달칵거리는 소리 출력?)
//			2. TextUI가 꺼진다.
	}

	//	public void makeTree(T nodeType){
	////		for (short i = 0; i < 8; i++) {
	////			tree.addChild (i);
	////
	////		}
	//
	////		for (int i = 0; i < w.Length; i++) {
	////			
	////		}
	//	}


	//class Node<T>{
	//	T value;
	//	ArrayList children;
	//
	//	public Node(T i){
	//		value = i;
	//	}
	//
	//	public Node(Word w){
	//		children = new ArrayList ();
	//
	//		for (int i = 0; i < 8; i++) {//location
	//			children.Add(new Node<short>((short)i));
	//			for (int j = 0; j < 8; j++) {//day
	//				for (int k = 0; k < 4; k++) {//time
	//
	//				}
	//			}
	//		}
	//	}
	//
	//	public void addChild(T data){
	//		if (children == null) {//initialize
	//			children = new ArrayList ();
	//		}
	//			
	//	}
	//}
	//struct Tuple<T, U, W> : IEquatable<Tuple<T,U,W>>
	//{
	//	readonly T first;
	//	readonly U second;
	//	readonly W third;
	//
	//	public Tuple(T first, U second, W third)
	//	{
	//		this.first = first;
	//		this.second = second;
	//		this.third = third;
	//	}
	//
	//	public T First { get { return first; } }
	//	public U Second { get { return second; } }
	//	public W Third { get { return third; } }
	//
	//	public override int GetHashCode()
	//	{
	//		return first.GetHashCode() ^ second.GetHashCode() ^ third.GetHashCode();
	//	}
	//
	//	public override bool Equals(object obj)
	//	{
	//		if (obj == null || GetType() != obj.GetType())
	//		{
	//			return false;
	//		}
	//		return Equals((Tuple<T, U, W>)obj);
	//	}
	//
	//	public bool Equals(Tuple<T, U, W> other)
	//	{
	//		return other.first.Equals(first) && other.second.Equals(second) && other.third.Equals(third);
	//	}
	//}
}

