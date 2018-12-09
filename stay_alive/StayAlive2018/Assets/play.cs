using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class play : MonoBehaviour
{
    int score1;
    public Text scorePoint;
    public Text txqt;
    // Use this for initialization


    void Start()
    {
        score1 = (int)timer.score;
        Debug.Log(timer.score + "scoreeeeeeeee");
        //txqt.text ="Your score is : " + timer.score.ToString();
        txqt.text = ("Your score is :");

    }
    // Update is called once per frame
    void Update()
    {

        score1 = (int)timer.score;
        //txqt.text = "Your score is : " + timer.score.ToString();
        scorePoint.text = ("" + score1);

    }
}

