using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Node : MonoBehaviour {

	public enum NodeState
	{
		Free,
		Occupied
	}

	public NodeState State = NodeState.Free;
	
	// Use this for initialization
	void Start () {
		
	}

	public bool CanAcceptPlayer()
	{
		if (State == NodeState.Free)
		{
			return true;
		}else
		{
			return false;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
