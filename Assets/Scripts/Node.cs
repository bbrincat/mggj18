using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using Random = UnityEngine.Random;

public class Node : MonoBehaviour {

	public enum NodeState
	{
		Free,
		Occupied
	}

	public enum NodeObjectiveState
	{
		None,
		Start,
		StartTaken,
		Final,
		FinalTaken
	}

	public GameObject StartObjectiveDecorator;
	public GameObject FinalObjectiveDecorator;

	public GameObject Completed;
	
	public NodeState State = NodeState.Free;
	public NodeObjectiveState ObjectiveState = NodeObjectiveState.None;
	public Objective Objective;
	// Use this for initialization
	void Start () {
		
	}

	public bool CanRegisterObjective()
	{
		return !(ObjectiveState == NodeObjectiveState.Start || ObjectiveState == NodeObjectiveState.Final);
	}

	public void InitObjective(NodeObjectiveState state)
	{
		if (state == NodeObjectiveState.Start)
		{
			ObjectiveDecoration = Instantiate(StartObjectiveDecorator, gameObject.transform);
		}

		if (state == NodeObjectiveState.Final)
		{
			ObjectiveDecoration = Instantiate(FinalObjectiveDecorator, gameObject.transform);

		}
		ObjectiveDecoration.SetActive(true);

		ObjectiveState = state;

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
			if (ObjectiveState == NodeObjectiveState.Start)
			{
				ObjectiveDecoration.SetActive(false);
				
				Objective.State = Objective.ObjectiveState.Captured;
				ObjectiveState = NodeObjectiveState.StartTaken;
			}

			if (ObjectiveState == NodeObjectiveState.Final)
			{
				ObjectiveDecoration.SetActive(false);	
				Objective.State = Objective.ObjectiveState.Delivered;
				ObjectiveState = NodeObjectiveState.FinalTaken;
				
				
				//TODO replace
				Completed.SetActive(true);
			}
			
			State = NodeState.Occupied;

			return true;
		}else
		{
			return false;
		}
	}

//	private bool ObjectiveDecoration = false;
	private GameObject ObjectiveDecoration;
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
