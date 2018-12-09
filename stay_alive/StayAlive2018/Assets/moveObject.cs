using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
// this script for increasing fire
public class moveObject : MonoBehaviour 
 {
    
        Animator an;
        public GameObject item;
        public GameObject cube;
        int time = (int)timer.timeLeft;
        public Transform itempos;
        public GameObject firep;
        GameObject tempObj;
        public Transform fire;
        public Transform fireSparks;
        public Transform fireGlow;
        public Transform fireAlpha;
        public Transform itemP;
        public GameObject tempParent;
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
         an = (Animator)anime.animator;
        }

        void Update()
        {


            Vector3 directionToTarget = guide.position - itemP.position;//the distance between the object and FPS
            float distance = directionToTarget.magnitude;
          
            if (distance < 1)// if im close to object
        {
            if (distance < 0.999599) { cube.SetActive(true); } else { cube.SetActive(false); }//show the arrow guide on object

            if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("pickUp")) //take input from user
            {   // make a clone of the picked object 
                Rigidbody clone;
                clone = item.GetComponent<Rigidbody>();
                clone = Instantiate(clone, transform.position, transform.rotation);
                clone.name = item.name;

                //objects scaling
                item.GetComponent<Rigidbody>().isKinematic = true;
                if (item.name == "cap008")
                {
                    item.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }
                else if (item.name == "Bottle_v1")
                {
                    item.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
                }
                else if (item.name == "fire_extinguisherA")
                {
                    item.transform.localScale = new Vector3(0.09f, 0.09f, 0.09f);

                }
                //**************************************************************************************

                //change object position from its place to the hand
                item.transform.position = guide.transform.position;
                    item.transform.parent = tempParent.transform;
                  //hand animation
                    an.SetBool("wpOn", false);
                    an.SetBool("wpMove", false);
                    an.SetBool("wpDrop", false);

                }//pickup
              //**************************************************************************************

               //take user input to drop the object if its not close to fire 
                else if (Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("drop") )
                {
                item.GetComponent<Rigidbody>().useGravity = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
                //change object position to the dropped position
                item.transform.position = itempos.position;
                item.transform.parent = item.transform;

            }//drop

            }

        //**************************************************************************************
        Vector3 directionToTarget2 = itemP.position - fire.position;// distance between fire and FPS
        float distance2 = directionToTarget2.magnitude;
       
        if (distance2 < 1.5)//if user close to fire 
        {
            //if user dropped object
            if (Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("drop"))
            {
                //first change object position from hand to fire
                item.transform.position = new Vector3(0.94133f, 0.018655f, 0.005189f);
                item.GetComponent<Rigidbody>().useGravity = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.transform.position = itempos.position;
                item.transform.parent = item.transform;

                //explosion sound on 
                exp = GetComponent<AudioSource>();
                exp.Play();

               //increse fire
                fire.localScale += new Vector3(0.4f, 0.4f, 0.4f);
                fireSparks.localScale += new Vector3(0.4f, 0.4f, 0.4f);
                fireGlow.localScale += new Vector3(0.4f, 0.4f, 0.4f);
                fireAlpha.localScale += new Vector3(0.4f, 0.4f, 0.4f);






            }
        }//drop with fire interaction


        }//end of update



    }//end of class

  
  