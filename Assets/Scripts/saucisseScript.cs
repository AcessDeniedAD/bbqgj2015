using UnityEngine;
using System.Collections;

public class saucisseScript : MonoBehaviour {
	public bool saucisseSaucee = false;
	public float niveauDeCuisson = 0;
	public int niveauDeCuissonMax = 10;
	public bool saucisseCuite = false;
	public bool saucisseSurPlaque = false;
	public float heal;
	[HideInInspector]public bool gunOnFire;
	private float timer;
	[HideInInspector]public float elapsedTime;
	public float dangerousLevel;
	public float onFireDommage;
	public float fireDommageTime;
	public Animator monAnim;

	// Use this for initialization
	void Start () {
		this.gunOnFire = false;

		monAnim = transform.FindChild("Chipo_run").GetComponent<Animator>();
	}


	public void removeLife(float dommage){
		if (this.niveauDeCuisson < this.niveauDeCuissonMax) {
			this.niveauDeCuisson += dommage;
			this.gunOnFire = true;
			timer = fireDommageTime;
			Debug.Log ("TAKEDAMAGE");
			Debug.Log ( monAnim.GetBool("isFiring"));
			monAnim.SetBool("isFiring",true);
			Debug.Log ( monAnim.GetBool("isFiring")+"guygyugyukgkyhgyukgfygyufgu");

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
		if (saucisseSurPlaque) {
			Cuire ();
		}


		elapsedTime += 0.1f;
		if(timer < elapsedTime){
			this.gunOnFire = false;
			monAnim.SetBool("isFiring",false);
		
		}
		Debug.Log (gunOnFire);
		if (gunOnFire) {
			this.removeLife(onFireDommage);		
		}
		if (!gunOnFire && this.niveauDeCuisson > this.dangerousLevel) {
			addLife(heal);
		}
	}

	void OnTriggerEnter (Collider col)
	{	
		if (col.gameObject.tag == "sauce") {
			Debug.Log ("trigger saucisse & sauce");
			// appel de la fonction "saucer"
			Saucer();

			// Destruction de la sauce
			Destroy(col.gameObject);
		}

		if (col.gameObject.tag == "plaqueCuisson") {
			Debug.Log ("triggerEnter: saucisse & plaque de cuisson");
			Debug.Log ("début de la cuisson");
			saucisseSurPlaque = true;
		}
	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject.tag == "plaqueCuisson") {
			Debug.Log ("triggerExit: saucisse & plaque de cuisson");
			Debug.Log ("fin de la cuisson");
			saucisseSurPlaque = false;
		}
	}

	void Saucer(){
		// changement de la variable saucer
		saucisseSaucee = true;

		// Changement du skin
	}

	void Cuire(){
		// MAJ du niveau de cuisson
		Debug.Log ("cuisson+");
		niveauDeCuisson ++;
		Debug.Log ("niveau de cuisson"+ niveauDeCuisson);
		// Vérifier si la saucisse est cuite
		if (niveauDeCuisson >= niveauDeCuissonMax) {
			saucisseCuite = true;
		}
		// MAJ du skin de la saucisse
	}
}