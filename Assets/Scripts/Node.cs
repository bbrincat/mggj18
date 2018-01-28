
using UnityEngine;
using UnityEngine.SceneManagement;

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
		FinalDisabled,
		FinalTaken
	}

	public GameObject Completed;
	
	public NodeState State = NodeState.Free;
	public NodeObjectiveState nodeObjectiveState = NodeObjectiveState.None;
	public Objective Objective;

	public Player CurrentPlayer;
	
	
//	private bool ObjectiveDecoration = false;
	private GameObject ObjectiveDecoration;
	
	// Use this for initialization
	void Start () {
		
	}

	public bool CanRegisterObjective()
	{
		return nodeObjectiveState != NodeObjectiveState.Start;
	}

	public void ActivateObjective()
	{
		ObjectiveDecoration = Instantiate(GameData.Instance.objective, gameObject.transform);
		
		ObjectiveDecoration.SetActive(true);
		nodeObjectiveState = Node.NodeObjectiveState.Start;

	}
	
	public void ActivateObjectiveEndpoint()
	{
		if (ObjectiveDecoration == null)
		{
			ObjectiveDecoration = Instantiate(GameData.Instance.objective, gameObject.transform);
		}
		
		ObjectiveDecoration.SetActive(true);
		nodeObjectiveState = NodeObjectiveState.Final;

	}
	
	public void DeactivateObjectiveEndpoint()
	{
		ObjectiveDecoration.SetActive(false);
		nodeObjectiveState = NodeObjectiveState.FinalDisabled;

	}
	

	public void DeactivateObjective()
	{
		nodeObjectiveState = NodeObjectiveState.None;
		if (ObjectiveDecoration != null)
		{
			ObjectiveDecoration.SetActive(false);

		}
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
		switch (State)
		{
			case NodeState.Free:
			
				if (nodeObjectiveState == NodeObjectiveState.Start)
				{
					ObjectiveDecoration.SetActive(false);
					
					Objective.State = Objective.ObjectiveState.Captured;
					nodeObjectiveState = NodeObjectiveState.StartTaken;
	
					player.TakeBall();
					Debug.Log("Transferred ball to player");
					
					Objective.ActivateObjectiveEndpoints(player);

				}
	
				if (nodeObjectiveState == NodeObjectiveState.Final)
				{
					if (player.hasBall)
					{
						
				
						
						ObjectiveDecoration.SetActive(false);
						
						nodeObjectiveState = NodeObjectiveState.FinalTaken;
	
						player.hasBall = false;
						
						Objective.winner = player;
						Objective.DeactivateObjective();
	
						//TODO replace
						Debug.Log("ball delivered");
						GameData.Instance.winner = player;
						SceneManager.LoadScene("Victory");
						GameData.Instance.bravu.SetActive(true);
					}
				}

				CurrentPlayer = player;
				State = NodeState.Occupied;
				return true;
				break;

			case NodeState.Occupied:
				Debug.Log(CurrentPlayer + " lost the ball. Play "+ player.key+ "took ball");

				
				if (CurrentPlayer.hasBall)
				{
					Debug.Log(Objective);
					Debug.Log(player);
					Debug.Log(CurrentPlayer);
					
					GameData.Instance.currentObjective.ActivateObjectiveEndpoints(player);
					GameData.Instance.currentObjective.DeactivateObjectiveEndpoints(CurrentPlayer);

					CurrentPlayer.ReleaseBall();
					player.TakeBall();
					Debug.Log(CurrentPlayer.key + " lost the ball. Play "+ player.key+ "took ball");
				}
				return false;
		}

		return false;
	}

	
	
	// Update is called once per frame
	void Update () {
		Debug.Log("Objective" + Objective);
	}
}
