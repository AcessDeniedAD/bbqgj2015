using UnityEngine;
using System.Collections;
using ParticlePlayground;

public class plaquefire : MonoBehaviour {
	ParticlePlayground.PlaygroundParticlesC playground;
	public float elapsedTime;
	public float onFireElapsedTime;
	public float notOnFireElapsedTime;
	private bool onFire;
	private BoxCollider b;
	// Use this for initialization
	void Start () {
		playground = this.GetComponent<ParticlePlayground.PlaygroundParticlesC> ();
		onFire = false;
		onFireElapsedTime = Random.Range (0, 40);
		notOnFireElapsedTime = Random.Range (0, 40);

	}	
	
	// Update is called once per frame
	void Update () {
		elapsedTime += 0.1f;
		if ( onFire ==false && elapsedTime >= onFireElapsedTime) {
			notOnFireElapsedTime = Random.Range (0, 40);
			playground.emit=true;
			elapsedTime = 0.1f;
			onFire = true;

		}
		else if (elapsedTime >= notOnFireElapsedTime && onFire ==true) {
			onFireElapsedTime = Random.Range (0, 40);
			playground.emit=false;
			onFire = false;
			elapsedTime = 0.1f;
		}
	}
}
