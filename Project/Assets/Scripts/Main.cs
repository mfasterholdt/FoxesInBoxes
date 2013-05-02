using UnityEngine;
using System.Collections;
using System.IO;

public class Main : MonoBehaviour 
{	
	public GameObject[] tiles;
	
	string fileName = "level01.txt";

	void Start ()
	{
		//Read file
	    StreamReader sr = new StreamReader(Application.dataPath + "/Levels/" + fileName);
	    string fileContents = sr.ReadToEnd();
	    sr.Close();
	 
		//Parse file
	    string[] lines = fileContents.Split("\n"[0]);
		
	    foreach(string l in lines) {
	        Debug.Log(l);
	    }
	}
}
