using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class extinguherA : MonoBehaviour {


    public GameObject item;

    public Transform itempos;
    public GameObject firep;
    public Transform fire;
    public Transform fireSparks;
    public Transform fireGlow;
    public Transform fireAlpha;
    public Transform itemP;
    public GameObject tempParent;
    public GameObject cube;
    public Transform guide;
    public AudioClip sound;
    AudioSource exp;
    float growthInterval; // seconds
    float growthRate;     // meters/second
    int particleDensity;   // # particles/meter

    // Use this for initialization

    private void Start()
    {
        cube.SetActive(false);
      //  an = (Animator)anime.animator;
    }
    void Update()
    {


        Vector3 directionToTarget = guide.position - itemP.position;
        float angle = Vector3.Angle(guide.forward, directionToTarget);
        float distance = directionToTarget.magnitude;
        //Mathf.Abs(angle) < 90
        if (distance < 1)
        {
            if (distance < 0.999599) { cube.SetActive(true); } else { cube.SetActive(false); }
            // Debug.Log("target is in front of me");
            if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("pickUp"))
            {
                Rigidbody clone;

                clone = item.GetComponent<Rigidbody>();
                clone = Instantiate(clone, transform.position, transform.rotation);
                clone.name = item.name;
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.transform.localScale = new Vector3(0.09f, 0.09f, 0.09f);
                item.transform.position = guide.transform.position;
                item.transform.parent = tempParent.transform;

            }


            else if (Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("drop"))
            {
                item.GetComponent<Rigidbody>().useGravity = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.transform.position = itempos.position;
                // item.transform.position = item.transform.position;
                item.transform.parent = item.transform;

            }

        }// pick up


        Vector3 directionToTarget2 = itemP.position - fire.position;
        float angle2 = Vector3.Angle(guide.forward, directionToTarget2);
        float distance2 = directionToTarget2.magnitude;
        //Mathf.Abs(angle) < 90
        if (distance2 < 1.5)
        {
            // Debug.Log("fireeeeeeeeeeeeeeeeeeeeeeee is in front of me");
            if (Input.GetKeyDown(KeyCode.D)||Input.GetButtonDown("drop"))
            {
                Debug.Log("boioooooooooooooooooooooooooom");

                exp = GetComponent<AudioSource>();
                exp.Play();
                fire.localScale += new Vector3(0.4f, 0.4f, 0.4f);
                fireSparks.localScale += new Vector3(0.4f, 0.4f, 0.4f);
                fireGlow.localScale += new Vector3(0.4f, 0.4f, 0.4f);
                fireAlpha.localScale += new Vector3(0.4f, 0.4f, 0.4f);







            }
        }// fire interaction


    }

    RaycastHit hit;


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked.");
    }





}
