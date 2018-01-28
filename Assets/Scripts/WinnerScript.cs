using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WinnerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		var num = GameData.Instance.winner.index+1;
		GameObject.FindGameObjectWithTag("p" + num +"image").SetActive(true);
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
