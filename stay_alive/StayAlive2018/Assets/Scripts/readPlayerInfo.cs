using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System;
using UnityEngine.UI;
using System.IO;

public class readPlayerInfo : MonoBehaviour
{
    public Text name1, name2, name3, name4, name5, name6, name7, name8, name9, name10;
    public Text score1, score2, score3, score4, score5, score6, score7, score8, score9, score10;
    List<Text> nameList = new List<Text>();
    List<Text> scoreList = new List<Text>();

    private string conn, SQLquery;
    private string conn2, SQLquery2;
    IDbConnection dbconn, dbconn2; //connection
    IDbCommand dbcmd, dbcmd2; //for commands
    int counter = 0;
    int counterlist = 1;

    // Use this for initialization
    void Start()
    {
        try { 
        nameList.Add(name1); scoreList.Add(score1);
        nameList.Add(name2); scoreList.Add(score2);
        nameList.Add(name3); scoreList.Add(score3);
        nameList.Add(name4); scoreList.Add(score4);
        nameList.Add(name5); scoreList.Add(score5);
        nameList.Add(name6); scoreList.Add(score6);
        nameList.Add(name7); scoreList.Add(score7);
        nameList.Add(name8); scoreList.Add(score8);
        nameList.Add(name9); scoreList.Add(score9);
        nameList.Add(name10); scoreList.Add(score10);


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



        dbconn = new SqliteConnection("URI=file:" + conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT count(ID) FROM PlayerInformation";
        dbcmd.CommandText = sqlQuery;
        string name, score;
        int IDs = 0;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            IDs = reader.GetInt32(0);
            if (IDs > 10)
            {

                dbcmd = dbconn.CreateCommand();
                sqlQuery = "delete from PlayerInformation Where ID not IN(select ID from PlayerInformation order by cast(Score as int) DESC Limit 10);";
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteReader();

                dbcmd = dbconn.CreateCommand();
                sqlQuery = "select Name, Score from PlayerInformation order by cast(Score as int) DESC Limit 10;";
                dbcmd.CommandText = sqlQuery;
                reader = dbcmd.ExecuteReader();

                while (reader.Read())
                {
                    name = reader.GetString(0);
                    score = reader.GetString(1);
                    Debug.Log("  name =" + name + "  " + score);
                    nameList[counter].text = (counterlist + " ." + name);
                    scoreList[counter].text = (counterlist + " ." + score);

                    counter++;
                    counterlist++;
                }
            }

            if (IDs <= 10)
            {

                dbcmd = dbconn.CreateCommand();
                sqlQuery = "select Name, Score from PlayerInformation order by cast(Score as int) DESC;";
                dbcmd.CommandText = sqlQuery;
                reader = dbcmd.ExecuteReader();
                while (reader.Read())
                {
                    name = reader.GetString(0);
                    score = reader.GetString(1);
                    Debug.Log("  name =" + name + " score" + score);

                    nameList[counter].text = (counterlist + " ." + name);
                    scoreList[counter].text = (counterlist + " ." + score);
                    counter++;
                    counterlist++;
                }

            }

        }
        reader.Close();
        dbconn.Close();
    }
        catch (Exception e) { e.ToString(); }

    }


}




