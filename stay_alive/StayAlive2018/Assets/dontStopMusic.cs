using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontStopMusic : MonoBehaviour {
    public AudioSource openingSound;    static bool AudioBegin = false;
    void Awake()
    {
        if (!AudioBegin)
        {
            openingSound.Play();
            DontDestroyOnLoad(gameObject); // to keep the sound when loading new scene
            AudioBegin = true;
        }
    }
    void Update()
    {
       
        if (Application.loadedLevelName == "scene2.1" || Application.loadedLevelName == " scene1.1 + timer + distance")
            //when the game start pause the sound
        {
            openingSound.Stop();
            AudioBegin = false;
        }
    }
}
