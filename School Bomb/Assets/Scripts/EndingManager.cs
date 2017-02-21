using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour {

    public GameObject[] endings;
    
    void Start()
    {
        int x = PlayerPrefs.GetInt("EndingNumber", -1);
        endings[x].SetActive(true);
    }
}
