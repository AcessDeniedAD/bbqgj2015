using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour {
	public GameObject boxToPopPowerUp;
	private float timer=0; 
	public GameObject powerUp;
	public GameObject lightStrike;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;


		if (timer >= 5) 
		{
			Vector3 positionToPop = new Vector3( Random.Range(boxToPopPowerUp.collider.bounds.min.x,boxToPopPowerUp.collider.bounds.max.x),-8, Random.Range(boxToPopPowerUp.collider.bounds.min.z,boxToPopPowerUp.collider.bounds.max.z));
			Instantiate(powerUp,positionToPop,Quaternion.identity);
			Instantiate(lightStrike,new Vector3( positionToPop.x,positionToPop.y-1,positionToPop.z),Quaternion.identity);
			timer= 0;
		}
	}
}
