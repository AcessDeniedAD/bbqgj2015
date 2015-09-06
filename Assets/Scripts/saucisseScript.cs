using UnityEngine;
using System.Collections;

public class saucisseScript : MonoBehaviour {
	public bool saucisseSaucee = false;
	public float niveauDeCuisson = 0;
	public int niveauDeCuissonMax = 10;
	public bool saucisseCuite = false;
	public bool saucisseSurPlaque = false;
	public float heal;
	public bool onFire;
	private float timer;
	[HideInInspector]public float elapsedTime;
	public float dangerousLevel;
	public float onFireDommage;
	public float fireDommageTime;

	// Use this for initialization
	void Start () {
		this.onFire = false;
	}

	public void removeLife(float dommage){
		if (this.niveauDeCuisson < this.niveauDeCuissonMax) {
			this.niveauDeCuisson += dommage;
			if (this.onFire != true){
				this.onFire = true;
			}
			timer = fireDommageTime;
		}
	}

	public void addLife(float heal){
		if (this.niveauDeCuisson > 0) {
			this.niveauDeCuisson -= heal;
		}
	}

	public void kill(){
		if (this.niveauDeCuisson >= this.niveauDeCuissonMax) {
			Destroy (this);				
		}
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log ("Timer:"+timer+"Time.deltaTime" + elapsedTime);
		elapsedTime += 0.1f;

		if(timer < elapsedTime){
			this.onFire = false;
		}

		if (this.onFire == true){
			Debug.Log("onFire est true");
		}

		if (this.onFire == false){
			Debug.Log("onFire est false");
		}


		if (onFire) {
			this.removeLife(onFireDommage);		
		}

		if (!onFire && this.niveauDeCuisson > this.dangerousLevel) {
			addLife(heal);
		}
	}

	void OnTriggerEnter (Collider col)
	{	
		if (col.gameObject.tag == "sauce") {
			Saucer();
			// Destruction de la sauce
			Destroy(col.gameObject);
		}


	}
	void OnTriggerStay(Collider col) {
		if (col.gameObject.tag == "plaqueCuisson") {
			removeLife(onFireDommage);
			this.elapsedTime = 0.0f;
		}
	}

	void Saucer(){
		// changement de la variable saucer
		saucisseSaucee = true;
		// Changement du skin
	}
}