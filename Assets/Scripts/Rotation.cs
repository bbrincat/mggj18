using System;
using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEditor.UI;
using UnityEngine.Analytics;
using UnityEngine.Experimental.Audio.Google;

public enum ZoomerState
{
	Captured,
	Flying
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
	public KeyCode key;

	void Start()
	{
		transform.position = (transform.position - Owner.transform.position).normalized * radius + Owner.transform.position;
		radius = 2.0f;
	}

	public void SetOwner(GameObject g)
	{
		Owner = g;
		
	}
	void Update()
	{

		if ( State == ZoomerState.Captured && Input.GetKeyDown(key))
		{
			State = ZoomerState.Flying;
			LinearDirection = Vector3.Cross(transform.position - Owner.transform.position, Vector3.back).normalized;
		}

		switch (State)
		{
			case ZoomerState.Captured:
				transform.RotateAround(Owner.transform.position, axis, rotationSpeed * Time.deltaTime);
				break;
			case ZoomerState.Flying:
				transform.position = transform.position + LinearDirection * linearSpeed * Time.deltaTime;
				if (Vector3.Magnitude(transform.position - Owner.transform.position) > 100)
				{
					transform.position = (transform.position - Owner.transform.position).normalized * radius + Owner.transform.position;
					State = ZoomerState.Captured;
					gameObject.SetActive(false);
					transform.position = (transform.position - Owner.transform.position).normalized * radius + Owner.transform.position;
					gameObject.SetActive(true);
					
				}
				break;
		}
		
	}
	
	void OnCollisionEnter(Collision collision)
	{
		var node = collision.gameObject.GetComponent<Node>();
		if (node != null)
		{
			if (node.CanAcceptPlayer())
			{
				Owner = collision.gameObject;	
				State = ZoomerState.Captured;
			}
			else
			{
		
			}
	
		}
	
	}
}