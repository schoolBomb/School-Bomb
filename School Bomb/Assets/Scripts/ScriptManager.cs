using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour {
	private JsonReader j;
	public ArrayList wordList;

	// Use this for initialization
	void Start () {
		j = GetComponent<JsonReader> ();

	}

	public void findWord(short day, short time, short nowStage){

	}
}
