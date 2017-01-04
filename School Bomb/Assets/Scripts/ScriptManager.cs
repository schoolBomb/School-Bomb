using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


//word script를 필요시 불러오는작업을 한다. 
public class ScriptManager : MonoBehaviour {
	private JsonReader j;
	Word[] w;
	//Dictionary wordDic=new Dictionar
//	Node<short> tree;

	// Use this for initialization
	void Start () {
		j = GetComponent<JsonReader> ();
		w = j.w;
		//findWord (2, 1, 1);
	}

	public void findWord(short nowStage,short day, short time){//장소 날짜 시간에 맞는 word list를 뽑는다 s
		var result = 
			from word in w
			where (word.location == nowStage) && (word.day == day) && (word.time == time)
			select word;

		foreach (var word in result) {
			Debug.Log (word.location+" "+word.day+" "+word.time+word.sentence);
		}

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

