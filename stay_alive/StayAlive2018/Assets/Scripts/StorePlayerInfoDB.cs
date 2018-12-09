using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System;
using UnityEngine.UI;
using System.Data;
using UnityEngine.SceneManagement;
using System.IO;

public class StorePlayerInfoDB : MonoBehaviour
{
    private string conn, SQLquery;
    IDbConnection dbconn; //connection
    IDbCommand dbcmd; //for commands
    public Text info;
    string pName = "no name";
    public Text hint;
    // Use this for initialization
    void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
            conn = Application.dataPath + "/Plugins/StayAlivePlayer.s3db"; //Path to database.

        else
        {
            conn = Application.persistentDataPath + "/StayAlivePlayer.s3db";
            if (!File.Exists(conn))
            {
                WWW load = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "StayAlivePlayer.s3db");

                while (!load.isDone) { }

                File.WriteAllBytes(conn, load.bytes);
            }

        }


    }

    public void insertName()
    {

        try
        {

            using (dbconn = new SqliteConnection("URI=file:" + conn))
            {
                if (info.text != null && !string.IsNullOrEmpty(info.text))
                {

                    dbconn.Open(); //Open connection to the database.
                    dbcmd = dbconn.CreateCommand();

                    pName = info.text;
                    SQLquery = "INSERT INTO PlayerInformation (Name , Score) VALUES ('" + pName + "','0') ;";
                    dbcmd.CommandText = SQLquery;
                    dbcmd.ExecuteScalar();
                    dbconn.Close();
                    SceneManager.LoadScene("guide");
                }
                else
                {
                    hint.text = ("you must enter your name  ");
                }
            }
        }
        catch (Exception e) { e.ToString(); }
    }




}

