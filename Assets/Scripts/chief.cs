using UnityEngine;
using System.Collections;
using InControl;
using System;
using ParticlePlayground;


public class chief : InputDonjon {

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
	private BoxCollider b ;
	ParticlePlayground.PlaygroundParticlesC fireScrpit;

	// Use this for initialization
	void Start () {
		_maxFireGun = 0;
		gunUse = true;
		firgunSize = 0;
		b = transform.FindChild("Playground Manager").FindChild ("Playground Fire").GetComponent<BoxCollider>();
		b.enabled = false;
		Debug.Log (b.enabled);
		fireScrpit = this.transform.FindChild ("Playground Manager").transform.FindChild ("Playground Fire").GetComponent<ParticlePlayground.PlaygroundParticlesC> ();
		fireScrpit.emit = false;

				
		if (this.gameObject.tag == "playerChief") 
		{
			monAnim = transform.FindChild("ChiefPasTouché").GetComponent<Animator>();
		}
	}
	// Update is called once per frame
	void Update () {

		var inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices [playerNum] : null;
		updateWithInControl (inputDevice);
		if (inputDevice.Action1 && gunUse == true) {
			firgunSize += 4f * Time.deltaTime;
			if (firgunSize <3.6){
				b.enabled =true;
				b.size = new Vector3(0.2f,firgunSize,1.5f);
				b.isTrigger = true;
				fireScrpit.emit = true;
				b.center = new Vector3(0.0f,(0.0f+firgunSize)/2,0.0f);
			}
			fireScrpit.emit = true;
			_maxFireGun += fireGunOverheatingSpeed;				
		} else if (! inputDevice.Action1 || gunUse == false) {
			b.enabled = false;
			b.isTrigger = false;
			firgunSize = 0.0f;
			fireScrpit.emit = false;
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
