using UnityEngine;
using System.Collections;

public class saucisseScript : MonoBehaviour {
	public bool saucisseSaucee = false;
	public float niveauDeCuisson = 0;
	public int niveauDeCuissonMax = 10;
	public bool saucisseCuite = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "sauce") {
			// appel de la fonction "saucer"
			Saucer();

			// Destruction de la sauce
			Destroy(col.gameObject);
		}
		if (col.gameObject.tag == "plaqueCuisson") {
			// appel de la fonction "cuire"
			Cuire();
		}
	}

	void Saucer(){
		// changement de la variable saucer
		saucisseSaucee = true;

		// Changement du skin
	}

	void Cuire(){
		// MAJ du niveau de cuisson
		niveauDeCuisson ++;
		// Vérifier si la saucisse est cuite
		if (niveauDeCuisson >= niveauDeCuissonMax) {
			saucisseCuite = true;
		}
		// MAJ du skin de la saucisse
	}
}