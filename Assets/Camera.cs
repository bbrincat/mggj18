	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

	public float speed = 10f;
	public float zoomSpeed = 10.0f;
	
	public float minX = -360.0f;
	public float maxX = 360.0f;
	
	public float minY = -45.0f;
	public float maxY = 45.0f;
 
	public float sensX = 100.0f;
	public float sensY = 100.0f;
	
	float rotationY = 0.0f;
	float rotationX = 0.0f;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
		}


		float scroll = Input.GetAxis("Mouse ScrollWheel");
		transform.Translate(0, scroll * zoomSpeed, scroll * zoomSpeed, Space.World);
//	
//		
//
//		rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
//		rotationY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
//		rotationY = Mathf.Clamp(rotationY, minY, maxY);
//		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
//	
//
//	Debug.Log(transform.position);
//	Debug.Log(transform.rotation);
	}
}
