using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this script for turn off fire
public class moveSand : MonoBehaviour
{

    public GameObject item;
    public GameObject tempParent;
    public Transform guide;
    public Transform itemP;
    public Transform itempos;
    public GameObject firep;
    public GameObject cube;
    public Transform fire;
    Animator an;
    // Use this for initialization


    void Start()
    {
        cube.SetActive(false);
        item.GetComponent<Rigidbody>().useGravity = false;
        an = (Animator)anime.animator;
    }



    void Update()
    {


        Vector3 directionToTarget = guide.position - itemP.position;//the distance between the object and FPS
        float distance = directionToTarget.magnitude;

        if (distance < 1) // if im close to object
        {


            if (distance < 0.999995) { cube.SetActive(true); }else { cube.SetActive(false); } //show the arrow guide on object
            
           
            if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("pickUp")) //take input from user
            {   // make a clone of the picked object 
                Rigidbody clone;
                clone = item.GetComponent<Rigidbody>();
                clone = Instantiate(clone, transform.position, transform.rotation);
                clone.name = item.name;

                //objects scaling
                if (item.name == "fire_extinguisherC")
                {
                  
                    item.transform.localScale = new Vector3(0.09f, 0.09f, 0.09f);
                   
                }
                if(item.name== "bakingSoda")
                {
                    item.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }

                if (item.name == "panCover")
                {
                    item.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                }
                //**************************************************************************************

                //change object position from its place to the hand 
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.transform.position = guide.transform.position;
                item.transform.parent = tempParent.transform;
                //hand animation
                if (item.name != "fire_extinguisherC")
                {
                    an.SetBool("wpOn", true);
                    an.SetBool("wpMove", false);
                    an.SetBool("wpDrop", false);
                }
            }//pickup
            //**************************************************************************************
            //take user input to drop the object if its not close to fire 
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("drop"))
            {
               //change object position to the dropped position
                item.GetComponent<Rigidbody>().useGravity = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.transform.position = itempos.position;
                item.transform.parent = item.transform;
               
                
            }//drop

        }

        //**************************************************************************************
        Vector3 directionToTarget2 = itemP.position - fire.position; // distance between fire and FPS
        float distance2 = directionToTarget2.magnitude;
       
        if (distance2 < 1.5)//if user close to fire 
        {
           
            if (Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("drop"))//if user dropped object
            {
                //first change object position from hand to fire
                item.transform.position = new Vector3(0.94133f, 0.018655f, 0.005189f);
                item.GetComponent<Rigidbody>().useGravity = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.transform.position = itempos.position;
                item.transform.parent = item.transform;
               //then turn off fire
                Destroy(firep, 0.1f);
               
                //check timer
                int time = (int)timer.timeLeft;
                //if user turned off fire before time is done
                if (time > 0)
                {

                    timer.flag = true;//flag for finishing
                    timer.score = time * 100;//calculate score depending on time
                  
                }  

            }
        }// drop with fire interaction



    }//end of update


}//end of class