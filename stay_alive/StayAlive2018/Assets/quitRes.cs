using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quitRes : MonoBehaviour {
    public GameObject menu;
   public static bool menuHide = false;
	// Use this for initialization
	void Start () {
        menu.SetActive(false);
        menuHide = false;
    }
	
	// Update is called once per frame
	void Update () {
        //if user pressed trinagle on joystick and menu is not hiddin and user didnt finish playing timer still on
        if (Input.GetButtonDown("trin")&& menuHide == true && timer.finish == false) 
        {
            menu.SetActive(false); // hide menu
            Time.timeScale = 1f; //restart timer (remove freezing)
            menuHide = false; 
     
        }
        //if user pressed trinagle on joystick and menu is hiddin and user didnt finish playing timer still on
        else if (Input.GetButtonDown("trin") && menuHide == false && timer.finish==false)
        {
            menu.SetActive(true);// show mwnu
            Time.timeScale = 0f;//freez time
            menuHide = true;
            

        }




        
        

    }
}
