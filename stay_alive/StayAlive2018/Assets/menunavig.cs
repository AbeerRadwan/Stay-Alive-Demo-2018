
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class menunavig : MonoBehaviour
{
    int index = 0;
    public int totalscenes = 2;
    public float yoffset = 10f;
    public GameObject a;
    public GameObject menu;
    public AudioSource chooseScene;
    // Use this for initialization
   

   
    void Update()
    {
         
        if (Input.GetAxis("Vertical") > 0) //take movemnt from joystick scroll
        {
            if (index < totalscenes - 1)//means pointer was down
            {
                index++;
                Vector3 position = a.transform.position;// positiont of pointer its down 
                position.y += yoffset;
                a.transform.position = position;//change positiont from down to up 

            }

        }
       
        if (Input.GetAxis("Vertical") < 0)
        {
            if (index > 0) //means pounter up
            {
                index--;
                Vector3 position = a.transform.position;
                position.y -= yoffset;
                a.transform.position = position;//poiter will go down
              
            }
        }
        
        //if the menu is not hidden and game didnt finish user can choose restart or quit
        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("pickUp")&& timer.finish==false&& quitRes.menuHide==true)
        {
           
            chooseScene.Play();
            if (index == 0)
            {
                Time.timeScale = 1f;
                Application.LoadLevel(3);//restart
            }
            else if (index == 1)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("endingScene");//quit
            }
        }

        

    }
}



