using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitStop : MonoBehaviour {

	private ParticleSystem ps;

	void Start () {
		ps = GetComponent<ParticleSystem> ();
		Invoke("StopEmitter", 3);
	}

	void StopEmitter() {
		var main = ps.main;
		main.loop = false;
	}
}
