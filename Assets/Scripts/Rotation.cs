using System;
using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEditor.UI;
using UnityEngine.Analytics;
using UnityEngine.Assertions.Must;
using UnityEngine.Experimental.Audio.Google;

public enum ZoomerState
{
	Captured,
	Flying,
	Collision
}

public class Rotation : MonoBehaviour
{

	public Vector3 axis = Vector3.up;
	
	public float radius = 2.0f;
	public float linearSpeed = 1f;
	public float rotationSpeed = 100.0f;
	
	public ZoomerState State = ZoomerState.Captured;
	public Vector3 LinearDirection;

	public GameObject Owner;
	public GameObject PreviousOwner;

	public Transform explosion;
	public Transform highlight;

	public Player player;

	public GameObject BallDecoration;

	private AudioSource audiosource;
	

	void Start()
	{
		transform.position = (transform.position - Owner.transform.position).normalized * radius + Owner.transform.position;
		radius = 2.0f;

	}

	public void SetOwner(GameObject g)
	{
		Owner = g;	
	}
	
	public Node GetCurrentNode()
	{
		return Owner.GetComponent<Node>();
	}
	
	public Node GetPreviousNode()
	{
		if (PreviousOwner != null)
		{
			return PreviousOwner.GetComponent<Node>();
		}

		return null;
	}

	public void  ResetPosition()
	{
		transform.position = (transform.position - Owner.transform.position).normalized * radius + Owner.transform.position;
	}

	void Update()
	{
		
		Debug.Log("Update: " + State );	
		
		switch (State)
		{
			case ZoomerState.Captured:
				if (Input.GetKeyDown(player.key))
				{
					LinearDirection = Vector3.Cross(transform.position - Owner.transform.position, Vector3.back).normalized;
					PreviousOwner = Owner;
					State = ZoomerState.Flying;
				}
				else
				{
					transform.RotateAround(Owner.transform.position, axis, rotationSpeed * Time.deltaTime);
				}
				break;
			case ZoomerState.Flying:
				transform.position = transform.position + LinearDirection * linearSpeed * Time.deltaTime;
				
				//Collided with nothing.
				if (Vector3.Magnitude(transform.position - PreviousOwner.transform.position) > 100)
				{
//					transform.position = (transform.position - Owner.transform.position).normalized * radius + Owner.transform.position;
			
					gameObject.SetActive(false);
					transform.position = (transform.position - PreviousOwner.transform.position).normalized * radius + PreviousOwner.transform.position;
					gameObject.SetActive(true);
					
					State = ZoomerState.Captured;

				}
				break;
		}
		
	}

	
	
	public bool attachToNode(GameObject gameObject)
	{
		var node = gameObject.GetComponent<Node>();
		Debug.Log("Collided with " + gameObject.name);
		Debug.Log(node);
		if (node != null)
		{
			if (node.TryAcceptPlayer(player))
			{
				Owner = gameObject;
				if (GetPreviousNode() != null)
				{
					GetPreviousNode().Release();
				}

				State = ZoomerState.Captured;
				return true;
			}
		}

		return false;
	}
	
	public void TakeBall()
	{
//
//		var pos = new Vector3(gameObject.transform.position.x+3,
//			gameObject.transform.position.y+3,
//			gameObject.transform.position.z);
		
		BallDecoration = Instantiate(GameData.Instance.objective, gameObject.transform);
//		BallDecoration.transform.position = pos;
		BallDecoration.SetActive(true);
	}

	public void ReleaseBall()
	{
BallDecoration.SetActive(false);

	}
	
	
	void OnCollisionEnter(Collision collision)
	{
		audiosource = this.GetComponent<AudioSource> ();
		audiosource.Play ();

		Debug.Log("Collision: " + State );	
//		State = ZoomerState.Collision;
		
		if (State != ZoomerState.Captured) {
			if (!attachToNode(collision.gameObject))
			{
				var opposite = Vector3.Dot(LinearDirection, collision.contacts[0].normal);
				LinearDirection = (LinearDirection - opposite * collision.contacts[0].normal).normalized;
//			foreach (ContactPoint contact in collision.contacts) {
//				print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
//				
//				Debug.DrawRay(contact.point, contact.normal, Color.white);
				//}
				//Do bounce back
			}
			else
			{
				ResetPosition();
				
				Instantiate (explosion, Owner.transform);

				Instantiate (highlight, Owner.transform);

			}
		}
//		{
//			State = ZoomerState.Captured;
//			PreviousOwner = Owner;
//			Owner = nul
//			PreviousOwner.GetComponent<Node>().Release();
//			
//		}
	}
}