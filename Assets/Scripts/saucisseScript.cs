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
	public Animator monAnim;

	// Use this for initialization
	void Start () {
<<<<<<< HEAD
		this.onFire = false;
=======
		this.gunOnFire = false;

		monAnim = transform.FindChild("Chipo_run").GetComponent<Animator>();
>>>>>>> origin/master
	}

	public void removeLife(float dommage){
		if (this.niveauDeCuisson < this.niveauDeCuissonMax) {
			this.niveauDeCuisson += dommage;
			if (this.onFire != true){
				this.onFire = true;
			}
			timer = fireDommageTime;
<<<<<<< HEAD
=======
			Debug.Log ("TAKEDAMAGE");
			Debug.Log ( monAnim.GetBool("isFiring"));
			monAnim.SetBool("isFiring",true);
			Debug.Log ( monAnim.GetBool("isFiring")+"guygyugyukgkyhgyukgfygyufgu");

>>>>>>> origin/master
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
<<<<<<< HEAD
		//Debug.Log ("Timer:"+timer+"Time.deltaTime" + elapsedTime);
=======
		if (saucisseSurPlaque) {
			Cuire ();
		}


>>>>>>> origin/master
		elapsedTime += 0.1f;

		if(timer < elapsedTime){
<<<<<<< HEAD
			this.onFire = false;
		}

		if (this.onFire == true){
			Debug.Log("onFire est true");
		}

		if (this.onFire == false){
			Debug.Log("onFire est false");
		}


		if (onFire) {
=======
			this.gunOnFire = false;
			monAnim.SetBool("isFiring",false);
		
		}
		Debug.Log (gunOnFire);
		if (gunOnFire) {
>>>>>>> origin/master
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