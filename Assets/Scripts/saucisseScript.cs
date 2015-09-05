using UnityEngine;
using System.Collections;

public class saucisseScript : MonoBehaviour {
	public bool saucisseSaucee = false;
	public float niveauDeCuisson = 0;
	public int niveauDeCuissonMax = 10;
	public bool saucisseCuite = false;
	public bool saucisseSurPlaque = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (saucisseSurPlaque) {
			Cuire ();
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