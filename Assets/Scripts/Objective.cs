using UnityEngine;
using System.Collections.Generic;

public class Objective
{
    public GameObject StartObject, OwnerObject, OwnerPlayer;
    public List<GameObject> FinalObjects;
    
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
            startNode.ActivateObjective(Node.NodeObjectiveState.Start);
        }
            
        foreach (var finalObject in FinalObjects)
        {
            var finalNode = finalObject.GetComponent<Node>();
            if (finalNode.CanRegisterObjective())
            {
                State = ObjectiveState.WaitingCapture;
                finalNode.ActivateObjective(Node.NodeObjectiveState.Final);
                finalNode.Objective = this;
            }
        }		
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
