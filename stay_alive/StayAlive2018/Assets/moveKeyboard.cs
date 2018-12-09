using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moveKeyboard : MonoBehaviour {
    float sensitivityX=0.8f;
    float sensitivityY=0.8f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("horizontal") * sensitivityX;
        float deltaY = Input.GetAxis("vertical") * sensitivityY;
        Vector3 targetPostion = new Vector3(deltaX, deltaY, transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetPostion), .1f);
    }
}
