using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour {
	public GameObject boxToPopPowerUp;
	private float timer=0; 
	public GameObject powerUp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;


		if (timer >= 2) 
		{
			Vector3 positionToPop = new Vector3 ();
			Instantiate(powerUp,new Vector3( Random.Range(boxToPopPowerUp.collider.bounds.min.x,boxToPopPowerUp.collider.bounds.max.x),2, Random.Range(boxToPopPowerUp.collider.bounds.min.z,boxToPopPowerUp.collider.bounds.max.z)), transform.rotation);
			timer= 0;
			Debug.Log ("POP");
		}
	}
}
