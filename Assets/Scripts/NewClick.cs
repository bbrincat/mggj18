using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewClick : MonoBehaviour {
	void Start() {
		this.GetComponent<Button>().onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Application.LoadLevel ("PlayerSelect");
	}
}
