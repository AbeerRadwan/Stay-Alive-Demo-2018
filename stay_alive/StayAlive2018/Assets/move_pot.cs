using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_pot : MonoBehaviour
{


    public GameObject item;
    public GameObject tempParent;
    public Transform guide;
    public Transform itemP;
    public Transform itempos;
    int time = (int)timer.timeLeft;
    public GameObject firep;
    public Transform fire;
    Animator an;
    // Use this for initialization
    void Start()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        an = (Animator)anime.animator;
    }



    void Update()
    {


        Vector3 directionToTarget = guide.position - itemP.position;
        float angle = Vector3.Angle(guide.forward, directionToTarget);
        float distance = directionToTarget.magnitude;

        if (distance < 1)
        {
            Debug.Log("target is in front of me");
            if (Input.GetKeyDown(KeyCode.A)||Input.GetButtonDown("pickUp"))
            {

                Rigidbody clone;

                clone = item.GetComponent<Rigidbody>();
                clone = Instantiate(clone, transform.position, transform.rotation);
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                item.transform.position = guide.transform.position;
                item.transform.parent = tempParent.transform;
                an.SetBool("wpOn", true);
                an.SetBool("wpMove", false);
                an.SetBool("wpDrop", false);

            }

            else if (Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("drop"))
            {

                

                item.GetComponent<Rigidbody>().useGravity = true;
                item.GetComponent<Rigidbody>().isKinematic = false;

                item.transform.position = itempos.position;
                item.transform.parent = item.transform;
                //  an.SetBool("wpDrop", true);
               

            }

        }

        Vector3 directionToTarget2 = itemP.position - fire.position;
        float angle2 = Vector3.Angle(guide.forward, directionToTarget2);
        float distance2 = directionToTarget2.magnitude;


   
        //Mathf.Abs(angle) < 90
        if (distance2 < 1.5)
        {
            //Debug.Log("fireeeeeeeeeeeeeeeeeeeeeeee is in front of me");
            if (Input.GetKeyDown(KeyCode.D))
            {
            
                fire.localScale += new Vector3(0.6f, 0.5f, 0.4f);

               /* if (time > 0)
                {
                    timer.flag = true;

                }*/

                //  firep.SetActive(false);
                

            }
        }// fire interaction



    }





}