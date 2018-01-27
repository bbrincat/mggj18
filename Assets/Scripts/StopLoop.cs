using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLoop : MonoBehaviour {

	private ParticleSystem ps;

	void Start () {
		ps = GetComponent<ParticleSystem> ();

		var main = ps.main;
		main.loop = false;
	}
}
