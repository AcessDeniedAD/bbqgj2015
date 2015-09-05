using UnityEngine;
using System.Collections;
using InControl;
using System;

public class chief : InputDonjon {
	public GameObject firegun;
	public GameObject sauce;
	public int sauceSpeed;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		var inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices[playerNum] : null;
		updateWithInControl (inputDevice);
		/*if (inputDevice.Action1) {
			firegun.SetActive(true);

						
		}
		else{
			firegun.SetActive(false);
		}*/

		if (inputDevice.Action2.WasPressed){
			Rigidbody instantiatedSauce = Instantiate(sauce,Quaternion.identity) as Rigidbody;
			instantiatedSauce.transform.rotation = transform.rotation;
			instantiatedSauce.velocity = transform.TransformDirection(new Vector3(0, 0,sauceSpeed));
		}
	}
}