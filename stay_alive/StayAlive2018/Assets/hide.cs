using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class hide : MonoBehaviour {

    public Image images;

	// Use this for initialization
	void Start () {
        images = GetComponent<Image>();
    images.SetEnabled(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
