using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anime : MonoBehaviour {
    public static Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        /*
        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("pickUp"))
        {
            animator.SetBool("wpOn", true);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("drop"))
        {
            animator.SetBool("wpMove", true);
            animator.SetBool("wpDrop", true);
        }
        else
        {
            animator.SetBool("wpOn", false);
            animator.SetBool("wpMove", false);
            animator.SetBool("wpDrop", false);
        }*/


    }
}
