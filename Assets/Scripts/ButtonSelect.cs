using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour {

	private bool readyPlayer1 = false;
	private bool readyPlayer2 = false;
	private bool readyPlayer3 = false;

	private bool secondCount = false;
	private bool thirdCount = false;

	private bool gameReady = false;

	public GameObject countdown;

	public Button buttonPlayer1;
	public Button buttonPlayer2;
	public Button buttonPlayer3;
	public Button buttonPlayer4;

	public Sprite OnSpritePlayer1;
	public Sprite OnSpritePlayer2;
	public Sprite OnSpritePlayer3;
	public Sprite OnSpritePlayer4;

	public Sprite sprite3;
	public Sprite sprite2;
	public Sprite sprite1;

	float timeLeft = 3.0f;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			ChangeImage (buttonPlayer1, OnSpritePlayer1);
			readyPlayer1 = true;
			GameData.Instance.Players.Add( new Player(KeyCode.Q));
		}
		if (Input.GetKeyDown (KeyCode.P) && readyPlayer1) {
			ChangeImage (buttonPlayer2, OnSpritePlayer2);
			readyPlayer2 = true;
			GameData.Instance.Players.Add( new Player(KeyCode.P));
		}
		if (Input.GetKeyDown (KeyCode.C) && readyPlayer1 && readyPlayer2) {
			ChangeImage (buttonPlayer3, OnSpritePlayer3);
			readyPlayer3 = true;
			GameData.Instance.Players.Add( new Player(KeyCode.C));
		}
		if (Input.GetKeyDown (KeyCode.M) && readyPlayer1 && readyPlayer2 && readyPlayer3) {
			ChangeImage (buttonPlayer4, OnSpritePlayer4);
			GameData.Instance.Players.Add (new Player (KeyCode.M));
			gameReady = true;
			countdown.SetActive (true);
		}
		if(Input.GetKeyDown (KeyCode.Space) && readyPlayer1 && readyPlayer2) {
			gameReady = true;
			countdown.SetActive (true);
		}
		if (gameReady) {
			countdown.GetComponent<Image> ().sprite = sprite1;
			timeLeft -= Time.deltaTime;
			if (timeLeft < 3.0f && timeLeft > 2.0f) {
				countdown.GetComponent<Image> ().sprite = sprite3;
				thirdCount = true;
			} 
			if (timeLeft > 1.0f && timeLeft < 2.0f) {
				countdown.GetComponent<Image> ().sprite = sprite2;
			}
		}
		if (timeLeft < 0) {
			Application.LoadLevel("main");
		}

	}

	public void ChangeImage(Button button, Sprite sprite){
		button.image.sprite = sprite;
	}
}
