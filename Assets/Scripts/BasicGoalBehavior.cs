using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGoalBehavior : MonoBehaviour {
	public float rotationSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.right * Time.deltaTime * rotationSpeed);
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.tag == "player") 
		{
			Destroy(gameObject);
		}
	}
}
