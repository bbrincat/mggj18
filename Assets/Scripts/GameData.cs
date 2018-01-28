using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    private static GameData _instance;
 
    public static GameData Instance
    {
        get
        {
            if(_instance == null)
                _instance = new GameData();
			
            return _instance;
        }
    }
    //prefabs

    public GameObject zoomer = Resources.Load("Zoomer") as GameObject;
    public GameObject node = Resources.Load("Node") as GameObject;
    public GameObject objective = Resources.Load("Magic_Ring_08") as GameObject;
    public GameObject bravu = Resources.Load("Bravu") as GameObject;

//	public Transform highlight = Resources.Load("Highlight") as Transform;
//    
//    public Material pinkTrail = Resources.Load("Glow") as Material;
//    public Material blueTrail = Resources.Load("Blue") as Material;
//    public Material greenTrail = Resources.Load("Green") as Material;
//    public Material orangeTrail = Resources.Load("Orange") as Material;
 
    public List<Player> Players = new List<Player>();
    public List<Objective> Objectives = new List<Objective>();
    public Objective currentObjective;
    public GameObject[,] nodes = new GameObject[10,10];
    public List<Level> Levels = new List<Level>();

}

	