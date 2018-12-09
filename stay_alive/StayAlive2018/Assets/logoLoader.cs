using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logoLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("Countdown");
	}


    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(4);
        Application.LoadLevel(1);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
