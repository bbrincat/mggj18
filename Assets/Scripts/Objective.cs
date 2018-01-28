using System;
using UnityEngine;
using System.Collections.Generic;


public class Objective
{
    public GameObject StartObject, OwnerObject, OwnerPlayer;
    public List<GameObject> FinalObjects;

    public Dictionary<int, GameObject> playerObjectives = new Dictionary<int, GameObject>();
    
    public enum ObjectiveState
    {
        Pending,
        WaitingCapture,
        Captured,
        Delivered,
        Invalid
    }

    public ObjectiveState State;

    public Player winner;

    public Objective(GameObject startObject, List<GameObject> finalObjects)
    {
        StartObject = startObject;
        OwnerObject = startObject;

        FinalObjects = finalObjects;
        
        for (int i= 0; i < GameData.Instance.Players.Count; i++)
        {
            playerObjectives.Add(i,finalObjects[i]); 
        }
        
    }

    public bool CanActivateObjective()
    {
        var startNode = StartObject.GetComponent<Node>();

        foreach (var finalObject in FinalObjects)
        {
            if (!finalObject.GetComponent<Node>().CanRegisterObjective())
            {
                return false;
            }
        }
        return startNode.CanRegisterObjective();
    }
    //maybe throw exception
    public void ActivateObjective()
    {
        var startNode = StartObject.GetComponent<Node>();
        if (startNode.CanRegisterObjective())
        {
            State = ObjectiveState.WaitingCapture;
            startNode.Objective = this;
            startNode.ActivateObjective();
        }
    }

    public void ActivateObjectiveEndpoints(Player player)
    {
        var finalObject = playerObjectives[player.index];
        
//        foreach (var finalObject in FinalObjects)
//        {
            var finalNode = finalObject.GetComponent<Node>();
            if (finalNode.CanRegisterObjective())
            {
                State = ObjectiveState.WaitingCapture;
                finalNode.ActivateObjectiveEndpoint();
                finalNode.Objective = this;
            }
//        }		
    }
    
    public void DeactivateObjectiveEndpoints(Player player)
    {
        var finalObject = playerObjectives[player.index];
        
        var finalNode = finalObject.GetComponent<Node>();
        finalNode.DeactivateObjectiveEndpoint();
        finalNode.Objective = this;

    }

    public void DeactivateObjective()
    {
        State = ObjectiveState.Delivered;
        
        var startNode = StartObject.GetComponent<Node>();
        startNode.DeactivateObjective();
        
        foreach (var finalObject in FinalObjects)
        {
            var finalNode = finalObject.GetComponent<Node>();
            finalNode.DeactivateObjective();
        }

    }


    public void TransferBall(Node node, Player player)
    {
       State = ObjectiveState.Captured;
      
    }
}	
