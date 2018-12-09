using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System;
using UnityEngine.UI;
using System.IO;

public class storePlayerScore : MonoBehaviour
{
    private string conn, SQLquery;
    IDbConnection dbconn; //connection
    IDbCommand dbcmd; //for commands
    public Text info;
    string ScorePoint = "0";

    // Use this for initialization
    void Start()
    {
        try { 
        if (Application.platform != RuntimePlatform.Android)
            conn =  Application.dataPath + "/Plugins/StayAlivePlayer.s3db"; //Path to database.

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

       


        IDbConnection dbcon = new SqliteConnection("URI=file:" + conn);
        dbcon.Open();
        IDbCommand dbcmd;
        IDataReader reader;
        dbcmd = dbcon.CreateCommand();
        /* using (dbconn = new SqliteConnection(conn))
         {*/
        if (info.text != null)
        {

            dbcmd = dbcon.CreateCommand();

            ScorePoint = timer.score.ToString();
            int IDs = 000000000000000;
            string name, score;

            string ids = "select max(ID) from PlayerInformation ;";
            dbcmd.CommandText = ids;
            // dbcmd.ExecuteScalar();

            reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                IDs = reader.GetInt32(0);
               
            }
            reader.Close();
            dbcon.Close();


            using (SqliteConnection connection = new SqliteConnection())
            {
                connection.ConnectionString = "URI=file:" + conn;
                connection.Open();
                using (SqliteCommand command = new SqliteCommand(connection))
                {
                    command.Parameters.Add("s", DbType.String).Value = ScorePoint;
                    command.Parameters.Add("ids", DbType.Int32).Value = IDs;
                    command.CommandText =
                        "update  PlayerInformation set score = :s where ID=:ids";

                    command.ExecuteNonQuery();
                }
                connection.Close();

            }

            Debug.Log("score+++++++++++++++++++++++++++++++++++++++++++++++" + ScorePoint);

        }
    }
        catch (Exception e) { e.ToString(); }
    }



}

