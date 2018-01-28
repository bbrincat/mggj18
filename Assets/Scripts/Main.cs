using System;
using System.Collections;	
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class Main : MonoBehaviour
{

	public Transform pinkHighlight;
	public Transform blueHighlight;
	public Transform greenHighlight;
	public Transform orangeHighlight;

	public Material pinkTrail;
	public Material blueTrail;
	public Material greenTrail;
	public Material orangeTrail;

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
				var go = Instantiate(GameData.Instance.node, position, Quaternion.identity);
				GameData.Instance.nodes[i,j] = go;
				go.SetActive(true);
			}
		}

		//temporary players
//		GameData.Instance.Players.Add( new Player(KeyCode.Q));
//		GameData.Instance.Players.Add( new Player(KeyCode.P));
//		GameData.Instance.Players.Add( new Player(KeyCode.C));
//		GameData.Instance.Players.Add( new Player(KeyCode.M));
		
//		var players = GameData.Instance.Players;
//		foreach (Player p in  players)
//		{
//			var z = Instantiate(GameData.Instance.zoomer, new Vector3(0, 0, 0), Quaternion.identity);
//			var rotationComponent = z.GetComponent<Rotation>();
//
//			//Put player on a random node
//			var attached = false;
//			while (!attached)
//			{
//				var rpi = UnityEngine.Random.Range(0, 10);
//				var rpj = UnityEngine.Random.Range(0, 10);
//
//				attached = rotationComponent.attachToNode(GameData.Instance.nodes[rpi, rpj]);
//
//			}
//			//rotationComponent.ResetPosition();
//			p.zoomer = z;
//			rotationComponent.player = p;
//			z.SetActive(true);	
//		}
		var playerNodes = new List<GameObject>(); 
		playerNodes.Add(GameData.Instance.nodes[0,0]);
		playerNodes.Add(GameData.Instance.nodes[9,0]);
		playerNodes.Add(GameData.Instance.nodes[0,9]);
		playerNodes.Add(GameData.Instance.nodes[9,9]);

		var finalNodes = new List<GameObject>();
		finalNodes.Add(GameData.Instance.nodes[0, 0]);
		finalNodes.Add(GameData.Instance.nodes[9, 0]);
		finalNodes.Add(GameData.Instance.nodes[0, 9]);
		finalNodes.Add(GameData.Instance.nodes[9, 9]);

		var playerTrails = new List<Material>();
		playerTrails.Add(pinkTrail);
		playerTrails.Add(blueTrail);
		playerTrails.Add(greenTrail);
		playerTrails.Add(orangeTrail);

		var playerHightlights = new List<Transform>();
		playerHightlights.Add(pinkHighlight);
		playerHightlights.Add(blueHighlight);
		playerHightlights.Add(greenHighlight);
		playerHightlights.Add(orangeHighlight);

		//Debug.Log (GameData.Instance.Players.Count);

		for (int i=0; i < GameData.Instance.Players.Count; i++)
		{
			
			var zoomer = Instantiate(GameData.Instance.zoomer, new Vector3(0, 0, 0), Quaternion.identity);
			zoomer.GetComponent<TrailRenderer>().material = playerTrails[i];
			GameData.Instance.Players[i].zoomer = zoomer;
			zoomer.GetComponent<Rotation>().highlight= playerHightlights[i];
			zoomer.GetComponent<Rotation>().player = GameData.Instance.Players[i];
		}

		var objective = new Objective(GameData.Instance.nodes[4, 4],finalNodes);
	
		if (objective.State != Objective.ObjectiveState.Invalid)
		{
			GameData.Instance.Objectives.Add(objective);
		}


		var level = new Level(objective, playerNodes);
		GameData.Instance.Levels.Add(level);
		level.ActivateLevel();
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
