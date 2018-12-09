using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endMusic : MonoBehaviour {
    int time = timer.timeLeft;

    public AudioSource a; static bool AudioBegin = false;
   
    void Update()
    {
        if (!AudioBegin)
        {
            if (time == 0)
            {
                a.Play();
                DontDestroyOnLoad(a);
               // AudioBegin = true;
            }

        }

        /*if (Application.loadedLevelName == "scene2.1" || Application.loadedLevelName == " scene1.1 + timer + distance")
        {
            openingSound.Stop();
            AudioBegin = false;
        }*/
    }
}
