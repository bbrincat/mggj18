using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;	
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("things");
		
		var addPlayerGO = GameObject.Find("AddPlayerButton");
		var addPlayerButton = addPlayerGO.GetComponent<Button>();
		addPlayerButton.onClick.AddListener(AddPlayer);
		Debug.Log(addPlayerGO.name);
		
		var playGO = GameObject.Find("PlayButton");
		var playButton = addPlayerGO.GetComponent<Button>();
		playButton.onClick.AddListener(play);
		Debug.Log(addPlayerGO.name);
		
	}

	private Player currentPlayer;
	
	void AddPlayer()
	{

		currentPlayer = new Player();
		GameData.Instance.Players.Add(currentPlayer);
		Debug.Log("Added Player:" + currentPlayer.id);
	
	}
	
	void play()
	{
		Debug.Log("PLAY");
		SceneManager.LoadScene("main");
	}
	
	// Update is called once per frame
	void Update () {
			if (currentPlayer != null) {
			foreach (KeyCode vKey in Enum.GetValues(typeof(KeyCode)))
			{
				if (Input.GetKey(vKey))
				{
					currentPlayer.key = vKey;
					Debug.Log(currentPlayer.id + " " + vKey);
//					var z = Instantiate(GameData.Instance.zoomer, new Vector3(0, 0, 0), Quaternion.identity);
//
//					//Put player on a random node
//					var ri = UnityEngine.Random.Range(10, 10);
//					var rj = UnityEngine.Random.Range(10, 10);
//					z.GetComponent<Rotation>().SetOwner(GameData.Instance.nodes[ri, rj]);
//					z.SetActive(true);
				}
			}
		}
	}
}
