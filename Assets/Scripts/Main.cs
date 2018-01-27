using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

	public GameObject node;
	public GameObject zoomer;
	
	// Use this for initialization
	void Start ()
	{
		Debug.Log("Entered Main.cs");
		
		GameObject[,] nodes = new GameObject[10,10];
		
		for (int i = 0; i < 10; i++)
		{
			for (int j = 0; j < 10; j++)
			{
				var offset = new Vector3(10 * (i - 5), 10 * (j - 5), 0);
				var position = new Vector3(0,0,0) + offset;
				var go = Instantiate(node, position, Quaternion.identity);
				nodes[i,j] = go;
				go.SetActive(true);
			}
		}
		
		var z = Instantiate(zoomer, new Vector3(0,0,0), Quaternion.identity);
		z.SetActive(true);
		z.GetComponent<Rotation>().SetOwner(nodes[0, 0]);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
