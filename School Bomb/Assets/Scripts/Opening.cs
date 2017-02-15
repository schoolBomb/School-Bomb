using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour {
    public float delayTime = 25;

	// Use this for initialization
	IEnumerator Start () {
        yield return new WaitForSeconds(delayTime);

        Application.LoadLevel("main");
		
	}
	
	
}
