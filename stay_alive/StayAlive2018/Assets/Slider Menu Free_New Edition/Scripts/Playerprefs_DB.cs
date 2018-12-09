using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerprefs_DB : MonoBehaviour {
    public static InputField name;
     static string playerName;
    // public int score;


    public void saveNmae()
    {
        playerName = name.text.ToString();
        PlayerPrefs.SetString("playerName", playerName);

    }
    public void savescore()
    {

        //    PlayerPrefs.SetInt("score", score);

    }
    public static void loadInfo()
    {
        PlayerPrefs.GetString("playerName");

        //  PlayerPrefs.GetInt("score");

    }



}
