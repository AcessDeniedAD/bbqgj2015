﻿using UnityEngine;
using System.Collections;

public class firegun : MonoBehaviour {
	public float Gundommage;
	// Use this for initialization
	void Start () {

	}

	void OnTriggerStay(Collider other) {
		//Debug.Log ("test");
			if (other.gameObject.tag == "player") {
			//Debug.Log ("LOLILOL");
				saucisseScript otherScript = other.GetComponent<saucisseScript> ();
				otherScript.removeLife (Gundommage);
				otherScript.onFire = true;
			otherScript.elapsedTime = 0.0f;
			}
	}



	// Update is called once per frame
	void Update () {
	
	}
}
