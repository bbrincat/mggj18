using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelect : MonoBehaviour {

	public Sprite hoverSprite;
	public Sprite idleSprite;

	void OnMouseOver()
	{
		this.GetComponent<Image> ().sprite = hoverSprite;
	}

	void OnMouseExit() {
		this.GetComponent<Image> ().sprite = idleSprite;
	}
}
