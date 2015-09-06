using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {
	private int numberPlayerDead;
	public int numberPlayWhoMustDie;
	public float timer = 10.0f;
	private float minutes;
	private float seconde;
	// Use this for initialization
	void Start () {
	
	}

	void OnGUI(){
		GUI.Box (new Rect (10, 10, 70, 20), "" + (int)minutes+" : " +(int)seconde);
	}
	void upNumberPlayerDead(){
		numberPlayerDead += 1;
	}
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		minutes = timer / 60;
		seconde = timer %60;
		if (numberPlayerDead >= numberPlayWhoMustDie) {
				Debug.Log ("Player win");
		} else if (timer <= 0) {
			Debug.Log ("Cheif win");
			timer =0;
		}

	}
}
