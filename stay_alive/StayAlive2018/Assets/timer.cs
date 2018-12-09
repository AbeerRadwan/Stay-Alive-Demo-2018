using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timer : MonoBehaviour {
    public static bool flag ;
    public static int timeLeft = 45;
    public Text countdownText;
    public Image image;
    public static bool finish = false;
    public GameObject firep;
    public Image image2;
    public GameObject rest;
    public static int score=0;
    AudioSource end;
    GameObject kitchen;
    public Camera camera;
   
 
    // Use this for initialization
    void Start()
    {
        //restting timer and flags each time the scene is loaded
        StartCoroutine("LoseTime");
        timeLeft = 45;
        flag = false;
        finish = false;
        score = 0;
      
      
    }
    
    // Update is called once per frame
    void Update()
    {
        //timer updating 
        countdownText.text = ("Time Left = " + timeLeft);
        //********************************************************************************************
        //if timer is done = 0 and user didnt use the correct object
        if (timeLeft <= 0 && flag==false )
        {
            finish = true;//finishing game flag
            Destroy(firep, 0.1f);//finished scene dystroy the fire

            //take user input after finishing scene to view score
            if ((Input.GetKeyDown(KeyCode.B)||Input.GetButtonDown("trin")) && finish == true) 
            {
               
                SceneManager.LoadScene("score");
            }

            //hide all scene objects except first layer which is UI (notifcation of lose)
          camera.cullingMask = (1 << LayerMask.NameToLayer("UI"));

            //stop timer
            StopCoroutine("LoseTime");
            countdownText.text = "";
           //hide objects
            rest.SetActive(false);
            image2.enabled = true;
       

        }//losing + time finished

        //********************************************************************************************
        //if timer isn't done > 0  or 0 and user used the correct object
        else if (timeLeft >= 0 && flag == true)
        {
            finish = true;//finishing game flag
            StartCoroutine("seeFire");//start timer to see the reaction after turning off fire              

        }
        
    }

    IEnumerator seeFire()
    {
        yield return new WaitForSeconds(2);
       
        if ((Input.GetKeyDown(KeyCode.B) || Input.GetButtonDown("trin")) && finish == true)
        {
            SceneManager.LoadScene("score");
        }
        camera.cullingMask = (1 << LayerMask.NameToLayer("UI"));
        StopCoroutine("LoseTime");
        countdownText.text = " ";
        rest.SetActive(false);
        Destroy(firep, 0.1f);
        image.enabled = true;//show notification of winning
     
    }
    //winning 
    //**********************************************************************************************
    IEnumerator LoseTime()
    {
        while (true)
        {   //timer will move 1 second at a time
            yield return new WaitForSeconds(1);
            timeLeft--;
            
        }
    }

    
}

