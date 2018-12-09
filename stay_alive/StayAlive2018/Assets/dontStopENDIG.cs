using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontStopENDIG : MonoBehaviour {
    public AudioSource a;
    public GameObject sc;
    // Use this for initialization
    void Awake () {
        DontDestroyOnLoad(a);
    }
	
	// Update is called once per frame
	void Update () {
       
        if (Input.GetButtonDown("pickUp"))
        {
            sc.SetActive(false);

            SceneManager.LoadScene("test_menu");
            a.Stop();
        }
        if (Input.GetButtonDown("trin"))
        {
            sc.SetActive(false);
            SceneManager.LoadScene("Layout Groups");
            a.Stop();
        }
        if (Input.GetButtonDown("drop"))
        {
            SceneManager.LoadScene("endingScene");
        }
    }
}
