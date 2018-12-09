using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic; //for use list 
using UnityEngine.UI;
using System.Xml;//for using xml attributes
using System.Xml.Serialization;//for access to xml serializer which will take the class and make it into xml file
using System.IO; // for file managment - open , close


public class XML_Manager : MonoBehaviour
{


    public static XML_Manager ins; //to allow other class to access
    public InputField field;


    //when we awake up the instance is made xml manager 
    private void Awake()
    {
        ins = this;


    }


    //list of item 

    public itemDataBase itmDB;

    //save information into xml file

    public void saveInfo()
    {
        //open new xml file 
        XmlSerializer serializer = new XmlSerializer(typeof(itemDataBase)); //spicify kind of class that will coverting to or from
        FileStream stream;


        if (System.IO.File.Exists(Application.dataPath + "/streamingAssets/XML/player_info.xml"))
        {
            stream = new FileStream(Application.dataPath + "/streamingAssets/XML/player_info.xml", FileMode.Append);
            serializer.Serialize(stream, itmDB);

        }
        else
        {
            stream = new FileStream(Application.dataPath + "/streamingAssets/XML/player_info.xml", FileMode.Create);
            serializer.Serialize(stream, itmDB);
        }
        stream.Close();

    }

    //load and read data from xml file
    public void loadInfo()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(itemDataBase)); //spicify kind of class that will coverting to or from
        FileStream stream = new FileStream(Application.dataPath + "/streamingAssets/XML/player_info.xml", FileMode.Open);
        itmDB = serializer.Deserialize(stream) as itemDataBase;
        stream.Close();

    }
}


//kind of entry inside the xml file  
[System.Serializable]
public class ItemEntry
{



    [XmlAttribute]
    public string playerName;

    [XmlAttribute]
    public int playerScore = 9;


}

[System.Serializable]
public class itemDataBase
{
    [XmlArray("PlayerInformation")]
    public List<ItemEntry> list = new List<ItemEntry>();

}
