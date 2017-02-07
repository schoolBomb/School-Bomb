using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WalkSceneSelect : MonoBehaviour {

    static SceneManager Instance;

	// Use this for initialization
	void Start () {
        /*
		if(Instance != null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        */
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Keypad0))
        {
            Debug.Log("PlayerWalk");
            SceneManager.LoadScene("PlayerWalk");
            
            
        }
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            Debug.Log("PlayerWalk_server");
            SceneManager.LoadScene("PlayerWalk_server");
        }
    }
}
