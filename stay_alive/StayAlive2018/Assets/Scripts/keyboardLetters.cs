using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class keyboardLetters : MonoBehaviour
{
    public InputField txt = null;
    int wordInex = 0;
    string alphabet;
    string word = null;
    private string conn, SQLquery;
    IDbConnection dbconn; //connection
    IDbCommand dbcmd; //for commands

    public void alphabetFunction(string alphabet)
    {

        if (alphabet.Equals("null"))
        {
            word = null;
            txt.text = word;
        }

        else if (alphabet.Equals("back"))
        {
            if (word.Length == 0) { }
            else
            {
                wordInex--;
                word = word.Remove(word.Length - 1); ;
                txt.text = word;
            }
        }
        /*else if (alphabet.Equals("ok"))
         {

             SceneManager.LoadScene("test_menu");
         }*/

        else
        {
            wordInex++;
            word = word + alphabet;
            txt.text = word;
        }
    }
}

