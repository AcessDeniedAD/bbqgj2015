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
	private Renderer rend;
	public float dangerousLevel;
	public float onFireDommage;
	public float fireDommageTime;
	public Texture[] textures;
	public Animator monAnim;
	public GameObject skin;

	// Use this for initialization
	void Start () {
		this.onFire = false;
		//monAnim = transform.FindChild("Chipo_run").GetComponent<Animator>();
	}

	public void removeLife(float dommage){
		if (this.niveauDeCuisson < this.niveauDeCuissonMax) {
			this.niveauDeCuisson += dommage;
			if (this.onFire != true){
				this.onFire = true;
				timer = fireDommageTime;
				Debug.Log ("TAKEDAMAGE");
				Debug.Log ( monAnim.GetBool("isFiring"));
				monAnim.SetBool("isFiring",true);
				Debug.Log ( monAnim.GetBool("isFiring")+"guygyugyukgkyhgyukgfygyufgu");
				rend = skin.renderer;
			}

		}
	}

	public void addLife(float heal){
		if (this.niveauDeCuisson > 0) {
			this.niveauDeCuisson -= heal;
		}
	}

	public void kill(){
		if (this.niveauDeCuisson >= this.niveauDeCuissonMax) {
			Destroy (gameObject);				
		}
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log ("Timer:"+timer+"Time.deltaTime" + elapsedTime);
		elapsedTime += 0.1f;
		if (niveauDeCuisson < niveauDeCuissonMax / 3) {
			skin.renderer.material.mainTexture = textures[0];
		}else if (niveauDeCuisson > niveauDeCuissonMax / 3 && niveauDeCuisson < niveauDeCuissonMax / 1.5) {
			skin.renderer.material.mainTexture = textures[1];
		}else if(niveauDeCuisson >= niveauDeCuissonMax ) {
			skin.renderer.material.mainTexture = textures[2];
			skin.renderer.material.color = Color.black;
		}

		if(timer < elapsedTime){
			this.onFire = false;
			monAnim.SetBool("isFiring",false);
		}

		if (this.onFire == true){
			monAnim.GetBool("isFiring");
		}

		if (this.onFire == false){
		}
		
		if (onFire) {
			this.removeLife(onFireDommage);		
			monAnim.SetBool("isFiring",true);
		}
		
		if (!onFire && this.niveauDeCuisson > this.dangerousLevel) {
			addLife(heal);
		}
	}

	void OnTriggerEnter (Collider col)
	{	
		if (col.gameObject.tag == "sauce") {
			kill ();
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