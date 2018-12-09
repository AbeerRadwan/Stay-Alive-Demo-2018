using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("pickUp"))
        {
            SceneManager.LoadScene("scene1.1+timer+distance");
        }
        if(Input.GetButtonDown("drop"))
        {
            SceneManager.LoadScene("scene1.2");
        }
    }
}
