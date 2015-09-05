using UnityEngine;
using System.Collections;
using InControl;
using System;

public class chief : InputDonjon {
	public GameObject firegun;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		var inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices[playerNum] : null;
		updateWithInControl (inputDevice);
		if (inputDevice.Action1) {
			firegun.SetActive(true);
						
		}
		else{
			firegun.SetActive(false);
		}
	}
}
