using UnityEngine;
using UnityEditor;//for textAsset
using System.Collections;
using System;

public class JsonReader : MonoBehaviour {
	public Word[] w;
	public Item[] it;

	public void getWordSheet()
	{
		TextAsset t = (TextAsset)AssetDatabase.LoadAssetAtPath("Assets/Resource/etc/wordSheet.txt", typeof(TextAsset));

		if (t == null)
		{//파일 로드가 안 된 경우
			Debug.Log("wordSheet can't be loaded");
		}

		//배열인 json 데이터 구조를 읽어들인다.
		string tempData = "{\"Items\":" + t.text + "}";
		w = JsonHelper.FromJson<Word>(tempData);
		if (w == null)// if it cannot change string to object
			Debug.Log("Can't make object");

	}

	public void getItemSheet()
	{
		TextAsset t1 = (TextAsset)AssetDatabase.LoadAssetAtPath("Assets/Resource/etc/itemSheet.txt", typeof(TextAsset));
		if (t1 == null)
		{//파일 로드가 안 된 경우
			Debug.Log("itemSheet can't be loaded");
		}

		//배열인 json 데이터 구조를 읽어들인다.
		string tempData = "{\"Items\":" + t1.text + "}";
		it = JsonHelper.FromJson<Item>(tempData);
		if (it == null)// if it cannot change string to object
			Debug.Log("Can't make object");
	}
		
}
