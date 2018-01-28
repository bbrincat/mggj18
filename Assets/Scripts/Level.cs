using System.CodeDom;
using System.Collections.Generic;
using System.Runtime.Remoting;
using NUnit.Framework.Constraints;
using UnityEngine;

public class Level
{
    public Objective Objective;
    public List<GameObject> PlayerNodes;

    public Level(Objective objective,  List<GameObject> playerNodes)
    {
        Objective = objective;
        PlayerNodes = playerNodes;
    }

    public void ActivateLevel()
    {
        for (int i=0; i < GameData.Instance.Players.Count; i++)
        {            
            var rotationComponent = GameData.Instance.Players[i].zoomer.GetComponent<Rotation>();

            rotationComponent.attachToNode(PlayerNodes[i]); 
            rotationComponent.ResetPosition();

            GameData.Instance.Players[i].zoomer.SetActive(true);	
        }
        
        Objective.ActivateObjective();
        GameData.Instance.currentObjective = Objective;

    }
}