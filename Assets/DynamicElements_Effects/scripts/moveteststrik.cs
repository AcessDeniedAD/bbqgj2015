using UnityEngine;
using System.Collections;

public class moveteststrik : MonoBehaviour {
	public int actionTime;
	public float timer=0;
	public bool canMove =true;
	public bool canStop = false;
	public GameObject particle;
	private GameObject go;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > actionTime) 
		{
			if(canMove)
			{

				canMove=false;

			}
			else
			{

				DestroyObject(go);
				go=  Instantiate(particle, new Vector3(transform.position.x, Mathf.Round(transform.position.y)-1,transform.position.z), Quaternion.identity) as GameObject;
				canMove=true;
			}

			timer = 0;

		}
		if (canMove) {

						
						transform.position += Vector3.left * Time.deltaTime;
				}
	
		Debug.Log (canMove);

	}
}
