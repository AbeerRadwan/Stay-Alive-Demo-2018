using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScene : MonoBehaviour {

	
	// Update is called once per frame
	public void changeSCene (int secne) {
        Application.LoadLevel(secne);
	}
}
