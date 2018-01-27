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

	public void Release()
	{
		if (State == NodeState.Occupied)
		{
			State = NodeState.Free;
		}
	}

	public bool TryAcceptPlayer()
	{
		if (State == NodeState.Free)
		{
			State = NodeState.Occupied;
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
