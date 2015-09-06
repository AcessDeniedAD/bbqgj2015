using UnityEngine;
using System.Collections;

public class SauceScript : MonoBehaviour {
	public float sauceSpeed = 0.1f;
	public GameObject sauciseToANim;

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
		if (col.gameObject.tag == "walls")
		{
			Destroy(gameObject);
		}
	}
}