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

	public GameObject Completed;
	
	public NodeState State = NodeState.Free;
	public NodeObjectiveState nodeObjectiveState = NodeObjectiveState.None;
	public Objective Objective;
	
	// Use this for initialization
	void Start () {
		
	}

	public bool CanRegisterObjective()
	{
		return nodeObjectiveState != NodeObjectiveState.Start;
	}

	public void ActivateObjective(NodeObjectiveState state)
	{
		if (state == NodeObjectiveState.Start)
		{
			ObjectiveDecoration = Instantiate(GameData.Instance.objective, gameObject.transform);
		}

		if (state == NodeObjectiveState.Final)
		{
			ObjectiveDecoration = Instantiate(GameData.Instance.objective, gameObject.transform);
			Debug.Log("Activating Final Objective");

		}
		
		ObjectiveDecoration.SetActive(true);
		nodeObjectiveState = state;

	}

	public void DeactivateObjective()
	{
		nodeObjectiveState = NodeObjectiveState.None;
		ObjectiveDecoration.SetActive(false);
	}
	
	
	public void Release()
	{
		if (State == NodeState.Occupied)
		{
			State = NodeState.Free;
		}
	}

	public bool TryAcceptPlayer(Player player)
	{
		if (State == NodeState.Free)
		{
			if (nodeObjectiveState == NodeObjectiveState.Start)
			{
				ObjectiveDecoration.SetActive(false);
				
				Objective.State = Objective.ObjectiveState.Captured;
				nodeObjectiveState = NodeObjectiveState.StartTaken;

				player.hasBall = true;
				Debug.Log("Transferred ball to player");
				
			}

			if (nodeObjectiveState == NodeObjectiveState.Final)
			{
				if (player.hasBall)
				{
					Debug.Log("ball delivered");

					ObjectiveDecoration.SetActive(false);
					
					nodeObjectiveState = NodeObjectiveState.FinalTaken;

					player.hasBall = false;
					
					Objective.winner = player;
					Objective.DeactivateObjective();

					//TODO replace
					GameData.Instance.bravu.SetActive(true);
				}
	
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
