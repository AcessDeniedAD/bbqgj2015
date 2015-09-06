using UnityEngine;
using System.Collections;

public class tache : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (translateScale ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator translateScale()
	{
		while (transform.localScale.x >= 0 ) 
		{
			transform.localScale -= new Vector3(0.02f,0.02f,0.02f);
			yield return 0;
		}
		Destroy (gameObject);
		yield return 0;
		
	}
}
