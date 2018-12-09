using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class pointerNavigate : MonoBehaviour
{
    int index = 0;
    public int totalscenes = 2;
    public float yoffset = 10f;
    public GameObject a;
    public AudioSource chooseScene; 
 

  
    void Update()
    {

        
        if(Input.GetAxis("Horizontal")>0) //take input movment from joystick >0 go to the right 
        {
         if(index < totalscenes - 1) 
            { 
         index++; // im at scene 1 now
        Vector3 position = a.transform.position; // get pointer position which is on scene1
        position.x += yoffset; //increasing y to move right
        a.transform.position = position; // update pointer position to be in scene 2

          }
         }
        
        if (Input.GetAxis("Horizontal") < 0)//take input movment from joystick >0 go to the left 
        {
         if (index >0)
        {
          index--;
         Vector3 position = a.transform.position;
         position.x -= yoffset;
         a.transform.position = position;
         }
         }
        
        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("pickUp")) // if user choose scene go to the scene with pointer position
            {
            chooseScene.Play();
                if (index == 0)
                {

                Application.LoadLevel(4);
               
                }
                else if (index == 1)
                {
                Application.LoadLevel(5);
                   
                }
            }
        
    }
}

    

