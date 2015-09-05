using UnityEngine;
using System.Collections;
using InControl;
using System;

public class chief : InputDonjon {
	public GameObject firegun;
	public GameObject sauce;
	public int sauceSpeed;
	public int firegunUse;
	public int maxFireGun;
	public int fireGunOverheatingSpeed;
	public int fireGunCoolingSpeed;
	private bool gunUse ;
	private int _maxFireGun;
	// Use this for initialization
	void Start () {
		_maxFireGun = 0;
		gunUse = true;
	}

	// Update is called once per frame
	void Update () {
				var inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices [playerNum] : null;
				updateWithInControl (inputDevice);
				if (inputDevice.Action1 && gunUse == true) {
						firegun.SetActive (true);
						_maxFireGun += fireGunOverheatingSpeed;				
				} else if (! inputDevice.Action1 || gunUse == false) {
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
						GameObject instantiatedSauce = Instantiate (sauce, transform.position, transform.rotation) as GameObject;
						instantiatedSauce.transform.rotation = transform.rotation;
						instantiatedSauce.rigidbody.velocity = transform.TransformDirection (new Vector3 (0, 0, sauceSpeed));
				}
		}
<<<<<<< HEAD
		else{
			firegun.SetActive(false);
		}*/

		if (inputDevice.Action2.WasPressed){
			GameObject instantiatedSauce = Instantiate(sauce,transform.position,transform.rotation) as GameObject;
			Debug.Log("sauce tirée");
			instantiatedSauce.transform.rotation = transform.rotation;
			instantiatedSauce.rigidbody.velocity = transform.TransformDirection(new Vector3(0, 0,sauceSpeed));
		}
	}
}
=======
}
>>>>>>> origin/master
