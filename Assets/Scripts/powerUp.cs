using UnityEngine;
using System.Collections;

public class powerUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.transform.localScale = new Vector3 (0,0,0);
		StartCoroutine (translateScale ());
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	IEnumerator translateScale()
	{
		while (gameObject.transform.localScale.x<=0.5) 
		{
			gameObject.transform.localScale+=new Vector3(0.8f *Time.deltaTime,0.8f *Time.deltaTime,0.8f *Time.deltaTime);
			yield return 0 ;
		}
		gameObject.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		gameObject.collider.isTrigger = true;
		gameObject.rigidbody.isKinematic = true;
		yield return 0;
	}
	void OnTriggerEnter(Collider other)
	{
		Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == "player") 
		{
			Destroy(gameObject);
		}
	}
}
