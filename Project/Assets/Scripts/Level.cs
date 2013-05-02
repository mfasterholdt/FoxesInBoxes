using UnityEngine;
using System.Collections;
using System.IO;

public class Level : MonoBehaviour 
{	
	public GameObject[] tileList;
	public string fileName = "level01.txt";

	Tile[,] tiles;
	string[,] levelData;	
	int levelWidth;
	int levelHeight;
	
	static int tileSize = 1;
	
	float widthOffset;
	float heightOffset;
	
	void Start ()
	{		
		LoadLevel(fileName);
		
		CreateLevel();
	}
	
	void LoadLevel(string name)
	{
		//Read file
	    StreamReader sr = new StreamReader(Application.dataPath + "/Levels/" + name);
	    string fileContents = sr.ReadToEnd();
	    sr.Close();
	 
		//Parse file
	    string[] lines = fileContents.Split("\n"[0]);
		levelHeight = lines.Length;
		levelWidth = (lines[0] as string).Length;
		
		levelData = new string[levelWidth,levelHeight];
		tiles = new Tile[levelWidth, levelHeight];
		
		for(int y = 0; y < levelHeight; y++)
		{
			string line = lines[y];
			
			for(int x = 0; x < levelWidth; x++) 
			{
				levelData[x,y] = line.Substring(x, 1);
			}
	    }
	}
	
	void CreateLevel()
	{
		widthOffset =  (tileSize - levelWidth) / 2f;
		heightOffset = (levelHeight - tileSize) / 2f;
		
		Camera.mainCamera.orthographicSize = levelHeight / 1.9f;
		
		for(int y = 0; y < levelHeight; y++)
		{	
			for(int x = 0; x < levelWidth; x++) 
			{
				int index = int.Parse(levelData[x,y]);
				
				Vector2 pos = new Vector2(x, y);
				CreateTile(index, pos);
			}
	    }
	}
	
	void CreateTile(int index, Vector3 p)
	{
		//Create tile
		
		Vector3 pos = new Vector3(p.x * tileSize, p.y * -tileSize, 0);
		pos.x += widthOffset;
		pos.y += heightOffset;
		
		GameObject newObj = Instantiate(tileList[index]) as GameObject;
		Tile newTile = newObj.GetComponent<Tile>();
		
		newObj.transform.parent = this.transform;
		newTile.Setup(pos);	
		
		
		if(newTile.type == Tile.Type.environemnt)
		{
			
		}
		else
		{
			//Create air behind object
			CreateTile(0, p);
		}
	}
}
