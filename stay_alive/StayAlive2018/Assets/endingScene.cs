using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("Countdown");
    }
    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(6);
        Application.Quit();
    }
    // Update is called once per frame
    void Update () {
        
               
    }

}

