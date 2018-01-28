using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour {

	public AudioClip audioclip;
	private AudioSource audiosource;

	void Awake() {
		audiosource = this.GetComponent<AudioSource> ();
		DontDestroyOnLoad(this.gameObject);
	}

	void Start() {
		audiosource.Play ();
		audiosource.clip = audioclip;
	}
	void Update(){
		if (SceneManager.GetActiveScene().name == "main") {
			Destroy (this.gameObject);
		}
	}
}
