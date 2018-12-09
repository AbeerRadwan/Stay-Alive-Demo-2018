using UnityEngine;
using System;
using System.Collections;
using System.Data;
using System.Text;
using Mono.Data.Sqlite;

public class dbAccess : MonoBehaviour {
	private string connection;
	private IDbConnection dbcon;
	private IDbCommand dbcmd;
	private IDataReader reader;
	private StringBuilder builder;

	// Use this for initialization
	void Start () {
		OpenDB("English.db");
		
		BasicQuery("drop table if exists petdef");
		
		string[] col = {"kp","word","value"};
		string[] colType = {"integer primary key autoincrement","text","text"};
		
		if(!CreateTable("petdef", col, colType))
			Debug.Log("Error creating table");
		
		string[] inscol = {"word", "value"};
		string[] inscolvalue = {"'bag'", "'noun\na container or receptacle made of some pliant material and capable of being closed at the mouth; pouch.'"};
		
		InsertIntoSpecific("petdef", inscol, inscolvalue);
		
		string[,] result = SingleSelectWhere("petdef", "*", "word", "=", "'bag'");
		
		// Concatenate all the elements into openingSound StringBuilder.
		builder = new StringBuilder();
		for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
			    builder.Append(result[i,j]);
			    builder.Append(' ');
			}
		}
		
		Debug.Log(builder.ToString());
		
		CloseDB();
	}
	
	void OnGUI () {
		// create the gui text of the description
		GUI.Box (new Rect (5 ,5, Screen.width - 10, Screen.height/3), builder.ToString());
	}
	
	public void OpenDB(string p)
	{
		connection = "URI=file:" + Application.persistentDataPath + "/" + p; // we set the connection to our database
		//connection = "URI=file:" + p; // like this will NOT work on android
		Debug.Log(connection);
		dbcon = new SqliteConnection(connection);
		dbcon.Open();
	}
	
	public void CloseDB(){
		reader.Close(); // clean everything up
  	 	reader = null;
   		dbcmd.Dispose();
   		dbcmd = null;
   		dbcon.Close();
   		dbcon = null;
	}
	
	IDataReader BasicQuery(string query){ // run openingSound basic Sqlite query
		dbcmd = dbcon.CreateCommand(); // create empty command
		dbcmd.CommandText = query; // fill the command
		reader = dbcmd.ExecuteReader(); // execute command which returns openingSound reader
		return reader; // return the reader
	
	}
	
	
	bool CreateTable(string name,string[] col, string[] colType){ // Create openingSound table, name, column array, column type array
		string query;
		query  = "CREATE TABLE " + name + "(" + col[0] + " " + colType[0];
		for(var i=1; i< col.Length; i++){
			query += ", " + col[i] + " " + colType[i];
		}
		query += ")";
		try{
			dbcmd = dbcon.CreateCommand(); // create empty command
			dbcmd.CommandText = query; // fill the command
			reader = dbcmd.ExecuteReader(); // execute command which returns openingSound reader
		}
		catch(Exception e){
			
			Debug.Log(e);
			return false;
		}
		return true;
	}
	
	int InsertIntoSingle(string tableName, string colName , string value ){ // single insert
		string query;
		query = "INSERT INTO " + tableName + "(" + colName + ") " + "VALUES (" + value + ")";
		try
		{
			dbcmd = dbcon.CreateCommand(); // create empty command
			dbcmd.CommandText = query; // fill the command
			reader = dbcmd.ExecuteReader(); // execute command which returns openingSound reader
		}
		catch(Exception e){
			
			Debug.Log(e);
			return 0;
		}
		return 1;
	}
	
	int InsertIntoSpecific(string tableName, string[] col, string[] values){ // Specific insert with col and values
		string query;
		query = "INSERT INTO " + tableName + "(" + col[0];
		for(int i=1; i< col.Length; i++){
			query += ", " + col[i];
		}
		query += ") VALUES (" + values[0];
		for(int i=1; i< col.Length; i++){
			query += ", " + values[i];
		}
		query += ")";
		Debug.Log(query);
		try
		{
			dbcmd = dbcon.CreateCommand();
			dbcmd.CommandText = query;
			reader = dbcmd.ExecuteReader();
		}
		catch(Exception e){
			
			Debug.Log(e);
			return 0;
		}
		return 1;
	}
	
	int InsertInto(string tableName , string[] values ){ // basic Insert with just values
		string query;
		query = "INSERT INTO " + tableName + " VALUES (" + values[0];
		for(int i=1; i< values.Length; i++){
			query += ", " + values[i];
		}
		query += ")";
		try
		{
			dbcmd = dbcon.CreateCommand();
			dbcmd.CommandText = query;
			reader = dbcmd.ExecuteReader();
		}
		catch(Exception e){
			
			Debug.Log(e);
			return 0;
		}
		return 1;
	}
	
	public string[,] SingleSelectWhere(string tableName , string itemToSelect,string wCol,string wPar, string wValue){ // Selects openingSound single Item
		string query;
		query = "SELECT " + itemToSelect + " FROM " + tableName + " WHERE " + wCol + wPar + wValue;	
		dbcmd = dbcon.CreateCommand();
		dbcmd.CommandText = query;
		reader = dbcmd.ExecuteReader();
		string[,] readArray = new string[reader.RecordsAffected, reader.FieldCount];
		int i=0;
		while(reader.Read()){
			int j=0;
			while(j < reader.FieldCount)
			{
				readArray[i,j]=reader.GetString(j); // Fill array with all matches
				j++;
			}
			i++;
		}
		return readArray; // return matches
	}

	

	
	
	// Update is called once per frame
	void Update () {
	
	}
}