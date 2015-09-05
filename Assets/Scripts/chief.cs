using UnityEngine;
using System.Collections;
using InControl;
using System;


public class chief : InputDonjon {
	public GameObject firegun;
	//public GameObject sauce;
	public Rigidbody sauce;
	public int sauceSpeed=100000;
	public int firegunUse;
	public int maxFireGun;
	public int fireGunOverheatingSpeed;
	public int fireGunCoolingSpeed;
	private bool gunUse ;
	private int _maxFireGun;
	private float firgunSize;


	// Use this for initialization
	void Start () {
		_maxFireGun = 0;
		gunUse = true;
		firgunSize = 0;




	}	
	
	// Update is called once per frame
	void Update () {
		BoxCollider b = firegun.collider as BoxCollider;
		var inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices [playerNum] : null;
		updateWithInControl (inputDevice);
		if (inputDevice.Action1 && gunUse == true) {
			firgunSize += 4f * Time.deltaTime;
			if (firgunSize <3.3){
				b.size = new Vector3(1.0f,firgunSize,0.7f);
				b.center = new Vector3(0.0f,(0.0f+firgunSize)/2,0.0f);
			}
			firegun.SetActive (true);
			_maxFireGun += fireGunOverheatingSpeed;				
		} else if (! inputDevice.Action1 || gunUse == false) {
			firgunSize = 0.0f;
			firegun.SetActive (false);
			if (_maxFireGun > 0)
				_maxFireGun -= fireGunCoolingSpeed;
		}

		if (_maxFireGun >= maxFireGun) {
			gunUse = false;
		} else if (_maxFireGun <= firegunUse && gunUse == false) {
			gunUse = true;
		}

		if (inputDevice.Action2.WasPressed) {
			Rigidbody instantiatedSauce = Instantiate (sauce, transform.position, transform.rotation) as Rigidbody;
		}
	}
}
