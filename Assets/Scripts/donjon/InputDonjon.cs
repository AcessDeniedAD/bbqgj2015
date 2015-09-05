using UnityEngine;
using System.Collections;
using InControl;
using System;

public class InputDonjon : MonoBehaviour {
	private Quaternion saveRotate;
	public int playerNum;
	public GameObject saucisseGameObject;
	private float speed =0.1f;
	public Animator monAnim ;
	// Use this for initialization
	void Start () {
		if(gameObject.tag == "player")
		monAnim = transform.FindChild("Chipo_run").GetComponent<Animator>();
	
	}
	public void updateWithInControl(InputDevice inputDevice){
		if (monAnim != null) 
		{
			if(inputDevice.LeftStick)
				monAnim.SetBool ("walking", true);
			else
				monAnim.SetBool ("walking", false);
		}

		//var inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices[playerNum] : null;
		float moveY = 0;
		float moveX = 0;
		moveX -= inputDevice.LeftStickX;
		if (moveX == 0)
			moveX -= inputDevice.DPad.X;
			moveY -= inputDevice.LeftStickY;
		if (moveY == 0)
			moveY -= inputDevice.DPad.Y;
		if (inputDevice.LeftStick) {
					
			transform.position += new Vector3 (-moveX * speed, 0, -moveY * speed);
			
			if (inputDevice != null) {
				if (Mathf.Abs (inputDevice.LeftStickX) >= 0.19 || Mathf.Abs (inputDevice.LeftStickY) >= 0.19) {
					transform.rotation = Quaternion.Euler (new Vector3 (0, Mathf.Atan2 (inputDevice.LeftStickX, inputDevice.LeftStickY) * Mathf.Rad2Deg, 0));		
				if (transform.rotation.eulerAngles.y != 180 && transform.rotation.eulerAngles.y != -180)
					saveRotate = transform.rotation;
				}
				else
				{
					transform.rotation = saveRotate;	
				}
			} 
			else 
			{
				transform.rotation = saveRotate;	
			}
		}
	}
	// Update is called once per frame
	void Update () {
			var inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices[playerNum] : null;
			this.updateWithInControl(inputDevice);

	}
	void OnCollisionEnter(Collision collision) {
		Debug.Log(collision.collider.name);
	}
}
	