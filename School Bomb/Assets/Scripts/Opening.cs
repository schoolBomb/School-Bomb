using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour {
    public float delayTime = 25;

	// Use this for initialization
	IEnumerator Start () {
        yield return new WaitForSeconds(delayTime);
        GetComponent<FadeObjectInOut>().FadeOut();
        yield return new WaitForSeconds(5);
        Application.LoadLevel("GameStart");
	}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel("GameStart");
        }
    }
	
	
}
