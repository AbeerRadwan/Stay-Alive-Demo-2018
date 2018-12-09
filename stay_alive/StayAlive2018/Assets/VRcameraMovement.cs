using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRcameraMovement : MonoBehaviour {

    public Transform vrCamera;
    public float moveSpeed = 1.0f;
    private CharacterController CharCont;

    // Use this for initialization
    void Start()
    {

        CharCont = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

                
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);

            CharCont.SimpleMove(forward * moveSpeed * Time.deltaTime);

        
    }
}
