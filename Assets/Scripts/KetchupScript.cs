using UnityEngine;
using System.Collections;

public class KetchupScript : MonoBehaviour {
	public float sauceSpeed = 0.1f;
	public GameObject sauciseToANim;
	public GameObject TacheKetchup;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * sauceSpeed);
	}
	
	void OnTriggerEnter(Collider col)
	{
		// Destruction de la bille de sauce si elle touvhe un mur
		if (col.gameObject.tag == "wall")
		{
			Destroy(gameObject);
			Rigidbody instantiatedKetchup = Instantiate (TacheKetchup, transform.position, transform.rotation) as Rigidbody;
		}
	}
}