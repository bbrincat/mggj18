using System;
using System.Collections;	
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

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
	
	public List<Player> Players = new List<Player>();
	
	public GameObject[,] nodes = new GameObject[10,10];

}

	
public class Player
{
	public GameObject zoomer;
	public KeyCode key;
	public Guid id;

	public Player()
	{
		id = Guid.NewGuid();
	}
	public Player(KeyCode key)
	{
		id = Guid.NewGuid();
		this.key = key;
	}
}
	

	
public class Main : MonoBehaviour
{
	public GameObject node;
	public GameObject zoomer;
	
	void Start ()
	{
		Debug.Log("Entered Main.cs");
		
		//setup nodes
		for (int i = 0; i < 10; i++)
		{
			for (int j = 0; j < 10; j++)
			{
				var ri = UnityEngine.Random.Range(-0.4f, 0.4f);
				var rj = UnityEngine.Random.Range(-0.4f, 0.4f);

				var offset = new Vector3(10 * (i - 5 +ri), 10 * (j - 5 +rj ) , 0);
				var position = new Vector3(0,0,0) + offset;
				var go = Instantiate(node, position, Quaternion.identity);
				GameData.Instance.nodes[i,j] = go;
				go.SetActive(true);
			}
		}
		
		//temporary players
		GameData.Instance.Players.Add( new Player(KeyCode.Q));
//		GameData.Instance.Players.Add( new Player(KeyCode.P));
//		GameData.Instance.Players.Add( new Player(KeyCode.C));
//		GameData.Instance.Players.Add( new Player(KeyCode.M));
		
		var players = GameData.Instance.Players;
		foreach (Player p in  players)
		{
			var z = Instantiate(zoomer, new Vector3(0, 0, 0), Quaternion.identity);
			var rotationComponent = z.GetComponent<Rotation>();

			//Put player on a random node
			var attached = false;
			while (!attached)
			{
				var rpi = UnityEngine.Random.Range(0, 10);
				var rpj = UnityEngine.Random.Range(0, 10);

				attached = rotationComponent.attachToNode(GameData.Instance.nodes[rpi, rpj]);

			}
			//rotationComponent.ResetPosition();
			p.zoomer = z;
			rotationComponent.key = p.key;
			z.SetActive(true);	
		}

	}

	// Update is called once per frame
	void Update () {
		
//		for (int i = 0; i < 10; i++)
//		{
//			for (int j = 0; j < 10; j++)
//			{
//				var ri = UnityEngine.Random.Range(-0.1f, 0.1f);
//				var rj = UnityEngine.Random.Range(-0.1f, 0.1f);
//
//				var offset = new Vector3(10 * (i - 5 +ri), 10 * (j - 5 +rj ) , 0);
//				GameData.Instance.nodes[i, j].transform.position += offset;
//			}
		}
//	}
}
